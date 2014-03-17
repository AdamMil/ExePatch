namespace ExePatch
{
  partial class GoToLineForm
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
      System.Windows.Forms.Label lblLine;
      System.Windows.Forms.Button btnGo;
      this.txtLine = new System.Windows.Forms.TextBox();
      lblLine = new System.Windows.Forms.Label();
      btnGo = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblLine
      // 
      lblLine.AutoSize = true;
      lblLine.Location = new System.Drawing.Point(9, 14);
      lblLine.Name = "lblLine";
      lblLine.Size = new System.Drawing.Size(65, 13);
      lblLine.TabIndex = 0;
      lblLine.Text = "&Line number";
      // 
      // txtLine
      // 
      this.txtLine.Location = new System.Drawing.Point(80, 11);
      this.txtLine.Name = "txtLine";
      this.txtLine.Size = new System.Drawing.Size(100, 20);
      this.txtLine.TabIndex = 1;
      // 
      // btnGo
      // 
      btnGo.Location = new System.Drawing.Point(187, 9);
      btnGo.Name = "btnGo";
      btnGo.Size = new System.Drawing.Size(45, 23);
      btnGo.TabIndex = 2;
      btnGo.Text = "&Go";
      btnGo.UseVisualStyleBackColor = true;
      btnGo.Click += new System.EventHandler(this.btnGo_Click);
      // 
      // GoToLineForm
      // 
      this.AcceptButton = btnGo;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(244, 40);
      this.Controls.Add(btnGo);
      this.Controls.Add(this.txtLine);
      this.Controls.Add(lblLine);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "GoToLineForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Go to Line";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtLine;
  }
}