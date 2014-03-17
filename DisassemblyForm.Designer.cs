namespace ExePatch
{
  partial class DisassemblyForm
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.Button btnBrowse;
      System.Windows.Forms.Label lblStart;
      System.Windows.Forms.Label lblBits;
      System.Windows.Forms.Button btnCancel;
      System.Windows.Forms.Label lblLength;
      System.Windows.Forms.ToolTip toolTip;
      System.Windows.Forms.Label lblOrigin;
      System.Windows.Forms.Button btnSelectProcess;
      this.txtStart = new System.Windows.Forms.TextBox();
      this.cmbBits = new System.Windows.Forms.ComboBox();
      this.chkAutosync = new System.Windows.Forms.CheckBox();
      this.txtLength = new System.Windows.Forms.TextBox();
      this.txtOrigin = new System.Windows.Forms.TextBox();
      this.chkLabelAll = new System.Windows.Forms.CheckBox();
      this.radFile = new System.Windows.Forms.RadioButton();
      this.txtFile = new System.Windows.Forms.TextBox();
      this.radClipboard = new System.Windows.Forms.RadioButton();
      this.btnDisassemble = new System.Windows.Forms.Button();
      this.radProcess = new System.Windows.Forms.RadioButton();
      this.lblProcess = new System.Windows.Forms.Label();
      this.chkAppend = new System.Windows.Forms.CheckBox();
      btnBrowse = new System.Windows.Forms.Button();
      lblStart = new System.Windows.Forms.Label();
      lblBits = new System.Windows.Forms.Label();
      btnCancel = new System.Windows.Forms.Button();
      lblLength = new System.Windows.Forms.Label();
      toolTip = new System.Windows.Forms.ToolTip(this.components);
      lblOrigin = new System.Windows.Forms.Label();
      btnSelectProcess = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnBrowse
      // 
      btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      btnBrowse.Location = new System.Drawing.Point(454, 8);
      btnBrowse.Name = "btnBrowse";
      btnBrowse.Size = new System.Drawing.Size(75, 23);
      btnBrowse.TabIndex = 2;
      btnBrowse.Text = "B&rowse";
      btnBrowse.UseVisualStyleBackColor = true;
      btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
      // 
      // lblStart
      // 
      lblStart.AutoSize = true;
      lblStart.Location = new System.Drawing.Point(7, 103);
      lblStart.Name = "lblStart";
      lblStart.Size = new System.Drawing.Size(87, 13);
      lblStart.TabIndex = 7;
      lblStart.Text = "&Start offset (hex):";
      // 
      // lblBits
      // 
      lblBits.AutoSize = true;
      lblBits.Location = new System.Drawing.Point(185, 129);
      lblBits.Name = "lblBits";
      lblBits.Size = new System.Drawing.Size(61, 13);
      lblBits.TabIndex = 13;
      lblBits.Text = "CPU &mode:";
      // 
      // btnCancel
      // 
      btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      btnCancel.Location = new System.Drawing.Point(454, 66);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new System.Drawing.Size(75, 23);
      btnCancel.TabIndex = 19;
      btnCancel.Text = "Cancel";
      btnCancel.UseVisualStyleBackColor = true;
      // 
      // lblLength
      // 
      lblLength.AutoSize = true;
      lblLength.Location = new System.Drawing.Point(177, 103);
      lblLength.Name = "lblLength";
      lblLength.Size = new System.Drawing.Size(69, 13);
      lblLength.TabIndex = 9;
      lblLength.Text = "&Length (hex):";
      // 
      // txtStart
      // 
      this.txtStart.Location = new System.Drawing.Point(100, 100);
      this.txtStart.Name = "txtStart";
      this.txtStart.Size = new System.Drawing.Size(71, 20);
      this.txtStart.TabIndex = 8;
      toolTip.SetToolTip(this.txtStart, "The offset into the data where disassembly will start. If blank, the starting off" +
        "set will be determined automatically. (Currently that means it will be zero.)");
      // 
      // cmbBits
      // 
      this.cmbBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbBits.Items.AddRange(new object[] {
            "16-bit",
            "32-bit",
            "64-bit"});
      this.cmbBits.Location = new System.Drawing.Point(252, 126);
      this.cmbBits.Name = "cmbBits";
      this.cmbBits.Size = new System.Drawing.Size(71, 21);
      this.cmbBits.TabIndex = 14;
      toolTip.SetToolTip(this.cmbBits, "The native integer size of the CPU mode used to assemble the code. If incorrect, " +
        "the code may not disassemble correctly.");
      // 
      // chkAutosync
      // 
      this.chkAutosync.AutoSize = true;
      this.chkAutosync.Checked = true;
      this.chkAutosync.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkAutosync.Location = new System.Drawing.Point(10, 156);
      this.chkAutosync.Name = "chkAutosync";
      this.chkAutosync.Size = new System.Drawing.Size(108, 17);
      this.chkAutosync.TabIndex = 15;
      this.chkAutosync.Text = "Attempt &autosync";
      toolTip.SetToolTip(this.chkAutosync, "Attempt to resync if illegal instructions (or data embedded in the code) are foun" +
        "d.");
      this.chkAutosync.UseVisualStyleBackColor = true;
      // 
      // txtLength
      // 
      this.txtLength.Location = new System.Drawing.Point(252, 100);
      this.txtLength.Name = "txtLength";
      this.txtLength.Size = new System.Drawing.Size(71, 20);
      this.txtLength.TabIndex = 10;
      toolTip.SetToolTip(this.txtLength, "The number of bytes to disassemble. If zero or empty, the data will be disassembl" +
        "ed until the end.");
      // 
      // txtOrigin
      // 
      this.txtOrigin.Location = new System.Drawing.Point(100, 126);
      this.txtOrigin.Name = "txtOrigin";
      this.txtOrigin.Size = new System.Drawing.Size(71, 20);
      this.txtOrigin.TabIndex = 12;
      toolTip.SetToolTip(this.txtOrigin, "The starting address in memory where the program fragment is assumed to be loaded" +
        ". If blank, the origin will be determined automatically. (Currently that means i" +
        "t will be zero.)");
      // 
      // chkLabelAll
      // 
      this.chkLabelAll.AutoSize = true;
      this.chkLabelAll.Location = new System.Drawing.Point(293, 157);
      this.chkLabelAll.Name = "chkLabelAll";
      this.chkLabelAll.Size = new System.Drawing.Size(100, 17);
      this.chkLabelAll.TabIndex = 17;
      this.chkLabelAll.Text = "La&bel every line";
      toolTip.SetToolTip(this.chkLabelAll, "If checked, a label will be added to every line , rather than just the lines that" +
        " are jump targets.");
      this.chkLabelAll.UseVisualStyleBackColor = true;
      // 
      // lblOrigin
      // 
      lblOrigin.AutoSize = true;
      lblOrigin.Location = new System.Drawing.Point(7, 129);
      lblOrigin.Name = "lblOrigin";
      lblOrigin.Size = new System.Drawing.Size(63, 13);
      lblOrigin.TabIndex = 11;
      lblOrigin.Text = "&Origin (hex):";
      // 
      // btnSelectProcess
      // 
      btnSelectProcess.Location = new System.Drawing.Point(104, 60);
      btnSelectProcess.Name = "btnSelectProcess";
      btnSelectProcess.Size = new System.Drawing.Size(95, 23);
      btnSelectProcess.TabIndex = 5;
      btnSelectProcess.Text = "Select &Process";
      btnSelectProcess.UseVisualStyleBackColor = true;
      btnSelectProcess.Click += new System.EventHandler(this.btnSelectProcess_Click);
      // 
      // radFile
      // 
      this.radFile.AutoSize = true;
      this.radFile.Checked = true;
      this.radFile.Location = new System.Drawing.Point(9, 11);
      this.radFile.Name = "radFile";
      this.radFile.Size = new System.Drawing.Size(67, 17);
      this.radFile.TabIndex = 0;
      this.radFile.TabStop = true;
      this.radFile.Text = "From &file:";
      this.radFile.UseVisualStyleBackColor = true;
      this.radFile.CheckedChanged += new System.EventHandler(this.radFile_CheckedChanged);
      // 
      // txtFile
      // 
      this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtFile.Location = new System.Drawing.Point(83, 9);
      this.txtFile.Name = "txtFile";
      this.txtFile.Size = new System.Drawing.Size(364, 20);
      this.txtFile.TabIndex = 1;
      this.txtFile.TextChanged += new System.EventHandler(this.txtFile_TextChanged);
      // 
      // radClipboard
      // 
      this.radClipboard.AutoSize = true;
      this.radClipboard.Location = new System.Drawing.Point(9, 37);
      this.radClipboard.Name = "radClipboard";
      this.radClipboard.Size = new System.Drawing.Size(205, 17);
      this.radClipboard.TabIndex = 3;
      this.radClipboard.TabStop = true;
      this.radClipboard.Text = "From &clipboard (in hexadecimal format)";
      this.radClipboard.UseVisualStyleBackColor = true;
      // 
      // btnDisassemble
      // 
      this.btnDisassemble.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDisassemble.Enabled = false;
      this.btnDisassemble.Location = new System.Drawing.Point(454, 37);
      this.btnDisassemble.Name = "btnDisassemble";
      this.btnDisassemble.Size = new System.Drawing.Size(75, 23);
      this.btnDisassemble.TabIndex = 18;
      this.btnDisassemble.Text = "&Disassemble";
      this.btnDisassemble.UseVisualStyleBackColor = true;
      this.btnDisassemble.Click += new System.EventHandler(this.btnDisassemble_Click);
      // 
      // radProcess
      // 
      this.radProcess.AutoSize = true;
      this.radProcess.Location = new System.Drawing.Point(9, 63);
      this.radProcess.Name = "radProcess";
      this.radProcess.Size = new System.Drawing.Size(88, 17);
      this.radProcess.TabIndex = 4;
      this.radProcess.TabStop = true;
      this.radProcess.Text = "From process";
      this.radProcess.UseVisualStyleBackColor = true;
      this.radProcess.CheckedChanged += new System.EventHandler(this.radProcess_CheckedChanged);
      // 
      // lblProcess
      // 
      this.lblProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblProcess.Location = new System.Drawing.Point(205, 60);
      this.lblProcess.Name = "lblProcess";
      this.lblProcess.Size = new System.Drawing.Size(238, 23);
      this.lblProcess.TabIndex = 6;
      this.lblProcess.Text = "No process selected.";
      this.lblProcess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // chkAppend
      // 
      this.chkAppend.AutoSize = true;
      this.chkAppend.Location = new System.Drawing.Point(124, 156);
      this.chkAppend.Name = "chkAppend";
      this.chkAppend.Size = new System.Drawing.Size(163, 17);
      this.chkAppend.TabIndex = 16;
      this.chkAppend.Text = "App&end disassembly to listing";
      this.chkAppend.UseVisualStyleBackColor = true;
      // 
      // DisassemblyForm
      // 
      this.AcceptButton = this.btnDisassemble;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = btnCancel;
      this.ClientSize = new System.Drawing.Size(536, 180);
      this.Controls.Add(this.chkLabelAll);
      this.Controls.Add(this.chkAppend);
      this.Controls.Add(this.lblProcess);
      this.Controls.Add(btnSelectProcess);
      this.Controls.Add(this.radProcess);
      this.Controls.Add(this.txtOrigin);
      this.Controls.Add(lblOrigin);
      this.Controls.Add(this.txtLength);
      this.Controls.Add(lblLength);
      this.Controls.Add(btnCancel);
      this.Controls.Add(this.btnDisassemble);
      this.Controls.Add(this.chkAutosync);
      this.Controls.Add(this.cmbBits);
      this.Controls.Add(lblBits);
      this.Controls.Add(this.txtStart);
      this.Controls.Add(lblStart);
      this.Controls.Add(this.radClipboard);
      this.Controls.Add(btnBrowse);
      this.Controls.Add(this.txtFile);
      this.Controls.Add(this.radFile);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DisassemblyForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Disassemble Raw Binary";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RadioButton radFile;
    private System.Windows.Forms.TextBox txtFile;
    private System.Windows.Forms.RadioButton radClipboard;
    private System.Windows.Forms.TextBox txtStart;
    private System.Windows.Forms.ComboBox cmbBits;
    private System.Windows.Forms.CheckBox chkAutosync;
    private System.Windows.Forms.Button btnDisassemble;
    private System.Windows.Forms.TextBox txtLength;
    private System.Windows.Forms.TextBox txtOrigin;
    private System.Windows.Forms.RadioButton radProcess;
    private System.Windows.Forms.Label lblProcess;
    private System.Windows.Forms.CheckBox chkAppend;
    private System.Windows.Forms.CheckBox chkLabelAll;

  }
}