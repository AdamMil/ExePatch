namespace ExePatch
{
  partial class MainForm
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
      System.Windows.Forms.MenuStrip menuStrip;
      System.Windows.Forms.ToolStripMenuItem fileMenu;
      System.Windows.Forms.ToolStripMenuItem newMenuItem;
      System.Windows.Forms.ToolStripMenuItem openMenuItem;
      System.Windows.Forms.ToolStripMenuItem disassembleMenuItem;
      System.Windows.Forms.ToolStripSeparator menuSep1;
      System.Windows.Forms.ToolStripMenuItem saveMenuItem;
      System.Windows.Forms.ToolStripSeparator menuSep3;
      System.Windows.Forms.ToolStripMenuItem saveBinaryMenuItem;
      System.Windows.Forms.ToolStripSeparator menuSep2;
      System.Windows.Forms.ToolStripMenuItem exitMenuItem;
      System.Windows.Forms.ToolStripMenuItem editMenu;
      System.Windows.Forms.ToolStripMenuItem findMenuItem;
      System.Windows.Forms.ToolStripMenuItem findAndReplaceMenuItem;
      System.Windows.Forms.ToolStripSeparator menuSep4;
      System.Windows.Forms.ToolStripMenuItem goToLineMenuItem;
      System.Windows.Forms.ToolStripSeparator menuSep7;
      System.Windows.Forms.ToolStripMenuItem commentOutMenuItem;
      System.Windows.Forms.ToolStripMenuItem uncommentMenuItem;
      System.Windows.Forms.ToolStripMenuItem toggleCommentsMenuItem;
      System.Windows.Forms.ToolStripMenuItem toolsMenu;
      System.Windows.Forms.ToolStripMenuItem idaScriptMenuItem;
      System.Windows.Forms.ToolStripMenuItem patchMenuItem;
      System.Windows.Forms.ToolStripMenuItem helpMenu;
      System.Windows.Forms.ToolStripMenuItem assemblerSyntaxMenuItem;
      System.Windows.Forms.ToolStripMenuItem tutorialMenuItem;
      System.Windows.Forms.ToolStripSeparator menuSep8;
      System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
      System.Windows.Forms.StatusStrip statusStrip;
      System.Windows.Forms.ToolStripMenuItem closeMenuItem;
      System.Windows.Forms.ToolStripSeparator menuSep10;
      this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.findNextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblAssembly = new System.Windows.Forms.ToolStripStatusLabel();
      this.tabControl = new System.Windows.Forms.TabControl();
      menuStrip = new System.Windows.Forms.MenuStrip();
      fileMenu = new System.Windows.Forms.ToolStripMenuItem();
      newMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      disassembleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      menuSep1 = new System.Windows.Forms.ToolStripSeparator();
      saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      menuSep3 = new System.Windows.Forms.ToolStripSeparator();
      saveBinaryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      menuSep2 = new System.Windows.Forms.ToolStripSeparator();
      exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      editMenu = new System.Windows.Forms.ToolStripMenuItem();
      findMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      findAndReplaceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      menuSep4 = new System.Windows.Forms.ToolStripSeparator();
      goToLineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      menuSep7 = new System.Windows.Forms.ToolStripSeparator();
      commentOutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      uncommentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      toggleCommentsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
      idaScriptMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      patchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      helpMenu = new System.Windows.Forms.ToolStripMenuItem();
      assemblerSyntaxMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      tutorialMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      menuSep8 = new System.Windows.Forms.ToolStripSeparator();
      aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      statusStrip = new System.Windows.Forms.StatusStrip();
      closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      menuSep10 = new System.Windows.Forms.ToolStripSeparator();
      menuStrip.SuspendLayout();
      statusStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip
      // 
      menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            fileMenu,
            editMenu,
            toolsMenu,
            helpMenu});
      menuStrip.Location = new System.Drawing.Point(0, 0);
      menuStrip.Name = "menuStrip";
      menuStrip.Size = new System.Drawing.Size(1184, 24);
      menuStrip.TabIndex = 0;
      menuStrip.Text = "menuStrip1";
      // 
      // fileMenu
      // 
      fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            newMenuItem,
            openMenuItem,
            disassembleMenuItem,
            menuSep1,
            closeMenuItem,
            menuSep10,
            saveMenuItem,
            this.saveAsMenuItem,
            menuSep3,
            saveBinaryMenuItem,
            menuSep2,
            exitMenuItem});
      fileMenu.Name = "fileMenu";
      fileMenu.Size = new System.Drawing.Size(37, 20);
      fileMenu.Text = "&File";
      // 
      // newMenuItem
      // 
      newMenuItem.Name = "newMenuItem";
      newMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      newMenuItem.Size = new System.Drawing.Size(195, 22);
      newMenuItem.Text = "&New";
      newMenuItem.Click += new System.EventHandler(this.newMenuItem_Click);
      // 
      // openMenuItem
      // 
      openMenuItem.Name = "openMenuItem";
      openMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      openMenuItem.Size = new System.Drawing.Size(195, 22);
      openMenuItem.Text = "&Open...";
      openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
      // 
      // disassembleMenuItem
      // 
      disassembleMenuItem.Name = "disassembleMenuItem";
      disassembleMenuItem.Size = new System.Drawing.Size(195, 22);
      disassembleMenuItem.Text = "&Disassemble...";
      disassembleMenuItem.Click += new System.EventHandler(this.disassembleMenuItem_Click);
      // 
      // menuSep1
      // 
      menuSep1.Name = "menuSep1";
      menuSep1.Size = new System.Drawing.Size(192, 6);
      // 
      // saveMenuItem
      // 
      saveMenuItem.Name = "saveMenuItem";
      saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      saveMenuItem.Size = new System.Drawing.Size(195, 22);
      saveMenuItem.Text = "&Save";
      saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
      // 
      // saveAsMenuItem
      // 
      this.saveAsMenuItem.Name = "saveAsMenuItem";
      this.saveAsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
      this.saveAsMenuItem.Size = new System.Drawing.Size(195, 22);
      this.saveAsMenuItem.Text = "Save &As...";
      this.saveAsMenuItem.Click += new System.EventHandler(this.saveAsMenuItem_Click);
      // 
      // menuSep3
      // 
      menuSep3.Name = "menuSep3";
      menuSep3.Size = new System.Drawing.Size(192, 6);
      // 
      // saveBinaryMenuItem
      // 
      saveBinaryMenuItem.Name = "saveBinaryMenuItem";
      saveBinaryMenuItem.Size = new System.Drawing.Size(195, 22);
      saveBinaryMenuItem.Text = "Save &Binary...";
      saveBinaryMenuItem.Click += new System.EventHandler(this.saveBinaryMenuItem_Click);
      // 
      // menuSep2
      // 
      menuSep2.Name = "menuSep2";
      menuSep2.Size = new System.Drawing.Size(192, 6);
      // 
      // exitMenuItem
      // 
      exitMenuItem.Name = "exitMenuItem";
      exitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      exitMenuItem.Size = new System.Drawing.Size(195, 22);
      exitMenuItem.Text = "E&xit";
      exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
      // 
      // editMenu
      // 
      editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            findMenuItem,
            this.findNextMenuItem,
            findAndReplaceMenuItem,
            menuSep4,
            goToLineMenuItem,
            menuSep7,
            commentOutMenuItem,
            uncommentMenuItem,
            toggleCommentsMenuItem});
      editMenu.Name = "editMenu";
      editMenu.Size = new System.Drawing.Size(39, 20);
      editMenu.Text = "&Edit";
      // 
      // findMenuItem
      // 
      findMenuItem.Name = "findMenuItem";
      findMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
      findMenuItem.Size = new System.Drawing.Size(224, 22);
      findMenuItem.Text = "&Find...";
      findMenuItem.Click += new System.EventHandler(this.findMenuItem_Click);
      // 
      // findNextMenuItem
      // 
      this.findNextMenuItem.Name = "findNextMenuItem";
      this.findNextMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
      this.findNextMenuItem.Size = new System.Drawing.Size(224, 22);
      this.findNextMenuItem.Text = "Find &Next";
      this.findNextMenuItem.Click += new System.EventHandler(this.findNextMenuItem_Click);
      // 
      // findAndReplaceMenuItem
      // 
      findAndReplaceMenuItem.Name = "findAndReplaceMenuItem";
      findAndReplaceMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
      findAndReplaceMenuItem.Size = new System.Drawing.Size(224, 22);
      findAndReplaceMenuItem.Text = "Find and &Replace...";
      findAndReplaceMenuItem.Click += new System.EventHandler(this.findAndReplaceMenuItem_Click);
      // 
      // menuSep4
      // 
      menuSep4.Name = "menuSep4";
      menuSep4.Size = new System.Drawing.Size(221, 6);
      // 
      // goToLineMenuItem
      // 
      goToLineMenuItem.Name = "goToLineMenuItem";
      goToLineMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
      goToLineMenuItem.Size = new System.Drawing.Size(224, 22);
      goToLineMenuItem.Text = "&Go to Line...";
      goToLineMenuItem.Click += new System.EventHandler(this.goToLineMenuItem_Click);
      // 
      // menuSep7
      // 
      menuSep7.Name = "menuSep7";
      menuSep7.Size = new System.Drawing.Size(221, 6);
      // 
      // commentOutMenuItem
      // 
      commentOutMenuItem.Name = "commentOutMenuItem";
      commentOutMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.K)));
      commentOutMenuItem.Size = new System.Drawing.Size(224, 22);
      commentOutMenuItem.Text = "&Comment Out";
      commentOutMenuItem.Click += new System.EventHandler(this.commentOutMenuItem_Click);
      // 
      // uncommentMenuItem
      // 
      uncommentMenuItem.Name = "uncommentMenuItem";
      uncommentMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.K)));
      uncommentMenuItem.Size = new System.Drawing.Size(224, 22);
      uncommentMenuItem.Text = "&Uncomment";
      uncommentMenuItem.Click += new System.EventHandler(this.uncommentMenuItem_Click);
      // 
      // toggleCommentsMenuItem
      // 
      toggleCommentsMenuItem.Name = "toggleCommentsMenuItem";
      toggleCommentsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
      toggleCommentsMenuItem.Size = new System.Drawing.Size(224, 22);
      toggleCommentsMenuItem.Text = "&Toggle Comments";
      toggleCommentsMenuItem.Click += new System.EventHandler(this.toggleCommentsMenuItem_Click);
      // 
      // toolsMenu
      // 
      toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            idaScriptMenuItem,
            patchMenuItem});
      toolsMenu.Name = "toolsMenu";
      toolsMenu.Size = new System.Drawing.Size(48, 20);
      toolsMenu.Text = "&Tools";
      // 
      // idaScriptMenuItem
      // 
      idaScriptMenuItem.Name = "idaScriptMenuItem";
      idaScriptMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
      idaScriptMenuItem.Size = new System.Drawing.Size(282, 22);
      idaScriptMenuItem.Text = "Generate &IDAPython Script...";
      idaScriptMenuItem.Click += new System.EventHandler(this.idaScriptMenuItem_Click);
      // 
      // patchMenuItem
      // 
      patchMenuItem.Name = "patchMenuItem";
      patchMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
      patchMenuItem.Size = new System.Drawing.Size(282, 22);
      patchMenuItem.Text = "&Patch Executable...";
      patchMenuItem.Click += new System.EventHandler(this.patchMenuItem_Click);
      // 
      // helpMenu
      // 
      helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            assemblerSyntaxMenuItem,
            tutorialMenuItem,
            menuSep8,
            aboutMenuItem});
      helpMenu.Name = "helpMenu";
      helpMenu.Size = new System.Drawing.Size(44, 20);
      helpMenu.Text = "&Help";
      // 
      // assemblerSyntaxMenuItem
      // 
      assemblerSyntaxMenuItem.Name = "assemblerSyntaxMenuItem";
      assemblerSyntaxMenuItem.Size = new System.Drawing.Size(194, 22);
      assemblerSyntaxMenuItem.Text = "View Assembler &Syntax";
      assemblerSyntaxMenuItem.Click += new System.EventHandler(this.assemblerSyntaxMenuItem_Click);
      // 
      // tutorialMenuItem
      // 
      tutorialMenuItem.Name = "tutorialMenuItem";
      tutorialMenuItem.Size = new System.Drawing.Size(194, 22);
      tutorialMenuItem.Text = "View &Tutorial";
      tutorialMenuItem.Click += new System.EventHandler(this.tutorialMenuItem_Click);
      // 
      // menuSep8
      // 
      menuSep8.Name = "menuSep8";
      menuSep8.Size = new System.Drawing.Size(191, 6);
      // 
      // aboutMenuItem
      // 
      aboutMenuItem.Name = "aboutMenuItem";
      aboutMenuItem.Size = new System.Drawing.Size(194, 22);
      aboutMenuItem.Text = "&About ExePatch";
      aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
      // 
      // statusStrip
      // 
      statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblAssembly});
      statusStrip.Location = new System.Drawing.Point(0, 740);
      statusStrip.Name = "statusStrip";
      statusStrip.Size = new System.Drawing.Size(1184, 22);
      statusStrip.TabIndex = 2;
      statusStrip.Text = "statusStrip1";
      // 
      // lblStatus
      // 
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new System.Drawing.Size(1169, 17);
      this.lblStatus.Spring = true;
      this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblAssembly
      // 
      this.lblAssembly.Name = "lblAssembly";
      this.lblAssembly.Size = new System.Drawing.Size(0, 17);
      this.lblAssembly.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // tabControl
      // 
      this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl.Location = new System.Drawing.Point(0, 24);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(1184, 716);
      this.tabControl.TabIndex = 3;
      this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
      // 
      // closeMenuItem
      // 
      closeMenuItem.Name = "closeMenuItem";
      closeMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
      closeMenuItem.Size = new System.Drawing.Size(195, 22);
      closeMenuItem.Text = "&Close";
      closeMenuItem.Click += new System.EventHandler(this.closeMenuItem_Click);
      // 
      // menuSep10
      // 
      menuSep10.Name = "menuSep10";
      menuSep10.Size = new System.Drawing.Size(192, 6);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1184, 762);
      this.Controls.Add(this.tabControl);
      this.Controls.Add(menuStrip);
      this.Controls.Add(statusStrip);
      this.KeyPreview = true;
      this.MainMenuStrip = menuStrip;
      this.Name = "MainForm";
      this.Text = "ExePatch";
      menuStrip.ResumeLayout(false);
      menuStrip.PerformLayout();
      statusStrip.ResumeLayout(false);
      statusStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
    private System.Windows.Forms.ToolStripMenuItem findNextMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    private System.Windows.Forms.ToolStripStatusLabel lblAssembly;
    private System.Windows.Forms.TabControl tabControl;
  }
}

