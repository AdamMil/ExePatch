using System;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace ExePatch
{
  partial class AboutForm : Form
  {
    public AboutForm()
    {
      InitializeComponent();
    }

    protected override void OnLoad(System.EventArgs e)
    {
      base.OnLoad(e);

      Assembly assembly = Assembly.GetExecutingAssembly();
      Version version = assembly.GetName().Version;
      lblProgram.Text += version.Major.ToString(CultureInfo.InvariantCulture) + "." + version.Minor.ToString(CultureInfo.InvariantCulture);

      pictureBox.Image = Bitmap.FromStream(assembly.GetManifestResourceStream("ExePatch.About.png"));
    }

    void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
    }
  }
}
