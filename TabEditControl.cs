using System;
using System.Windows.Forms;
using DigitalRune.Windows.TextEditor;
using DigitalRune.Windows.TextEditor.Document;

namespace ExePatch
{
  partial class TabEditControl : UserControl
  {
    public TabEditControl()
    {
      InitializeComponent();
      IsNewFile      = true;
      BaseAddress    = 0x400000;
      SuspendProcess = true;
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      txtAsm.SetHighlighting("Assembly");
    }

    public TextEditorControl AsmEditor
    {
      get { return txtAsm; }
    }

    public TextEditorControl HexViewer
    {
      get { return txtHex; }
    }

    public Chunk[] AssembledCode { get; set; }
    public uint BaseAddress { get; set; }
    public bool Changed { get; set; }
    public string FilePath { get; set; }
    public bool IsNewFile { get; set; }
    public string PatchFile { get; set; }
    public int PatchProcessId { get; set; }
    public int LastChangeTime { get; set; }
    public bool ParsedOrgLine { get; private set; }
    public bool SuspendProcess { get; set; }

    public int SplitDistance
    {
      get { return splitContainer.SplitterDistance; }
      set { splitContainer.SplitterDistance = value; }
    }

    public void Reset()
    {
      txtAsm.Text = "BITS 32\n\nORG 400000h\n";
      txtHex.Text = "";
      txtAsm.ActiveTextAreaControl.Caret.Position = new TextLocation(0, 2);
      LastChangeTime = 0;
      Changed = false;
      AssembledCode = new Chunk[0];
      FilePath = null;
      IsNewFile = true;
    }
  }
}
