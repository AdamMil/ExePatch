using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using AdamMil.Utilities;

namespace ExePatch
{
  public partial class ScriptForm : Form
  {
    public ScriptForm()
    {
      InitializeComponent();
    }

    public ScriptForm(uint baseAddress, uint address, byte[] binary) : this()
    {
      this.baseAddress = baseAddress;
      txtAddress.Text  = address.ToString("X");
      binaryData       = binary;
    }

    public ScriptForm(uint baseAddress, string asm) : this()
    {
      txtAddress.Enabled = false;
      txtAddress.Text    = "Auto";
      this.baseAddress   = baseAddress;
      this.asm           = asm;
    }

    public uint Address
    {
      get { return uint.Parse(txtAddress.Text, NumberStyles.HexNumber); }
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      base.OnKeyDown(e);
      if(!e.Handled && e.KeyCode == Keys.Escape && e.Modifiers == Keys.None) Close();
    }

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);
      btnCopyScript.Focus();
      CenterToParent();
    }

    string MultiScript()
    {
      string error;
      int failedChunk;
      Program.Chunk[] chunks = Program.AssembleChunks(asm, baseAddress, out failedChunk, out error);
      if(chunks == null)
      {
        MessageBox.Show("Failed to assemble chunk " + failedChunk.ToString() + ": " + error, "Assembly failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        return null;
      }
      else
      {
        StringBuilder sb = new StringBuilder();
        foreach(Program.Chunk chunk in chunks) Script(sb, chunk.MemoryAddress, chunk.Code);
        return sb.ToString();
      }
    }

    string Script()
    {
      uint address;
      if(!uint.TryParse(txtAddress.Text, NumberStyles.HexNumber, null, out address))
      {
        MessageBox.Show("Invalid address. Enter a 32-bit hex number.", "Invalid address", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return null;
      }
      else
      {
        StringBuilder sb = new StringBuilder();
        Script(sb, address, binaryData);
        return sb.ToString();
      }
    }

    void btnCopyScript_Click(object sender, EventArgs e)
    {
      try
      {
        string script = txtAddress.Enabled ? Script() : MultiScript();
        if(script != null)
        {
          Clipboard.SetText(script);
          DialogResult = DialogResult.OK;
          Close();
        }
      }
      catch(Exception ex)
      {
        Program.ShowErrorMessage(ex);
      }
    }

    readonly string asm;
    readonly byte[] binaryData;
    readonly uint baseAddress = 0x400000;

    static void Script(StringBuilder sb, uint address, byte[] code)
    {
      if(code.Length != 0)
      {
        sb.Append("for i, c in enumerate('");
        foreach(byte b in code) sb.Append("\\x").Append(BinaryUtility.ToHex(b));
        sb.AppendLine("'):").Append("  idc.PatchByte(0x").Append(address.ToString("X")).AppendLine("+i, ord(c));");
      }
    }
  }
}
