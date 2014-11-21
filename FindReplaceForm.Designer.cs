namespace ExePatch
{
  partial class FindReplaceForm
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
      System.Windows.Forms.Label lblFind;
      System.Windows.Forms.Label lblReplace;
      System.Windows.Forms.Button btnDone;
      this.txtFind = new System.Windows.Forms.TextBox();
      this.txtReplace = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.radDocument = new System.Windows.Forms.RadioButton();
      this.radSelection = new System.Windows.Forms.RadioButton();
      this.chkMatchCase = new System.Windows.Forms.CheckBox();
      this.btnFind = new System.Windows.Forms.Button();
      this.btnReplace = new System.Windows.Forms.Button();
      this.btnReplaceAll = new System.Windows.Forms.Button();
      this.btnSwap = new System.Windows.Forms.Button();
      lblFind = new System.Windows.Forms.Label();
      lblReplace = new System.Windows.Forms.Label();
      btnDone = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblFind
      // 
      lblFind.AutoSize = true;
      lblFind.Location = new System.Drawing.Point(9, 10);
      lblFind.Name = "lblFind";
      lblFind.Size = new System.Drawing.Size(56, 13);
      lblFind.TabIndex = 0;
      lblFind.Text = "Fi&nd what:";
      // 
      // lblReplace
      // 
      lblReplace.AutoSize = true;
      lblReplace.Location = new System.Drawing.Point(9, 36);
      lblReplace.Name = "lblReplace";
      lblReplace.Size = new System.Drawing.Size(72, 13);
      lblReplace.TabIndex = 2;
      lblReplace.Text = "R&eplace with:";
      // 
      // btnDone
      // 
      btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      btnDone.DialogResult = System.Windows.Forms.DialogResult.OK;
      btnDone.Location = new System.Drawing.Point(316, 84);
      btnDone.Name = "btnDone";
      btnDone.Size = new System.Drawing.Size(58, 23);
      btnDone.TabIndex = 11;
      btnDone.Text = "Done";
      btnDone.UseVisualStyleBackColor = true;
      btnDone.Click += new System.EventHandler(this.btnDone_Click);
      // 
      // txtFind
      // 
      this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtFind.Location = new System.Drawing.Point(87, 7);
      this.txtFind.Name = "txtFind";
      this.txtFind.Size = new System.Drawing.Size(286, 20);
      this.txtFind.TabIndex = 1;
      this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
      this.txtFind.Enter += new System.EventHandler(this.txt_Enter);
      // 
      // txtReplace
      // 
      this.txtReplace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtReplace.Location = new System.Drawing.Point(87, 33);
      this.txtReplace.Name = "txtReplace";
      this.txtReplace.Size = new System.Drawing.Size(286, 20);
      this.txtReplace.TabIndex = 3;
      this.txtReplace.TextChanged += new System.EventHandler(this.txtReplace_TextChanged);
      this.txtReplace.Enter += new System.EventHandler(this.txt_Enter);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 61);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(42, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Where:";
      // 
      // radDocument
      // 
      this.radDocument.AutoSize = true;
      this.radDocument.Location = new System.Drawing.Point(87, 59);
      this.radDocument.Name = "radDocument";
      this.radDocument.Size = new System.Drawing.Size(74, 17);
      this.radDocument.TabIndex = 5;
      this.radDocument.TabStop = true;
      this.radDocument.Text = "&Document";
      this.radDocument.UseVisualStyleBackColor = true;
      // 
      // radSelection
      // 
      this.radSelection.AutoSize = true;
      this.radSelection.Location = new System.Drawing.Point(167, 59);
      this.radSelection.Name = "radSelection";
      this.radSelection.Size = new System.Drawing.Size(69, 17);
      this.radSelection.TabIndex = 6;
      this.radSelection.TabStop = true;
      this.radSelection.Text = "&Selection";
      this.radSelection.UseVisualStyleBackColor = true;
      // 
      // chkMatchCase
      // 
      this.chkMatchCase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.chkMatchCase.AutoSize = true;
      this.chkMatchCase.Location = new System.Drawing.Point(293, 59);
      this.chkMatchCase.Name = "chkMatchCase";
      this.chkMatchCase.Size = new System.Drawing.Size(82, 17);
      this.chkMatchCase.TabIndex = 7;
      this.chkMatchCase.Text = "Match &case";
      this.chkMatchCase.UseVisualStyleBackColor = true;
      // 
      // btnFind
      // 
      this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnFind.Enabled = false;
      this.btnFind.Location = new System.Drawing.Point(12, 84);
      this.btnFind.Name = "btnFind";
      this.btnFind.Size = new System.Drawing.Size(58, 23);
      this.btnFind.TabIndex = 8;
      this.btnFind.Text = "&Find";
      this.btnFind.UseVisualStyleBackColor = true;
      this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
      // 
      // btnReplace
      // 
      this.btnReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnReplace.Enabled = false;
      this.btnReplace.Location = new System.Drawing.Point(82, 84);
      this.btnReplace.Name = "btnReplace";
      this.btnReplace.Size = new System.Drawing.Size(75, 23);
      this.btnReplace.TabIndex = 9;
      this.btnReplace.Text = "&Replace";
      this.btnReplace.UseVisualStyleBackColor = true;
      this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
      // 
      // btnReplaceAll
      // 
      this.btnReplaceAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnReplaceAll.Enabled = false;
      this.btnReplaceAll.Location = new System.Drawing.Point(163, 84);
      this.btnReplaceAll.Name = "btnReplaceAll";
      this.btnReplaceAll.Size = new System.Drawing.Size(75, 23);
      this.btnReplaceAll.TabIndex = 10;
      this.btnReplaceAll.Text = "Replace &All";
      this.btnReplaceAll.UseVisualStyleBackColor = true;
      this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
      // 
      // btnSwap
      // 
      this.btnSwap.Location = new System.Drawing.Point(244, 84);
      this.btnSwap.Name = "btnSwap";
      this.btnSwap.Size = new System.Drawing.Size(58, 23);
      this.btnSwap.TabIndex = 12;
      this.btnSwap.Text = "S&wap";
      this.btnSwap.UseVisualStyleBackColor = true;
      this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
      // 
      // FindReplaceForm
      // 
      this.AcceptButton = this.btnFind;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = btnDone;
      this.ClientSize = new System.Drawing.Size(385, 115);
      this.Controls.Add(this.btnSwap);
      this.Controls.Add(this.btnReplaceAll);
      this.Controls.Add(btnDone);
      this.Controls.Add(this.btnReplace);
      this.Controls.Add(this.btnFind);
      this.Controls.Add(this.chkMatchCase);
      this.Controls.Add(this.radSelection);
      this.Controls.Add(this.radDocument);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtReplace);
      this.Controls.Add(lblReplace);
      this.Controls.Add(this.txtFind);
      this.Controls.Add(lblFind);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FindReplaceForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Find and Replace";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtFind;
    private System.Windows.Forms.TextBox txtReplace;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.RadioButton radDocument;
    private System.Windows.Forms.RadioButton radSelection;
    private System.Windows.Forms.CheckBox chkMatchCase;
    private System.Windows.Forms.Button btnFind;
    private System.Windows.Forms.Button btnReplace;
    private System.Windows.Forms.Button btnReplaceAll;
    private System.Windows.Forms.Button btnSwap;

  }
}