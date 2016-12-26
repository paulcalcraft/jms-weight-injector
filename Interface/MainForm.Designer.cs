namespace ModelTools.Interface
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
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFile_Import = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_Import_Weights = new System.Windows.Forms.ToolStripMenuItem();
            this.MainGroup = new System.Windows.Forms.GroupBox();
            this.MainGroup_btnUpdateNodeChecksum = new System.Windows.Forms.Button();
            this.MainGroup_lblWelcome = new System.Windows.Forms.Label();
            this.MainGroup_lblNodeChecksum = new System.Windows.Forms.Label();
            this.MainGroup_txtNodeChecksum = new System.Windows.Forms.TextBox();
            this.OutputGroup_txtOutput = new System.Windows.Forms.TextBox();
            this.OutputGroup = new System.Windows.Forms.GroupBox();
            this.lblPrecision = new System.Windows.Forms.Label();
            this.txtSigFigs = new System.Windows.Forms.TextBox();
            this.mnuMain.SuspendLayout();
            this.MainGroup.SuspendLayout();
            this.OutputGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(14, 4, 0, 4);
            this.mnuMain.Size = new System.Drawing.Size(1127, 49);
            this.mnuMain.TabIndex = 0;
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile_Open,
            this.mnuFile_Save,
            this.mnuFile_SaveAs,
            this.mnuFile_Close,
            this.toolStripSeparator1,
            this.mnuFile_Import});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(70, 41);
            this.mnuFile.Text = "File";
            // 
            // mnuFile_Open
            // 
            this.mnuFile_Open.Name = "mnuFile_Open";
            this.mnuFile_Open.Size = new System.Drawing.Size(233, 42);
            this.mnuFile_Open.Text = "Open";
            this.mnuFile_Open.Click += new System.EventHandler(this.mnuFile_Open_Click);
            // 
            // mnuFile_Save
            // 
            this.mnuFile_Save.Name = "mnuFile_Save";
            this.mnuFile_Save.Size = new System.Drawing.Size(233, 42);
            this.mnuFile_Save.Text = "Save";
            this.mnuFile_Save.Click += new System.EventHandler(this.mnuFile_Save_Click);
            // 
            // mnuFile_SaveAs
            // 
            this.mnuFile_SaveAs.Name = "mnuFile_SaveAs";
            this.mnuFile_SaveAs.Size = new System.Drawing.Size(233, 42);
            this.mnuFile_SaveAs.Text = "Save As...";
            this.mnuFile_SaveAs.Click += new System.EventHandler(this.mnuFile_SaveAs_Click);
            // 
            // mnuFile_Close
            // 
            this.mnuFile_Close.Name = "mnuFile_Close";
            this.mnuFile_Close.Size = new System.Drawing.Size(233, 42);
            this.mnuFile_Close.Text = "Close";
            this.mnuFile_Close.Click += new System.EventHandler(this.mnuFile_Close_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(230, 6);
            // 
            // mnuFile_Import
            // 
            this.mnuFile_Import.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile_Import_Weights});
            this.mnuFile_Import.Name = "mnuFile_Import";
            this.mnuFile_Import.Size = new System.Drawing.Size(233, 42);
            this.mnuFile_Import.Text = "Import";
            // 
            // mnuFile_Import_Weights
            // 
            this.mnuFile_Import_Weights.Name = "mnuFile_Import_Weights";
            this.mnuFile_Import_Weights.Size = new System.Drawing.Size(221, 42);
            this.mnuFile_Import_Weights.Text = "Weights";
            this.mnuFile_Import_Weights.Click += new System.EventHandler(this.mnuFile_Import_Weights_Click);
            // 
            // MainGroup
            // 
            this.MainGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainGroup.Controls.Add(this.MainGroup_btnUpdateNodeChecksum);
            this.MainGroup.Controls.Add(this.MainGroup_lblWelcome);
            this.MainGroup.Controls.Add(this.MainGroup_lblNodeChecksum);
            this.MainGroup.Controls.Add(this.MainGroup_txtNodeChecksum);
            this.MainGroup.Location = new System.Drawing.Point(28, 80);
            this.MainGroup.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.MainGroup.Name = "MainGroup";
            this.MainGroup.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.MainGroup.Size = new System.Drawing.Size(1071, 112);
            this.MainGroup.TabIndex = 1;
            this.MainGroup.TabStop = false;
            // 
            // MainGroup_btnUpdateNodeChecksum
            // 
            this.MainGroup_btnUpdateNodeChecksum.Location = new System.Drawing.Point(490, 42);
            this.MainGroup_btnUpdateNodeChecksum.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.MainGroup_btnUpdateNodeChecksum.Name = "MainGroup_btnUpdateNodeChecksum";
            this.MainGroup_btnUpdateNodeChecksum.Size = new System.Drawing.Size(170, 45);
            this.MainGroup_btnUpdateNodeChecksum.TabIndex = 3;
            this.MainGroup_btnUpdateNodeChecksum.Text = "Update";
            this.MainGroup_btnUpdateNodeChecksum.UseVisualStyleBackColor = true;
            this.MainGroup_btnUpdateNodeChecksum.Click += new System.EventHandler(this.MainGroup_btnUpdateNodeChecksum_Click);
            // 
            // MainGroup_lblWelcome
            // 
            this.MainGroup_lblWelcome.AutoSize = true;
            this.MainGroup_lblWelcome.Location = new System.Drawing.Point(16, 47);
            this.MainGroup_lblWelcome.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.MainGroup_lblWelcome.Name = "MainGroup_lblWelcome";
            this.MainGroup_lblWelcome.Size = new System.Drawing.Size(742, 29);
            this.MainGroup_lblWelcome.TabIndex = 2;
            this.MainGroup_lblWelcome.Text = "Welcome to the JMS Weight Injector. Please open a JMS file to start.";
            // 
            // MainGroup_lblNodeChecksum
            // 
            this.MainGroup_lblNodeChecksum.AutoSize = true;
            this.MainGroup_lblNodeChecksum.Location = new System.Drawing.Point(26, 49);
            this.MainGroup_lblNodeChecksum.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.MainGroup_lblNodeChecksum.Name = "MainGroup_lblNodeChecksum";
            this.MainGroup_lblNodeChecksum.Size = new System.Drawing.Size(192, 29);
            this.MainGroup_lblNodeChecksum.TabIndex = 1;
            this.MainGroup_lblNodeChecksum.Text = "Node Checksum";
            // 
            // MainGroup_txtNodeChecksum
            // 
            this.MainGroup_txtNodeChecksum.Location = new System.Drawing.Point(240, 42);
            this.MainGroup_txtNodeChecksum.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.MainGroup_txtNodeChecksum.Name = "MainGroup_txtNodeChecksum";
            this.MainGroup_txtNodeChecksum.Size = new System.Drawing.Size(230, 35);
            this.MainGroup_txtNodeChecksum.TabIndex = 0;
            // 
            // OutputGroup_txtOutput
            // 
            this.OutputGroup_txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputGroup_txtOutput.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.OutputGroup_txtOutput.Font = new System.Drawing.Font("Arial", 7.25F);
            this.OutputGroup_txtOutput.Location = new System.Drawing.Point(33, 51);
            this.OutputGroup_txtOutput.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.OutputGroup_txtOutput.Multiline = true;
            this.OutputGroup_txtOutput.Name = "OutputGroup_txtOutput";
            this.OutputGroup_txtOutput.ReadOnly = true;
            this.OutputGroup_txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputGroup_txtOutput.Size = new System.Drawing.Size(1007, 283);
            this.OutputGroup_txtOutput.TabIndex = 3;
            // 
            // OutputGroup
            // 
            this.OutputGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputGroup.Controls.Add(this.OutputGroup_txtOutput);
            this.OutputGroup.Location = new System.Drawing.Point(28, 205);
            this.OutputGroup.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.OutputGroup.Name = "OutputGroup";
            this.OutputGroup.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.OutputGroup.Size = new System.Drawing.Size(1078, 373);
            this.OutputGroup.TabIndex = 4;
            this.OutputGroup.TabStop = false;
            this.OutputGroup.Text = "Output";
            // 
            // lblPrecision
            // 
            this.lblPrecision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPrecision.AutoSize = true;
            this.lblPrecision.Location = new System.Drawing.Point(37, 593);
            this.lblPrecision.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblPrecision.Name = "lblPrecision";
            this.lblPrecision.Size = new System.Drawing.Size(331, 29);
            this.lblPrecision.TabIndex = 6;
            this.lblPrecision.Text = "Precision, Significant Figures:";
            // 
            // txtSigFigs
            // 
            this.txtSigFigs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSigFigs.Location = new System.Drawing.Point(390, 587);
            this.txtSigFigs.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.txtSigFigs.Name = "txtSigFigs";
            this.txtSigFigs.Size = new System.Drawing.Size(93, 35);
            this.txtSigFigs.TabIndex = 7;
            this.txtSigFigs.Text = "6";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 642);
            this.Controls.Add(this.txtSigFigs);
            this.Controls.Add(this.lblPrecision);
            this.Controls.Add(this.OutputGroup);
            this.Controls.Add(this.MainGroup);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Name = "MainForm";
            this.Text = "JMS Weight Injector v1.0.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.MainGroup.ResumeLayout(false);
            this.MainGroup.PerformLayout();
            this.OutputGroup.ResumeLayout(false);
            this.OutputGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip mnuMain;
    private System.Windows.Forms.ToolStripMenuItem mnuFile;
    private System.Windows.Forms.ToolStripMenuItem mnuFile_Open;
    private System.Windows.Forms.ToolStripMenuItem mnuFile_Close;
    private System.Windows.Forms.ToolStripMenuItem mnuFile_Import;
    private System.Windows.Forms.ToolStripMenuItem mnuFile_Import_Weights;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem mnuFile_Save;
    private System.Windows.Forms.ToolStripMenuItem mnuFile_SaveAs;
    private System.Windows.Forms.GroupBox MainGroup;
    private System.Windows.Forms.Label MainGroup_lblNodeChecksum;
    private System.Windows.Forms.TextBox MainGroup_txtNodeChecksum;
    private System.Windows.Forms.TextBox OutputGroup_txtOutput;
    private System.Windows.Forms.GroupBox OutputGroup;
    private System.Windows.Forms.Label MainGroup_lblWelcome;
    private System.Windows.Forms.Button MainGroup_btnUpdateNodeChecksum;
    private System.Windows.Forms.Label lblPrecision;
    private System.Windows.Forms.TextBox txtSigFigs;
  }
}