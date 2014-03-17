namespace ExePatch
{
  partial class ProcessForm
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
      System.Windows.Forms.Button btnCancel;
      System.Windows.Forms.Button btnRefresh;
      this.btnSelect = new System.Windows.Forms.Button();
      this.list = new System.Windows.Forms.ListBox();
      btnCancel = new System.Windows.Forms.Button();
      btnRefresh = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnSelect
      // 
      this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnSelect.Enabled = false;
      this.btnSelect.Location = new System.Drawing.Point(9, 305);
      this.btnSelect.Name = "btnSelect";
      this.btnSelect.Size = new System.Drawing.Size(75, 23);
      this.btnSelect.TabIndex = 1;
      this.btnSelect.Text = "&Select";
      this.btnSelect.UseVisualStyleBackColor = true;
      this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
      // 
      // btnCancel
      // 
      btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      btnCancel.Location = new System.Drawing.Point(171, 305);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new System.Drawing.Size(75, 23);
      btnCancel.TabIndex = 3;
      btnCancel.Text = "&Cancel";
      btnCancel.UseVisualStyleBackColor = true;
      btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnRefresh
      // 
      btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      btnRefresh.Location = new System.Drawing.Point(90, 305);
      btnRefresh.Name = "btnRefresh";
      btnRefresh.Size = new System.Drawing.Size(75, 23);
      btnRefresh.TabIndex = 2;
      btnRefresh.Text = "&Refresh";
      btnRefresh.UseVisualStyleBackColor = true;
      btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
      // 
      // list
      // 
      this.list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.list.FormattingEnabled = true;
      this.list.Location = new System.Drawing.Point(9, 9);
      this.list.Name = "list";
      this.list.Size = new System.Drawing.Size(237, 290);
      this.list.TabIndex = 0;
      this.list.SelectedIndexChanged += new System.EventHandler(this.list_SelectedIndexChanged);
      this.list.DoubleClick += new System.EventHandler(this.list_DoubleClick);
      // 
      // ProcessForm
      // 
      this.AcceptButton = this.btnSelect;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = btnCancel;
      this.ClientSize = new System.Drawing.Size(255, 334);
      this.Controls.Add(btnRefresh);
      this.Controls.Add(btnCancel);
      this.Controls.Add(this.btnSelect);
      this.Controls.Add(this.list);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ProcessForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Select Process";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListBox list;
    private System.Windows.Forms.Button btnSelect;
  }
}