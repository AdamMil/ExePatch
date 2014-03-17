using System;
using System.Globalization;
using System.Windows.Forms;

namespace ExePatch
{
  public partial class BaseAddressForm : Form
  {
    public BaseAddressForm()
    {
      InitializeComponent();
    }

    public BaseAddressForm(uint baseAddress) : this()
    {
      txtOffset.Text = baseAddress.ToString("X");
    }

    public uint Offset
    {
      get { return uint.Parse(txtOffset.Text, NumberStyles.HexNumber); }
    }

    void btnOK_Click(object sender, EventArgs e)
    {
      uint offset;
      if(!uint.TryParse(txtOffset.Text, NumberStyles.HexNumber, null, out offset))
      {
        MessageBox.Show("Invalid offset. Enter a 32-bit hex number.", "Invalid offset", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
      {
        DialogResult = DialogResult.OK;
        Close();
      }
    }
  }
}
