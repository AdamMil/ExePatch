namespace ExePatch
{
  partial class BaseAddressForm
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
      System.Windows.Forms.Label lblSet;
      System.Windows.Forms.Label lblHex;
      System.Windows.Forms.Button btnOK;
      System.Windows.Forms.Button btnCancel;
      this.txtOffset = new System.Windows.Forms.TextBox();
      lblSet = new System.Windows.Forms.Label();
      lblHex = new System.Windows.Forms.Label();
      btnOK = new System.Windows.Forms.Button();
      btnCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblSet
      // 
      lblSet.AutoSize = true;
      lblSet.Location = new System.Drawing.Point(9, 9);
      lblSet.Name = "lblSet";
      lblSet.Size = new System.Drawing.Size(187, 26);
      lblSet.TabIndex = 0;
      lblSet.Text = "Enter the &offset between code in the\r\n file and in memory (the base address):";
      // 
      // txtOffset
      // 
      this.txtOffset.Location = new System.Drawing.Point(48, 42);
      this.txtOffset.Name = "txtOffset";
      this.txtOffset.Size = new System.Drawing.Size(75, 20);
      this.txtOffset.TabIndex = 1;
      this.txtOffset.Text = "400000";
      // 
      // lblHex
      // 
      lblHex.AutoSize = true;
      lblHex.Location = new System.Drawing.Point(125, 44);
      lblHex.Name = "lblHex";
      lblHex.Size = new System.Drawing.Size(30, 13);
      lblHex.TabIndex = 2;
      lblHex.Text = "(hex)";
      // 
      // btnOK
      // 
      btnOK.Location = new System.Drawing.Point(23, 68);
      btnOK.Name = "btnOK";
      btnOK.Size = new System.Drawing.Size(75, 23);
      btnOK.TabIndex = 3;
      btnOK.Text = "&OK";
      btnOK.UseVisualStyleBackColor = true;
      btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnCancel
      // 
      btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      btnCancel.Location = new System.Drawing.Point(104, 68);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new System.Drawing.Size(75, 23);
      btnCancel.TabIndex = 4;
      btnCancel.Text = "&Cancel";
      btnCancel.UseVisualStyleBackColor = true;
      // 
      // MemoryOffsetForm
      // 
      this.AcceptButton = btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = btnCancel;
      this.ClientSize = new System.Drawing.Size(203, 98);
      this.Controls.Add(btnCancel);
      this.Controls.Add(btnOK);
      this.Controls.Add(lblHex);
      this.Controls.Add(this.txtOffset);
      this.Controls.Add(lblSet);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MemoryOffsetForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Set File to Memory Offset";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtOffset;
  }
}