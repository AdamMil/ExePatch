using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using AdamMil.Utilities;

namespace ExePatch
{
  partial class ScriptForm : Form
  {
    public ScriptForm()
    {
      InitializeComponent();
    }

    public ScriptForm(uint baseAddress, Chunk[] chunks) : this()
    {
      txtAddress.Enabled = chunks.Length == 1;
      txtAddress.Text    = chunks.Length == 1 ? chunks[0].MemoryAddress.ToString("X") : "Multiple";
      this.baseAddress = baseAddress;
      this.chunks      = chunks;
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

    string Script()
    {
      uint address = 0;
      if(chunks.Length == 1 && !uint.TryParse(txtAddress.Text, NumberStyles.HexNumber, null, out address))
      {
        MessageBox.Show("Invalid address. Enter a 32-bit hex number.", "Invalid address", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return null;
      }
      else
      {
        StringBuilder sb = new StringBuilder();
        if(chunks.Length == 1)
        {
          Script(sb, address, chunks[0].Code);
        }
        else
        {
          foreach(Chunk chunk in chunks) Script(sb, chunk.MemoryAddress, chunk.Code);
        }

        return sb.ToString();
      }
    }

    void btnCopyScript_Click(object sender, EventArgs e)
    {
      try
      {
        string script = Script();
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

    readonly Chunk[] chunks;
    readonly uint baseAddress;

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
