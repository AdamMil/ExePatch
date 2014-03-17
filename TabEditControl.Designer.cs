namespace ExePatch
{
  partial class TabEditControl
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if(disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.splitContainer = new System.Windows.Forms.SplitContainer();
      this.txtAsm = new DigitalRune.Windows.TextEditor.TextEditorControl();
      this.txtHex = new DigitalRune.Windows.TextEditor.TextEditorControl();
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel2.SuspendLayout();
      this.splitContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer
      // 
      this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.splitContainer.Location = new System.Drawing.Point(0, 0);
      this.splitContainer.Name = "splitContainer";
      // 
      // splitContainer.Panel1
      // 
      this.splitContainer.Panel1.Controls.Add(this.txtAsm);
      // 
      // splitContainer.Panel2
      // 
      this.splitContainer.Panel2.Controls.Add(this.txtHex);
      this.splitContainer.Size = new System.Drawing.Size(1009, 630);
      this.splitContainer.SplitterDistance = 573;
      this.splitContainer.TabIndex = 3;
      // 
      // txtAsm
      // 
      this.txtAsm.ConvertTabsToSpaces = true;
      this.txtAsm.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtAsm.EnableCompletion = false;
      this.txtAsm.EnableFolding = false;
      this.txtAsm.EnableMethodInsight = false;
      this.txtAsm.Location = new System.Drawing.Point(0, 0);
      this.txtAsm.Name = "txtAsm";
      this.txtAsm.ShowMatchingBracket = false;
      this.txtAsm.ShowVRuler = false;
      this.txtAsm.Size = new System.Drawing.Size(573, 630);
      this.txtAsm.TabIndent = 2;
      this.txtAsm.TabIndex = 0;
      // 
      // txtHex
      // 
      this.txtHex.ConvertTabsToSpaces = true;
      this.txtHex.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtHex.EnableCompletion = false;
      this.txtHex.EnableFolding = false;
      this.txtHex.EnableMethodInsight = false;
      this.txtHex.IsReadOnly = true;
      this.txtHex.Location = new System.Drawing.Point(0, 0);
      this.txtHex.Name = "txtHex";
      this.txtHex.ShowMatchingBracket = false;
      this.txtHex.ShowVRuler = false;
      this.txtHex.Size = new System.Drawing.Size(432, 630);
      this.txtHex.TabIndent = 2;
      this.txtHex.TabIndex = 0;
      // 
      // TabEditControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitContainer);
      this.Name = "TabEditControl";
      this.Size = new System.Drawing.Size(1009, 630);
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.Panel2.ResumeLayout(false);
      this.splitContainer.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DigitalRune.Windows.TextEditor.TextEditorControl txtHex;
    private DigitalRune.Windows.TextEditor.TextEditorControl txtAsm;
    private System.Windows.Forms.SplitContainer splitContainer;
  }
}
