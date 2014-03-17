using System;
using System.Windows.Forms;
using DigitalRune.Windows.TextEditor.Document;
using DigitalRune.Windows.TextEditor.TextBuffer;

namespace ExePatch
{
  public partial class FindReplaceForm : Form
  {
    public FindReplaceForm()
    {
      InitializeComponent();
    }

    public FindReplaceForm(string initialFindText, string initialReplaceText) : this()
    {
      txtFind.Text      = initialFindText;
      txtReplace.Text   = initialReplaceText;
    }

    public string FindText
    {
      get { return txtFind.Text; }
      set { txtFind.Text = value; }
    }

    public string ReplaceText
    {
      get { return txtReplace.Text; }
      set { txtReplace.Text = value; }
    }

    public bool UseSelection
    {
      get { return radSelection.Checked; }
      set
      {
        if(!value) radDocument.Checked = true;
        else if(radSelection.Enabled) radSelection.Checked = true;
      }
    }

    public void Center()
    {
      CenterToParent();
    }

    public void FindNext()
    {
      if(!string.IsNullOrEmpty(FindText)) FindNext(FindText, true, true);
    }

    protected override void OnClosed(EventArgs e)
    {
      base.OnClosed(e);
      Editor.ActiveTextAreaControl.TextArea.SelectionManager.SelectionChanged -= OnSelectionChanged;
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      base.OnKeyDown(e);
      if(!e.Handled && e.KeyCode == Keys.F3 && e.Modifiers == Keys.None)
      {
        FindNext();
        e.Handled = true;
      }
    }

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);

      OnSelectionChanged(null, null);
      Editor.ActiveTextAreaControl.TextArea.SelectionManager.SelectionChanged += OnSelectionChanged;

      txtFind.Focus();
      txtFind.SelectAll();

      CenterToParent();
    }

    DigitalRune.Windows.TextEditor.TextEditorControl Editor
    {
      get { return ((MainForm)Owner).AsmEditor; }
    }

    bool FindNext(string textToFind, bool advanceIfStarted, bool giveFeedback)
    {
      IDocument document = Editor.Document;
      ITextBufferStrategy textBuffer = document.TextBufferStrategy;

      bool firstSearch = searchStart == -1;
      if(firstSearch)
      {
        if(radSelection.Checked) searchStart = Editor.ActiveTextAreaControl.TextArea.SelectionManager.Selections[0].Offset;
        else searchStart = Editor.ActiveTextAreaControl.TextArea.Caret.Offset;
        searchPosition = searchStart;
      }
      else if(advanceIfStarted)
      {
        searchPosition++;
      }

      if(searchPosition >= textBuffer.Length) searchPosition = 0;
      if(searchStart >= textBuffer.Length) searchStart = 0;

      int searchEnd = searchStart;
      if(radSelection.Checked)
      {
        searchEnd = Editor.ActiveTextAreaControl.TextArea.SelectionManager.Selections[0].EndOffset;
        if(searchEnd == textBuffer.Length) searchEnd = 0;
      }

      while(true)
      {
        if(IsMatchAt(textBuffer, textToFind, searchPosition))
        {
          if(giveFeedback)
          {
            TextLocation position = document.OffsetToPosition(searchPosition);
            if(radDocument.Checked)
            {
              Editor.ActiveTextAreaControl.TextArea.SelectionManager.SetSelection(
                position, document.OffsetToPosition(searchPosition+textToFind.Length));
            }
            Editor.ActiveTextAreaControl.TextArea.Caret.Position = position;
          }
          return true;
        }

        if(++searchPosition == textBuffer.Length) searchPosition = 0;
        if(searchPosition == searchEnd)
        {
          if(giveFeedback)
          {
            if(firstSearch) MessageBox.Show("The specified text was not found.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else MessageBox.Show("The search is complete.", "Search complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          searchPosition = searchStart = -1;
          return false;
        }
      }
    }

    bool IsMatchAt(ITextBufferStrategy textBuffer, string textToFind, int offset)
    {
      int i;
      bool matchCase = chkMatchCase.Checked;
      for(i=0; i<textToFind.Length && offset<textBuffer.Length; i++, offset++)
      {
        char a = textToFind[i], b = textBuffer.GetCharAt(offset);
        if(!matchCase)
        {
          a = char.ToUpperInvariant(a);
          b = char.ToUpperInvariant(b);
        }
        if(a != b) return false;
      }
      return i == textToFind.Length;
    }

    void OnSelectionChanged(object sender, EventArgs e)
    {
      bool hasSelection = Editor.ActiveTextAreaControl.TextArea.SelectionManager.HasSomethingSelected;
      if(hasSelection != radSelection.Enabled)
      {
        radSelection.Enabled = hasSelection;
        if(!hasSelection) radDocument.Checked = true;
      }
    }

    void ReplaceAll(string textToFind, string replacement)
    {
      while(FindNext(textToFind, false, false))
      {
        Editor.Document.Replace(searchPosition, textToFind.Length, replacement);
        searchPosition += replacement.Length + 1;
      }
    }

    void btnDone_Click(object sender, EventArgs e)
    {
      Close();
    }

    void btnFind_Click(object sender, EventArgs e)
    {
      FindNext(FindText, true, true);
    }

    void btnReplace_Click(object sender, EventArgs e)
    {
      int currentPosition = searchPosition;
      if(FindNext(FindText, false, true) && searchPosition == currentPosition)
      {
        Editor.Document.Replace(searchPosition, txtFind.TextLength, ReplaceText);
        searchPosition += txtReplace.TextLength;
        FindNext(FindText, true, true);
      }
    }

    void btnReplaceAll_Click(object sender, EventArgs e)
    {
      Editor.Document.UndoStack.StartUndoGroup();
      ReplaceAll(FindText, ReplaceText);
      Editor.Document.UndoStack.EndUndoGroup();
    }

    void btnSwap_Click(object sender, EventArgs e)
    {
      Editor.Document.UndoStack.StartUndoGroup();
      string docText =
        radSelection.Checked ? Editor.ActiveTextAreaControl.TextArea.SelectionManager.SelectedText : Editor.Document.TextContent;
      string tempText = CreateSwapToken(docText, txtFind.TextLength);
      ReplaceAll(FindText, tempText);
      ReplaceAll(ReplaceText, FindText);
      ReplaceAll(tempText, ReplaceText);
      Editor.Document.UndoStack.EndUndoGroup();
    }

    void txtFind_TextChanged(object sender, EventArgs e)
    {
      btnFind.Enabled = btnReplace.Enabled = btnReplaceAll.Enabled = txtFind.TextLength != 0;
      btnSwap.Enabled = txtFind.TextLength != 0 && txtReplace.TextLength != 0;
      searchPosition = searchStart = -1;
    }

    void txtReplace_TextChanged(object sender, EventArgs e)
    {
      btnSwap.Enabled = txtFind.TextLength != 0 && txtReplace.TextLength != 0;
      searchPosition = searchStart = -1;
    }

    int searchPosition, searchStart;

    /// <summary>Creates a string not found within the given text, preferably of length <paramref name="length"/>.</summary>
    static string CreateSwapToken(string text, int length)
    {
      Random rand = new Random();
      char[] chars = new char[length];
      while(true)
      {
        for(int tries=0; tries<1000; tries++)
        {
          for(int i=0; i<chars.Length; i++) chars[i] = (char)rand.Next(32, 128);
          string token = new string(chars);
          if(text.IndexOf(token) == -1) return token;
        }
        chars = new char[chars.Length+1];
      }
    }
  }
}
