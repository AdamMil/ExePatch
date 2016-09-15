namespace ExePatch
{
  partial class AboutForm
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.Label lblBy;
      System.Windows.Forms.LinkLabel link;
      System.Windows.Forms.Button btnOK;
      this.pictureBox = new System.Windows.Forms.PictureBox();
      this.lblProgram = new System.Windows.Forms.Label();
      lblBy = new System.Windows.Forms.Label();
      link = new System.Windows.Forms.LinkLabel();
      btnOK = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // lblBy
      // 
      lblBy.AutoSize = true;
      lblBy.Location = new System.Drawing.Point(149, 38);
      lblBy.Name = "lblBy";
      lblBy.Size = new System.Drawing.Size(144, 13);
      lblBy.TabIndex = 1;
      lblBy.Text = "By Adam Milazzo, 2014-2016";
      // 
      // link
      // 
      link.AutoSize = true;
      link.Location = new System.Drawing.Point(150, 55);
      link.Name = "link";
      link.Size = new System.Drawing.Size(249, 13);
      link.TabIndex = 3;
      link.TabStop = true;
      link.Text = "http://www.adammil.net/blog/v122_ExePatch.html";
      link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
      // 
      // btnOK
      // 
      btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      btnOK.Location = new System.Drawing.Point(226, 119);
      btnOK.Name = "btnOK";
      btnOK.Size = new System.Drawing.Size(75, 23);
      btnOK.TabIndex = 2;
      btnOK.Text = "&OK";
      btnOK.UseVisualStyleBackColor = true;
      // 
      // pictureBox
      // 
      this.pictureBox.Location = new System.Drawing.Point(12, 12);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new System.Drawing.Size(130, 130);
      this.pictureBox.TabIndex = 0;
      this.pictureBox.TabStop = false;
      // 
      // lblProgram
      // 
      this.lblProgram.AutoSize = true;
      this.lblProgram.Location = new System.Drawing.Point(149, 21);
      this.lblProgram.Name = "lblProgram";
      this.lblProgram.Size = new System.Drawing.Size(93, 13);
      this.lblProgram.TabIndex = 0;
      this.lblProgram.Text = "ExePatch version ";
      // 
      // AboutForm
      // 
      this.AcceptButton = btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = btnOK;
      this.ClientSize = new System.Drawing.Size(420, 154);
      this.Controls.Add(btnOK);
      this.Controls.Add(link);
      this.Controls.Add(lblBy);
      this.Controls.Add(this.lblProgram);
      this.Controls.Add(this.pictureBox);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AboutForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "About ExePatch";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.Label lblProgram;
  }
}