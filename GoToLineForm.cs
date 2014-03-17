using System;
using System.Windows.Forms;

namespace ExePatch
{
  public partial class GoToLineForm : Form
  {
    public GoToLineForm()
    {
      InitializeComponent();
    }

    public int Line
    {
      get { return int.Parse(txtLine.Text); }
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      base.OnKeyDown(e);
      if(!e.Handled && e.KeyCode == Keys.Escape && e.Modifiers == Keys.None) Close();
    }

    void btnGo_Click(object sender, EventArgs e)
    {
      int lineNumber;
      if(!int.TryParse(txtLine.Text, out lineNumber) || lineNumber < 0)
      {
        MessageBox.Show("Invalid line number.", "Invalid line number", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
      {
        DialogResult = DialogResult.OK;
        Close();
      }
    }
  }
}
