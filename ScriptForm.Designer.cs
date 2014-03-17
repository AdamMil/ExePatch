namespace ExePatch
{
  partial class ScriptForm
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
      System.Windows.Forms.Label lblAddress;
      this.txtAddress = new System.Windows.Forms.TextBox();
      this.btnCopyScript = new System.Windows.Forms.Button();
      lblAddress = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // lblAddress
      // 
      lblAddress.AutoSize = true;
      lblAddress.Location = new System.Drawing.Point(8, 11);
      lblAddress.Name = "lblAddress";
      lblAddress.Size = new System.Drawing.Size(99, 13);
      lblAddress.TabIndex = 0;
      lblAddress.Text = "Start Address (hex):";
      // 
      // txtAddress
      // 
      this.txtAddress.Location = new System.Drawing.Point(108, 8);
      this.txtAddress.MaxLength = 8;
      this.txtAddress.Name = "txtAddress";
      this.txtAddress.Size = new System.Drawing.Size(80, 20);
      this.txtAddress.TabIndex = 1;
      // 
      // btnCopyScript
      // 
      this.btnCopyScript.Location = new System.Drawing.Point(11, 34);
      this.btnCopyScript.Name = "btnCopyScript";
      this.btnCopyScript.Size = new System.Drawing.Size(176, 23);
      this.btnCopyScript.TabIndex = 2;
      this.btnCopyScript.Text = "&Copy Script to Clipboard";
      this.btnCopyScript.UseVisualStyleBackColor = true;
      this.btnCopyScript.Click += new System.EventHandler(this.btnCopyScript_Click);
      // 
      // ScriptForm
      // 
      this.AcceptButton = this.btnCopyScript;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(200, 65);
      this.Controls.Add(this.btnCopyScript);
      this.Controls.Add(this.txtAddress);
      this.Controls.Add(lblAddress);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ScriptForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Generate IDA Script";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtAddress;
    private System.Windows.Forms.Button btnCopyScript;
  }
}