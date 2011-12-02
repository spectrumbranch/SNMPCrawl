namespace SNMPCrawl
{
    partial class Form1
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
            if (disposing && (components != null))
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
            this.communityLabel = new System.Windows.Forms.Label();
            this.submitBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setSNMPWalkFilepathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadServerListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.communityTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.numServersLoadedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.snmpwalkLoadedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.versGroupBox = new System.Windows.Forms.GroupBox();
            this.radioVers3 = new System.Windows.Forms.RadioButton();
            this.radioVers2c = new System.Windows.Forms.RadioButton();
            this.radioVers1 = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.versGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // communityLabel
            // 
            this.communityLabel.AutoSize = true;
            this.communityLabel.Location = new System.Drawing.Point(9, 50);
            this.communityLabel.Name = "communityLabel";
            this.communityLabel.Size = new System.Drawing.Size(61, 13);
            this.communityLabel.TabIndex = 0;
            this.communityLabel.Text = "Community:";
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(76, 76);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(231, 42);
            this.submitBtn.TabIndex = 1;
            this.submitBtn.Text = "Start Crawl";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(388, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setSNMPWalkFilepathToolStripMenuItem,
            this.loadServerListToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // setSNMPWalkFilepathToolStripMenuItem
            // 
            this.setSNMPWalkFilepathToolStripMenuItem.Name = "setSNMPWalkFilepathToolStripMenuItem";
            this.setSNMPWalkFilepathToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.setSNMPWalkFilepathToolStripMenuItem.Text = "&Set SNMPWalk Filepath";
            this.setSNMPWalkFilepathToolStripMenuItem.Click += new System.EventHandler(this.setSNMPWalkFilepathToolStripMenuItem_Click);
            // 
            // loadServerListToolStripMenuItem
            // 
            this.loadServerListToolStripMenuItem.Name = "loadServerListToolStripMenuItem";
            this.loadServerListToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.loadServerListToolStripMenuItem.Text = "&Load Server List";
            this.loadServerListToolStripMenuItem.Click += new System.EventHandler(this.loadServerListToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // communityTextBox
            // 
            this.communityTextBox.Location = new System.Drawing.Point(76, 50);
            this.communityTextBox.Name = "communityTextBox";
            this.communityTextBox.Size = new System.Drawing.Size(231, 20);
            this.communityTextBox.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.numServersLoadedLabel,
            this.toolStripStatusLabel1,
            this.snmpwalkLoadedLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 132);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(388, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // numServersLoadedLabel
            // 
            this.numServersLoadedLabel.AutoSize = false;
            this.numServersLoadedLabel.Name = "numServersLoadedLabel";
            this.numServersLoadedLabel.Size = new System.Drawing.Size(130, 17);
            this.numServersLoadedLabel.Text = "No Server File Loaded";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // snmpwalkLoadedLabel
            // 
            this.snmpwalkLoadedLabel.AutoSize = false;
            this.snmpwalkLoadedLabel.Name = "snmpwalkLoadedLabel";
            this.snmpwalkLoadedLabel.Size = new System.Drawing.Size(130, 17);
            this.snmpwalkLoadedLabel.Text = "SNMPwalk Not Loaded";
            // 
            // versGroupBox
            // 
            this.versGroupBox.Controls.Add(this.radioVers3);
            this.versGroupBox.Controls.Add(this.radioVers2c);
            this.versGroupBox.Controls.Add(this.radioVers1);
            this.versGroupBox.Location = new System.Drawing.Point(313, 28);
            this.versGroupBox.Name = "versGroupBox";
            this.versGroupBox.Size = new System.Drawing.Size(69, 90);
            this.versGroupBox.TabIndex = 5;
            this.versGroupBox.TabStop = false;
            this.versGroupBox.Text = "Version";
            // 
            // radioVers3
            // 
            this.radioVers3.AutoSize = true;
            this.radioVers3.Location = new System.Drawing.Point(14, 65);
            this.radioVers3.Name = "radioVers3";
            this.radioVers3.Size = new System.Drawing.Size(31, 17);
            this.radioVers3.TabIndex = 2;
            this.radioVers3.TabStop = true;
            this.radioVers3.Text = "3";
            this.radioVers3.UseVisualStyleBackColor = true;
            // 
            // radioVers2c
            // 
            this.radioVers2c.AutoSize = true;
            this.radioVers2c.Checked = true;
            this.radioVers2c.Location = new System.Drawing.Point(14, 42);
            this.radioVers2c.Name = "radioVers2c";
            this.radioVers2c.Size = new System.Drawing.Size(37, 17);
            this.radioVers2c.TabIndex = 1;
            this.radioVers2c.TabStop = true;
            this.radioVers2c.Text = "2c";
            this.radioVers2c.UseVisualStyleBackColor = true;
            // 
            // radioVers1
            // 
            this.radioVers1.AutoSize = true;
            this.radioVers1.Location = new System.Drawing.Point(14, 19);
            this.radioVers1.Name = "radioVers1";
            this.radioVers1.Size = new System.Drawing.Size(31, 17);
            this.radioVers1.TabIndex = 0;
            this.radioVers1.TabStop = true;
            this.radioVers1.Text = "1";
            this.radioVers1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 154);
            this.Controls.Add(this.versGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.communityTextBox);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.communityLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SNMPCrawl by Chris Bebry [v0.2.1]";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.versGroupBox.ResumeLayout(false);
            this.versGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label communityLabel;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadServerListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox communityTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel numServersLoadedLabel;
        private System.Windows.Forms.ToolStripMenuItem setSNMPWalkFilepathToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel snmpwalkLoadedLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox versGroupBox;
        private System.Windows.Forms.RadioButton radioVers3;
        private System.Windows.Forms.RadioButton radioVers2c;
        private System.Windows.Forms.RadioButton radioVers1;
    }
}

