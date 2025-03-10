namespace EHSInstall
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelMainFolderPath = new System.Windows.Forms.Label();
            this.labelMainFolderTitle = new System.Windows.Forms.Label();
            this.PathSelectorMainFolderbutton = new System.Windows.Forms.Button();
            this.checkedListBoxPcSelected = new System.Windows.Forms.CheckedListBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelLoginTitle = new System.Windows.Forms.Label();
            this.labelPasswordTitle = new System.Windows.Forms.Label();
            this.richTextBoxConsole = new System.Windows.Forms.RichTextBox();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.buttonDeselectAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMainFolderPath
            // 
            this.labelMainFolderPath.AutoSize = true;
            this.labelMainFolderPath.Location = new System.Drawing.Point(12, 105);
            this.labelMainFolderPath.Name = "labelMainFolderPath";
            this.labelMainFolderPath.Size = new System.Drawing.Size(43, 13);
            this.labelMainFolderPath.TabIndex = 0;
            this.labelMainFolderPath.Text = "NoPath";
            // 
            // labelMainFolderTitle
            // 
            this.labelMainFolderTitle.AutoSize = true;
            this.labelMainFolderTitle.Location = new System.Drawing.Point(12, 92);
            this.labelMainFolderTitle.Name = "labelMainFolderTitle";
            this.labelMainFolderTitle.Size = new System.Drawing.Size(108, 13);
            this.labelMainFolderTitle.TabIndex = 1;
            this.labelMainFolderTitle.Text = "Selection du dossier :";
            // 
            // PathSelectorMainFolderbutton
            // 
            this.PathSelectorMainFolderbutton.Location = new System.Drawing.Point(15, 134);
            this.PathSelectorMainFolderbutton.Name = "PathSelectorMainFolderbutton";
            this.PathSelectorMainFolderbutton.Size = new System.Drawing.Size(289, 23);
            this.PathSelectorMainFolderbutton.TabIndex = 2;
            this.PathSelectorMainFolderbutton.Text = "Selectionner le dossier";
            this.PathSelectorMainFolderbutton.UseVisualStyleBackColor = true;
            this.PathSelectorMainFolderbutton.Click += new System.EventHandler(this.PathSelectorMainFolderbutton_Click);
            // 
            // checkedListBoxPcSelected
            // 
            this.checkedListBoxPcSelected.FormattingEnabled = true;
            this.checkedListBoxPcSelected.HorizontalScrollbar = true;
            this.checkedListBoxPcSelected.ImeMode = System.Windows.Forms.ImeMode.On;
            this.checkedListBoxPcSelected.IntegralHeight = false;
            this.checkedListBoxPcSelected.Items.AddRange(new object[] {
            "10.107.79.128",
            "10.107.79.129",
            "10.107.79.130",
            "10.107.79.131"});
            this.checkedListBoxPcSelected.Location = new System.Drawing.Point(12, 192);
            this.checkedListBoxPcSelected.Name = "checkedListBoxPcSelected";
            this.checkedListBoxPcSelected.Size = new System.Drawing.Size(292, 245);
            this.checkedListBoxPcSelected.TabIndex = 3;
            // 
            // StartButton
            // 
            this.StartButton.Enabled = false;
            this.StartButton.Location = new System.Drawing.Point(12, 443);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(292, 42);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 495);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(292, 23);
            this.progressBar.TabIndex = 5;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(73, 25);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(231, 20);
            this.textBoxLogin.TabIndex = 8;
            this.textBoxLogin.Text = "EHS_ADM";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(73, 51);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(231, 20);
            this.textBoxPassword.TabIndex = 9;
            this.textBoxPassword.Text = "GSK_2030_@_128";
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelLoginTitle
            // 
            this.labelLoginTitle.AutoSize = true;
            this.labelLoginTitle.Location = new System.Drawing.Point(9, 32);
            this.labelLoginTitle.Name = "labelLoginTitle";
            this.labelLoginTitle.Size = new System.Drawing.Size(39, 13);
            this.labelLoginTitle.TabIndex = 10;
            this.labelLoginTitle.Text = "Login :";
            // 
            // labelPasswordTitle
            // 
            this.labelPasswordTitle.AutoSize = true;
            this.labelPasswordTitle.Location = new System.Drawing.Point(9, 54);
            this.labelPasswordTitle.Name = "labelPasswordTitle";
            this.labelPasswordTitle.Size = new System.Drawing.Size(59, 13);
            this.labelPasswordTitle.TabIndex = 11;
            this.labelPasswordTitle.Text = "Password :";
            // 
            // richTextBoxConsole
            // 
            this.richTextBoxConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxConsole.BackColor = System.Drawing.Color.Black;
            this.richTextBoxConsole.ForeColor = System.Drawing.Color.White;
            this.richTextBoxConsole.Location = new System.Drawing.Point(315, 25);
            this.richTextBoxConsole.Name = "richTextBoxConsole";
            this.richTextBoxConsole.Size = new System.Drawing.Size(573, 493);
            this.richTextBoxConsole.TabIndex = 12;
            this.richTextBoxConsole.Text = "";
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.Location = new System.Drawing.Point(12, 163);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(96, 23);
            this.buttonSelectAll.TabIndex = 13;
            this.buttonSelectAll.Text = "Select All";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // buttonDeselectAll
            // 
            this.buttonDeselectAll.Location = new System.Drawing.Point(114, 163);
            this.buttonDeselectAll.Name = "buttonDeselectAll";
            this.buttonDeselectAll.Size = new System.Drawing.Size(96, 23);
            this.buttonDeselectAll.TabIndex = 14;
            this.buttonDeselectAll.Text = "Deselect All";
            this.buttonDeselectAll.UseVisualStyleBackColor = true;
            this.buttonDeselectAll.Click += new System.EventHandler(this.buttonDeselectAll_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 526);
            this.Controls.Add(this.buttonDeselectAll);
            this.Controls.Add(this.buttonSelectAll);
            this.Controls.Add(this.richTextBoxConsole);
            this.Controls.Add(this.labelPasswordTitle);
            this.Controls.Add(this.labelLoginTitle);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.checkedListBoxPcSelected);
            this.Controls.Add(this.PathSelectorMainFolderbutton);
            this.Controls.Add(this.labelMainFolderTitle);
            this.Controls.Add(this.labelMainFolderPath);
            this.MinimumSize = new System.Drawing.Size(893, 565);
            this.Name = "MainForm";
            this.Text = "EHSInstall";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMainFolderPath;
        private System.Windows.Forms.Label labelMainFolderTitle;
        private System.Windows.Forms.Button PathSelectorMainFolderbutton;
        private System.Windows.Forms.CheckedListBox checkedListBoxPcSelected;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelLoginTitle;
        private System.Windows.Forms.Label labelPasswordTitle;
        private System.Windows.Forms.RichTextBox richTextBoxConsole;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.Button buttonDeselectAll;
    }
}

