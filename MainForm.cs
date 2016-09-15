using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdamMil.Utilities;
using DigitalRune.Windows.TextEditor;
using DigitalRune.Windows.TextEditor.Actions;
using DigitalRune.Windows.TextEditor.Document;
using DigitalRune.Windows.TextEditor.TextBuffer;

namespace ExePatch
{
  partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    public MainForm(string[] args) : this()
    {
      if(args.Length != 0) initialFile = args[0];
    }

    public string StatusText
    {
      get { return lblStatus.Text; }
      set { lblStatus.Text = value; }
    }

    protected override void OnClosed(EventArgs e)
    {
      closed = true;
      Utility.Dispose(asmTimer);
      System.Threading.Monitor.Enter(this); // wait for any assembly to finish (to remove in-use temp files)
      System.Threading.Monitor.Exit(this);
    }

    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
      base.OnClosing(e);
      foreach(TabPage page in tabControl.TabPages)
      {
        if(!IsOkayToCloseFile((TabEditControl)page.Controls[0]))
        {
          e.Cancel = true;
          break;
        }
      }
    }

    protected override void OnLoad(EventArgs e)
    {
 	    base.OnLoad(e);

      IntPtr hIcon = LoadIcon(GetModuleHandle(null), new IntPtr(32512));
      if(hIcon != IntPtr.Zero) Icon = System.Drawing.Icon.FromHandle(hIcon);

      NewFile();

      if(!string.IsNullOrEmpty(initialFile))
      {
        try { OpenFile(initialFile); }
        catch(Exception ex) { Program.ShowErrorMessage(ex); }
      }

      asmTimer = new System.Threading.Timer(TimerTick, null, 1000, 100);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      base.OnKeyDown(e);

      if(!e.Handled)
      {
        if(e.KeyCode == Keys.F3 && e.Modifiers == Keys.Control)
        {
          e.Handled = true;

          ITextBufferStrategy textBuffer = AsmEditor.Document.TextBufferStrategy;
          int offset = AsmEditor.ActiveTextAreaControl.Caret.Offset, length = textBuffer.Length;
          if(offset < length)
          {
            int start = offset, end = offset+1;
            char c = textBuffer.GetCharAt(offset);
            if(char.IsLetterOrDigit(c) || c == '_')
            {
              while(start > 0 && (char.IsLetterOrDigit((c=textBuffer.GetCharAt(start-1))) || c == '_')) start--;
              while(end < length && (char.IsLetterOrDigit((c=textBuffer.GetCharAt(end))) || c == '_')) end++;
            }
            else if(!char.IsWhiteSpace(c))
            {
              while(start > 0 && !char.IsLetterOrDigit((c=textBuffer.GetCharAt(start-1))) && !char.IsWhiteSpace(c) && c != '_') start--;
              while(end < length && !char.IsLetterOrDigit((c=textBuffer.GetCharAt(end))) && !char.IsWhiteSpace(c) && c != '_') end++;
            }
            else
            {
              return;
            }

            AsmEditor.ActiveTextAreaControl.TextArea.SelectionManager.SetSelection(AsmEditor.Document.OffsetToPosition(start),
                                                                                   AsmEditor.Document.OffsetToPosition(end));
            OpenFindReplaceForm(false);
            findReplace.FindNext();
          }
          else if(e.KeyCode == Keys.Tab && (e.Modifiers == Keys.Control || e.Modifiers == (Keys.Control|Keys.Shift)))
          {
            int index = tabControl.SelectedIndex;
            if(e.Modifiers == Keys.Control)
            {
              if(++index == tabControl.TabCount) index = 0;
            }
            else
            {
              if(--index < 0) index = tabControl.TabCount-1;
            }
            tabControl.SelectedIndex = index;
          }
        }
        else if(e.Modifiers == Keys.Control && e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
        {
          int index = e.KeyCode == Keys.D0 ? 9 : e.KeyCode-Keys.D1;
          if(index < tabControl.TabCount) tabControl.SelectedIndex = index;
        }
      }
    }

    internal TextEditorControl AsmEditor
    {
      get { return Editor.AsmEditor; }
    }

    TabEditControl Editor { get; set; }

    bool CloseFile(bool force)
    {
      if(force || IsOkayToCloseFile())
      {
        lock(this)
        {
          if(tabControl.TabCount == 1)
          {
            Editor.Reset();
            UpdateCaption();
          }
          else
          {
            int currentIndex = tabControl.SelectedIndex;
            tabControl.SelectedIndex = currentIndex < tabControl.TabCount-1 ? currentIndex+1 : currentIndex-1;
            tabControl.TabPages.RemoveAt(currentIndex);
          }
        }
        return true;
      }

      return false;
    }

    bool EnsureAssembled()
    {
      lock(this)
      {
        if(Editor.LastChangeTime != 0)
        {
          Program.StatusText = "Assembling...";
          TryToAssemble(AsmEditor.Text);
        }
      }

      if(Editor.AssembledCode == null)
      {
        MessageBox.Show("An error occurred while assembling the code.", "Assembly failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }

      if(Editor.AssembledCode.Length == 0)
      {
        MessageBox.Show("Write some code first.", "No code", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }

      Chunk failed = Editor.AssembledCode.FirstOrDefault(c => c.Error != null);
      if(failed != null)
      {
        MessageBox.Show("Failed to assemble chunk " + failed.MemoryAddress.ToString("X") + "h: " + failed.Error, "Assembly failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }

      return true;
    }

    void Execute(IEditAction action)
    {
      action.Execute(AsmEditor.ActiveTextAreaControl.TextArea);
    }

    bool IsOkayToCloseFile()
    {
      return IsOkayToCloseFile(Editor);
    }

    bool IsOkayToCloseFile(TabEditControl editor)
    {
      if(editor.Changed)
      {
        string fileName = editor.FilePath == null ? "untitled" : Path.GetFileName(editor.FilePath);
        DialogResult r = MessageBox.Show("Do you want to save your changes before closing " + fileName + "?", "Save changes?",
                                         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
        if(r == DialogResult.Cancel || r == DialogResult.Yes && !SaveFile(editor, editor.FilePath)) return false;
      }
      return true;
    }

    void NewFile()
    {
      lock(this)
      {
        TabEditControl oldEditor = Editor;
        Editor = new TabEditControl();
        Editor.Reset();
        Editor.AsmEditor.DocumentChanged += txtAsm_DocumentChanged;
        Editor.AsmEditor.ActiveTextAreaControl.TextArea.DragDrop  += txtAsm_DragDrop;
        Editor.AsmEditor.ActiveTextAreaControl.TextArea.DragEnter += txtAsm_DragEnterOrOver;
        Editor.AsmEditor.ActiveTextAreaControl.TextArea.DragOver  += txtAsm_DragEnterOrOver;

        TabPage page = new TabPage("untitled");
        page.Controls.Add(Editor);
        tabControl.TabPages.Add(page);
        tabControl.SelectedIndex = tabControl.TabCount-1;
        Editor.Dock = DockStyle.Fill; // if we set this earlier, the initial layout won't work
        if(oldEditor != null)
        {
          Editor.SplitDistance = oldEditor.SplitDistance;
        }
        else // for whatever reason, the SelectedIndexChanged event isn't raised when the first tab is added
        {
          UpdateCaption();
          UpdateAssemblyStatus();
        }
      }
    }

    internal bool OpenFile(string path)
    {
      if(!Editor.IsNewFile) NewFile();
      try
      {
        AsmEditor.Text = File.ReadAllText(path);
        Editor.FilePath = Path.GetFullPath(path);
        Editor.Changed = false; // this will have been set when the text was changed
        Editor.IsNewFile = false;
        UpdateCaption();
        return true;
      }
      catch(Exception ex)
      {
        Program.ShowErrorMessage(ex);
        return false;
      }
    }

    void OpenFindReplaceForm(bool forceVisible)
    {
      if(findReplace == null)
      {
        findReplace = new FindReplaceForm();
        findReplace.FormClosed += (o, e) =>
        {
          FindReplaceForm form = (FindReplaceForm)o;
          findReplace = null;
        };
        findReplace.FormClosing += (o, e) =>
        {
          if(!closed && e.CloseReason == CloseReason.UserClosing)
          {
            ((Form)o).Hide();
            e.Cancel = true;
          }
        };
        findReplace.Owner = this;
      }

      string selection = AsmEditor.ActiveTextAreaControl.TextArea.SelectionManager.SelectedText;
      bool multiLineSelect = selection.Contains('\n');
      if(!multiLineSelect) findReplace.FindText = selection;
      findReplace.UseSelection = multiLineSelect;

      if(forceVisible || findReplace.Visible)
      {
        if(!findReplace.Visible) findReplace.Show();
        findReplace.Activate();
      }
    }

    bool SaveFile(string path)
    {
      if(SaveFile(Editor, path))
      {
        UpdateCaption();
        lblStatus.Text = "File saved.";
        return true;
      }
      return false;
    }

    bool SaveFile(TabEditControl editor, string path)
    {
      try
      {
        if(path == null)
        {
          using(SaveFileDialog sfd = new SaveFileDialog())
          {
            sfd.DefaultExt = "asm";
            sfd.Filter = "Assembly files (*.asm)|*.asm|All files (*.*)|*";
            sfd.Title  = "Select the file to save as...";
            sfd.SupportMultiDottedExtensions = true;
            if(editor.FilePath != null)
            {
              sfd.InitialDirectory = Path.GetDirectoryName(editor.FilePath);
              sfd.FileName = editor.FilePath;
            }
            if(sfd.ShowDialog() != DialogResult.OK) return false;
            path = sfd.FileName;
          }
        }

        File.WriteAllText(path, editor.AsmEditor.Text);
        editor.FilePath = path;
        editor.Changed = false;
        editor.IsNewFile = false;
        return true;
      }
      catch(Exception ex)
      {
        Program.ShowErrorMessage(ex);
        return false;
      }
    }

    void TimerTick(object context)
    {
      lock(this)
      {
        int currentTime = Environment.TickCount, lastChangeTime = Editor.LastChangeTime;
        if(lastChangeTime != 0 && currentTime - lastChangeTime > 500 && !closed)
        {
          string asm = null;
          Invoke((Action)delegate { asm = AsmEditor.Text; lblAssembly.Text = "Assembling..."; });
          TryToAssemble(asm);
        }
      }
    }

    void TryToAssemble(string asm)
    {
      Editor.AssembledCode = null;
      Chunk[] chunks;
      uint baseAddress = Editor.BaseAddress;
      try { Editor.AssembledCode = chunks = Program.AssembleChunks(asm, baseAddress); }
      finally { Editor.LastChangeTime = 0; }

      if(!closed)
      {
        StringBuilder sb = new StringBuilder();
        foreach(Chunk chunk in chunks)
        {
          if(chunks.Length > 1)
          {
            if(sb.Length != 0) sb.AppendLine();
            sb.Append("ORG ").Append(chunk.MemoryAddress.ToString("X")).Append('h');
            uint defaultFileOffset = chunk.MemoryAddress >= baseAddress ? chunk.MemoryAddress - baseAddress : chunk.MemoryAddress;
            if(chunk.FileOffset != defaultFileOffset) sb.Append(" ; file offset = ").Append(chunk.FileOffset.ToString("X")).Append('h');
            sb.AppendLine();
          }

          if(chunk.Error != null)
          {
            sb.Append("ERROR: ").AppendLine(chunk.Error);
          }
          else if(chunk.Code.Length > 100000)
          {
            sb.AppendLine("The output is too large to display.");
          }
          else
          {
            const string HexChars = "0123456789ABCDEF";
            for(int i=0; i<chunk.Code.Length; )
            {
              bool sep = false;
              for(int e=Math.Min(chunk.Code.Length, i+16); i<e; i++)
              {
                if(sep) sb.Append(' ');
                else sep = true;
                byte value = chunk.Code[i];
                sb.Append(HexChars[value>>4]).Append(HexChars[value&0xF]);
              }
              sb.AppendLine();
            }
          }
        }

        BeginInvoke((Action)delegate
        {
          Editor.HexViewer.Text = sb.ToString();
          UpdateAssemblyStatus();
        });
      }
    }

    void UpdateAssemblyStatus()
    {
      int failureCount = Editor.AssembledCode == null ? -1 : Editor.AssembledCode.Count(c => c.Error != null);
      if(failureCount != 0)
      {
        lblAssembly.Text = failureCount < 0 || failureCount == Editor.AssembledCode.Length ?
          "Assembly failed." : "Assembly partially failed (" + failureCount + " of " + Editor.AssembledCode.Length.ToString() + " chunks)";
      }
      else
      {
        int totalLength = Editor.AssembledCode.Sum(c => c.Code.Length);
        lblAssembly.Text = totalLength.ToString() + " (0x" + totalLength.ToString("X") + ") assembled bytes.";
      }
    }

    void UpdateCaption()
    {
      string fileName = (Editor.FilePath == null ? "untitled" : Path.GetFileName(Editor.FilePath)) + (Editor.Changed ? "*" : null);
      Text = fileName + " - ExePatch";
      tabControl.SelectedTab.Text = fileName;
    }

    void aboutMenuItem_Click(object sender, EventArgs e)
    {
      using(AboutForm form = new AboutForm()) form.ShowDialog();
    }

    void assemblerSyntaxMenuItem_Click(object sender, EventArgs e)
    {
      Process.Start("http://www.nasm.us/docs.php");
    }

    void closeMenuItem_Click(object sender, EventArgs e)
    {
      CloseFile(false);
    }

    void commentOutMenuItem_Click(object sender, EventArgs e)
    {
      Execute(new ToggleLineComment(true));
    }

    void toggleCommentsMenuItem_Click(object sender, EventArgs e)
    {
      Execute(new ToggleLineComment());
    }

    void uncommentMenuItem_Click(object sender, EventArgs e)
    {
      Execute(new ToggleLineComment(false));
    }

    void disassembleMenuItem_Click(object sender, EventArgs e)
    {
      using(DisassemblyForm form = new DisassemblyForm(Editor.BaseAddress))
      {
        if(form.ShowDialog() == DialogResult.OK)
        {
          if(form.Append)
          {
            AsmEditor.Document.Insert(AsmEditor.Document.TextLength, "\n");
            AsmEditor.Document.Insert(AsmEditor.Document.TextLength, form.Disassembly);
          }
          else
          {
            if(!Editor.IsNewFile) NewFile();
            AsmEditor.Document.TextContent = form.Disassembly;
          }
          lblStatus.Text = "Disassembly successful.";
        }
      }
    }

    void exitMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    void findMenuItem_Click(object sender, EventArgs e)
    {
      OpenFindReplaceForm(true);
    }

    void findNextMenuItem_Click(object sender, EventArgs e)
    {
      if(findReplace == null || string.IsNullOrEmpty(findReplace.FindText)) OpenFindReplaceForm(true);
      else findReplace.FindNext();
    }

    void findAndReplaceMenuItem_Click(object sender, EventArgs e)
    {
      OpenFindReplaceForm(true);
    }

    void goToLineMenuItem_Click(object sender, EventArgs e)
    {
      using(GoToLineForm form = new GoToLineForm())
      {
        if(form.ShowDialog() == DialogResult.OK)
        {
          int newLine = Math.Max(0, form.Line-1);
          AsmEditor.ActiveTextAreaControl.ScrollTo(newLine, 0);
          AsmEditor.ActiveTextAreaControl.Caret.Line = newLine;
        }
      }
    }

    void idaScriptMenuItem_Click(object sender, EventArgs e)
    {
      if(EnsureAssembled())
      {
        using(ScriptForm form = new ScriptForm(Editor.BaseAddress, Editor.AssembledCode))
        {
          if(form.ShowDialog() == DialogResult.OK) lblStatus.Text = "IDAPython script placed on the clipboard.";
        }
      }
    }

    void patchMenuItem_Click(object sender, EventArgs e)
    {
      if(EnsureAssembled())
      {
        using(PatchForm form = new PatchForm(Editor.BaseAddress, Editor.PatchFile, Editor.PatchProcessId, Editor.SuspendProcess,
                                             Editor.AssembledCode))
        {
          if(form.ShowDialog() == DialogResult.OK)
          {
            if(form.PatchFile)
            {
              Editor.PatchFile      = form.FilePath;
              Editor.PatchProcessId = 0;
            }
            else
            {
              Editor.PatchProcessId = form.ProcessId;
              Editor.SuspendProcess = form.ShouldSuspendProcess;
            }
            lblStatus.Text = "Executable patched.";
          }
        }
      }
    }

    void newMenuItem_Click(object sender, EventArgs e)
    {
      NewFile();
    }

    void openMenuItem_Click(object sender, EventArgs e)
    {
      using(OpenFileDialog ofd = new OpenFileDialog())
      {
        if(Editor.FilePath != null) ofd.InitialDirectory = Path.GetDirectoryName(Editor.FilePath);
        ofd.ShowReadOnly = false;
        ofd.SupportMultiDottedExtensions = true;
        ofd.Title = "Select a file to open...";
        ofd.Filter = "Assembly files (*.asm)|*.asm|All files (*.*)|*";
        if(ofd.ShowDialog() == DialogResult.OK) OpenFile(ofd.FileName);
      }
    }

    void saveBinaryMenuItem_Click(object sender, EventArgs e)
    {
      if(EnsureAssembled())
      {
        if(Editor.AssembledCode.Length > 1)
        {
          MessageBox.Show("There are multiple assembled chunks. You can only save a single chunk as binary. (Try commenting others out.)",
                          "Too many chunks", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }

        using(SaveFileDialog sfd = new SaveFileDialog())
        {
          sfd.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*";
          sfd.Title  = "Select the file to save as...";
          sfd.SupportMultiDottedExtensions = true;
          if(sfd.ShowDialog() == DialogResult.OK)
          {
            try
            {
              File.WriteAllBytes(sfd.FileName, Editor.AssembledCode[0].Code);
              lblStatus.Text = Editor.AssembledCode[0].Code.Length.ToString() + " assembled bytes saved.";
            }
            catch(Exception ex) { Program.ShowErrorMessage(ex); }
          }
        }
      }
    }

    void saveMenuItem_Click(object sender, EventArgs e)
    {
      SaveFile(Editor.FilePath);
    }

    void saveAsMenuItem_Click(object sender, EventArgs e)
    {
      SaveFile(null);
    }

    void tabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
      Editor = (TabEditControl)tabControl.SelectedTab.Controls[0];
      UpdateCaption();
      UpdateAssemblyStatus();
    }

    void tutorialMenuItem_Click(object sender, EventArgs e)
    {
      Process.Start("http://www.youtube.com/watch?v=IxzDhsNGA5A&hd=1");
    }

    void txtAsm_DocumentChanged(object sender, DocumentEventArgs e)
    {
      TabEditControl editor = Editor;
      editor.LastChangeTime = Environment.TickCount;
      bool firstChange = !editor.Changed;
      editor.Changed = true;
      if(firstChange)
      {
        editor.IsNewFile = false;
        UpdateCaption();
      }
    }

    void txtAsm_DragDrop(object sender, DragEventArgs e)
    {
      if(e.Data.GetDataPresent(DataFormats.FileDrop))
      {
        object data = e.Data.GetData(DataFormats.FileDrop);
        string fileName = data as string;
        string[] names = data as string[];
        if(names != null && names.Length != 0) fileName = names[0];
        if(!string.IsNullOrEmpty(fileName)) OpenFile(fileName);
      }
    }

    void txtAsm_DragEnterOrOver(object sender, DragEventArgs e)
    {
      if((e.AllowedEffect & DragDropEffects.Copy) != 0 && e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
    }

    System.Threading.Timer asmTimer;
    FindReplaceForm findReplace;
    readonly string initialFile;
    bool closed;

    [System.Runtime.InteropServices.DllImport("kernel32.dll")]
    static extern IntPtr GetModuleHandle(string moduleName);
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr iconName);
  }
}
