namespace Terraform_Templator
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
            this.projectListCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.newProjButton = new System.Windows.Forms.Button();
            this.mainTabController = new System.Windows.Forms.TabControl();
            this.statTab = new System.Windows.Forms.TabPage();
            this.varTab = new System.Windows.Forms.TabPage();
            this.showFolder = new System.Windows.Forms.Button();
            this.variableSaveButton = new System.Windows.Forms.Button();
            this.variablesPanel = new System.Windows.Forms.Panel();
            this.variableTable = new System.Windows.Forms.TableLayoutPanel();
            this.loadProjButton = new System.Windows.Forms.Button();
            this.initializeButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.destroyButton = new System.Windows.Forms.Button();
            this.detailsButton = new System.Windows.Forms.Button();
            this.cmdOutput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mainTabController.SuspendLayout();
            this.statTab.SuspendLayout();
            this.varTab.SuspendLayout();
            this.variablesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // projectListCombo
            // 
            this.projectListCombo.FormattingEnabled = true;
            this.projectListCombo.Location = new System.Drawing.Point(114, 31);
            this.projectListCombo.Name = "projectListCombo";
            this.projectListCombo.Size = new System.Drawing.Size(219, 24);
            this.projectListCombo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Projects";
            // 
            // newProjButton
            // 
            this.newProjButton.Location = new System.Drawing.Point(357, 18);
            this.newProjButton.Name = "newProjButton";
            this.newProjButton.Size = new System.Drawing.Size(145, 49);
            this.newProjButton.TabIndex = 2;
            this.newProjButton.Text = "New";
            this.newProjButton.UseVisualStyleBackColor = true;
            this.newProjButton.Click += new System.EventHandler(this.newProjButton_Click);
            // 
            // mainTabController
            // 
            this.mainTabController.Controls.Add(this.statTab);
            this.mainTabController.Controls.Add(this.varTab);
            this.mainTabController.Location = new System.Drawing.Point(16, 90);
            this.mainTabController.Name = "mainTabController";
            this.mainTabController.SelectedIndex = 0;
            this.mainTabController.Size = new System.Drawing.Size(628, 450);
            this.mainTabController.TabIndex = 3;
            // 
            // statTab
            // 
            this.statTab.Controls.Add(this.label2);
            this.statTab.Controls.Add(this.cmdOutput);
            this.statTab.Controls.Add(this.detailsButton);
            this.statTab.Controls.Add(this.destroyButton);
            this.statTab.Controls.Add(this.applyButton);
            this.statTab.Controls.Add(this.initializeButton);
            this.statTab.Location = new System.Drawing.Point(4, 25);
            this.statTab.Name = "statTab";
            this.statTab.Padding = new System.Windows.Forms.Padding(3);
            this.statTab.Size = new System.Drawing.Size(620, 421);
            this.statTab.TabIndex = 0;
            this.statTab.Text = "Status";
            this.statTab.UseVisualStyleBackColor = true;
            // 
            // varTab
            // 
            this.varTab.Controls.Add(this.showFolder);
            this.varTab.Controls.Add(this.variableSaveButton);
            this.varTab.Controls.Add(this.variablesPanel);
            this.varTab.Location = new System.Drawing.Point(4, 25);
            this.varTab.Name = "varTab";
            this.varTab.Padding = new System.Windows.Forms.Padding(3);
            this.varTab.Size = new System.Drawing.Size(620, 421);
            this.varTab.TabIndex = 1;
            this.varTab.Text = "Variables";
            this.varTab.UseVisualStyleBackColor = true;
            // 
            // showFolder
            // 
            this.showFolder.Location = new System.Drawing.Point(361, 366);
            this.showFolder.Name = "showFolder";
            this.showFolder.Size = new System.Drawing.Size(121, 49);
            this.showFolder.TabIndex = 4;
            this.showFolder.Text = "Open Folder";
            this.showFolder.UseVisualStyleBackColor = true;
            this.showFolder.Click += new System.EventHandler(this.showFolder_Click);
            // 
            // variableSaveButton
            // 
            this.variableSaveButton.Location = new System.Drawing.Point(201, 366);
            this.variableSaveButton.Name = "variableSaveButton";
            this.variableSaveButton.Size = new System.Drawing.Size(121, 49);
            this.variableSaveButton.TabIndex = 3;
            this.variableSaveButton.Text = "Save";
            this.variableSaveButton.UseVisualStyleBackColor = true;
            this.variableSaveButton.Click += new System.EventHandler(this.variableSaveButton_Click);
            // 
            // variablesPanel
            // 
            this.variablesPanel.AutoScroll = true;
            this.variablesPanel.BackColor = System.Drawing.Color.Transparent;
            this.variablesPanel.Controls.Add(this.variableTable);
            this.variablesPanel.Location = new System.Drawing.Point(6, 6);
            this.variablesPanel.Name = "variablesPanel";
            this.variablesPanel.Size = new System.Drawing.Size(608, 339);
            this.variablesPanel.TabIndex = 2;
            // 
            // variableTable
            // 
            this.variableTable.AutoSize = true;
            this.variableTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.variableTable.BackColor = System.Drawing.Color.White;
            this.variableTable.ColumnCount = 3;
            this.variableTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.variableTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.variableTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.variableTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.variableTable.Location = new System.Drawing.Point(0, 0);
            this.variableTable.Name = "variableTable";
            this.variableTable.RowCount = 1;
            this.variableTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.variableTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.variableTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.variableTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.variableTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.variableTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.variableTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.variableTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.variableTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.variableTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.variableTable.Size = new System.Drawing.Size(608, 80);
            this.variableTable.TabIndex = 4;
            // 
            // loadProjButton
            // 
            this.loadProjButton.Location = new System.Drawing.Point(522, 19);
            this.loadProjButton.Name = "loadProjButton";
            this.loadProjButton.Size = new System.Drawing.Size(118, 48);
            this.loadProjButton.TabIndex = 0;
            this.loadProjButton.Text = "Load";
            this.loadProjButton.UseVisualStyleBackColor = true;
            this.loadProjButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // initializeButton
            // 
            this.initializeButton.Location = new System.Drawing.Point(41, 35);
            this.initializeButton.Name = "initializeButton";
            this.initializeButton.Size = new System.Drawing.Size(130, 50);
            this.initializeButton.TabIndex = 0;
            this.initializeButton.Text = "Initialize";
            this.initializeButton.UseVisualStyleBackColor = true;
            this.initializeButton.Click += new System.EventHandler(this.initializeButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(222, 35);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(130, 50);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            // 
            // destroyButton
            // 
            this.destroyButton.Location = new System.Drawing.Point(411, 35);
            this.destroyButton.Name = "destroyButton";
            this.destroyButton.Size = new System.Drawing.Size(130, 50);
            this.destroyButton.TabIndex = 2;
            this.destroyButton.Text = "Destroy";
            this.destroyButton.UseVisualStyleBackColor = true;
            // 
            // detailsButton
            // 
            this.detailsButton.Location = new System.Drawing.Point(277, 91);
            this.detailsButton.Name = "detailsButton";
            this.detailsButton.Size = new System.Drawing.Size(75, 28);
            this.detailsButton.TabIndex = 3;
            this.detailsButton.Text = "Details";
            this.detailsButton.UseVisualStyleBackColor = true;
            // 
            // cmdOutput
            // 
            this.cmdOutput.Location = new System.Drawing.Point(39, 165);
            this.cmdOutput.Multiline = true;
            this.cmdOutput.Name = "cmdOutput";
            this.cmdOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.cmdOutput.Size = new System.Drawing.Size(545, 227);
            this.cmdOutput.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 598);
            this.Controls.Add(this.mainTabController);
            this.Controls.Add(this.loadProjButton);
            this.Controls.Add(this.newProjButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.projectListCombo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terraform Templator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainTabController.ResumeLayout(false);
            this.statTab.ResumeLayout(false);
            this.statTab.PerformLayout();
            this.varTab.ResumeLayout(false);
            this.variablesPanel.ResumeLayout(false);
            this.variablesPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox projectListCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button newProjButton;
        private System.Windows.Forms.TabControl mainTabController;
        private System.Windows.Forms.TabPage statTab;
        private System.Windows.Forms.TabPage varTab;
        private System.Windows.Forms.Button loadProjButton;
        private System.Windows.Forms.Panel variablesPanel;
        private System.Windows.Forms.Button variableSaveButton;
        private System.Windows.Forms.TableLayoutPanel variableTable;
        private System.Windows.Forms.Button showFolder;
        private System.Windows.Forms.Button initializeButton;
        private System.Windows.Forms.Button detailsButton;
        private System.Windows.Forms.Button destroyButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cmdOutput;
    }
}

