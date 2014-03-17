namespace ExePatch
{
  partial class PatchForm
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
      System.Windows.Forms.Label lblAddress;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatchForm));
      System.Windows.Forms.Button btnBrowseFile;
      System.Windows.Forms.Button btnCancel;
      System.Windows.Forms.Button btnBrowseProcess;
      System.Windows.Forms.ToolTip toolTip;
      this.txtOffset = new System.Windows.Forms.TextBox();
      this.chkSuspend = new System.Windows.Forms.CheckBox();
      this.txtFile = new System.Windows.Forms.TextBox();
      this.btnPatch = new System.Windows.Forms.Button();
      this.radFile = new System.Windows.Forms.RadioButton();
      this.radProcess = new System.Windows.Forms.RadioButton();
      this.lblProcess = new System.Windows.Forms.Label();
      lblAddress = new System.Windows.Forms.Label();
      btnBrowseFile = new System.Windows.Forms.Button();
      btnCancel = new System.Windows.Forms.Button();
      btnBrowseProcess = new System.Windows.Forms.Button();
      toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.SuspendLayout();
      // 
      // lblAddress
      // 
      resources.ApplyResources(lblAddress, "lblAddress");
      lblAddress.Name = "lblAddress";
      // 
      // btnBrowseFile
      // 
      resources.ApplyResources(btnBrowseFile, "btnBrowseFile");
      btnBrowseFile.Name = "btnBrowseFile";
      btnBrowseFile.UseVisualStyleBackColor = true;
      btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
      // 
      // btnCancel
      // 
      resources.ApplyResources(btnCancel, "btnCancel");
      btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      btnCancel.Name = "btnCancel";
      btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnBrowseProcess
      // 
      resources.ApplyResources(btnBrowseProcess, "btnBrowseProcess");
      btnBrowseProcess.Name = "btnBrowseProcess";
      btnBrowseProcess.UseVisualStyleBackColor = true;
      btnBrowseProcess.Click += new System.EventHandler(this.btnBrowseProcess_Click);
      // 
      // txtOffset
      // 
      resources.ApplyResources(this.txtOffset, "txtOffset");
      this.txtOffset.Name = "txtOffset";
      toolTip.SetToolTip(this.txtOffset, resources.GetString("txtOffset.ToolTip"));
      // 
      // chkSuspend
      // 
      resources.ApplyResources(this.chkSuspend, "chkSuspend");
      this.chkSuspend.Checked = true;
      this.chkSuspend.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkSuspend.Name = "chkSuspend";
      toolTip.SetToolTip(this.chkSuspend, resources.GetString("chkSuspend.ToolTip"));
      this.chkSuspend.UseVisualStyleBackColor = true;
      // 
      // txtFile
      // 
      resources.ApplyResources(this.txtFile, "txtFile");
      this.txtFile.Name = "txtFile";
      this.txtFile.TextChanged += new System.EventHandler(this.txtFile_TextChanged);
      // 
      // btnPatch
      // 
      resources.ApplyResources(this.btnPatch, "btnPatch");
      this.btnPatch.Name = "btnPatch";
      this.btnPatch.UseVisualStyleBackColor = true;
      this.btnPatch.Click += new System.EventHandler(this.btnPatch_Click);
      // 
      // radFile
      // 
      resources.ApplyResources(this.radFile, "radFile");
      this.radFile.Name = "radFile";
      this.radFile.TabStop = true;
      this.radFile.UseVisualStyleBackColor = true;
      // 
      // radProcess
      // 
      resources.ApplyResources(this.radProcess, "radProcess");
      this.radProcess.Name = "radProcess";
      this.radProcess.TabStop = true;
      this.radProcess.UseVisualStyleBackColor = true;
      this.radProcess.CheckedChanged += new System.EventHandler(this.radProcess_CheckedChanged);
      // 
      // lblProcess
      // 
      resources.ApplyResources(this.lblProcess, "lblProcess");
      this.lblProcess.Name = "lblProcess";
      // 
      // PatchForm
      // 
      this.AcceptButton = this.btnPatch;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = btnCancel;
      this.Controls.Add(this.chkSuspend);
      this.Controls.Add(this.lblProcess);
      this.Controls.Add(btnBrowseProcess);
      this.Controls.Add(this.radProcess);
      this.Controls.Add(this.radFile);
      this.Controls.Add(btnCancel);
      this.Controls.Add(this.btnPatch);
      this.Controls.Add(btnBrowseFile);
      this.Controls.Add(this.txtFile);
      this.Controls.Add(this.txtOffset);
      this.Controls.Add(lblAddress);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "PatchForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtOffset;
    private System.Windows.Forms.TextBox txtFile;
    private System.Windows.Forms.Button btnPatch;
    private System.Windows.Forms.RadioButton radFile;
    private System.Windows.Forms.RadioButton radProcess;
    private System.Windows.Forms.Label lblProcess;
    private System.Windows.Forms.CheckBox chkSuspend;
  }
}