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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PathSelectorMainFolderbutton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelLoginTitle = new System.Windows.Forms.Label();
            this.labelPasswordTitle = new System.Windows.Forms.Label();
            this.richTextBoxConsole = new System.Windows.Forms.RichTextBox();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.buttonDeselectAll = new System.Windows.Forms.Button();
            this.checkBoxCopiePDF = new System.Windows.Forms.CheckBox();
            this.checkBoxCopieApp = new System.Windows.Forms.CheckBox();
            this.checkBoxCopieQuiz = new System.Windows.Forms.CheckBox();
            this.checkBoxCopieRaccourci = new System.Windows.Forms.CheckBox();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.richTextBoxMainFolderPath = new System.Windows.Forms.RichTextBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.buttonMajList = new System.Windows.Forms.Button();
            this.listViewPcSelector = new System.Windows.Forms.ListView();
            this.buttonFichierIP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PathSelectorMainFolderbutton
            // 
            this.PathSelectorMainFolderbutton.Location = new System.Drawing.Point(12, 64);
            this.PathSelectorMainFolderbutton.Name = "PathSelectorMainFolderbutton";
            this.PathSelectorMainFolderbutton.Size = new System.Drawing.Size(292, 23);
            this.PathSelectorMainFolderbutton.TabIndex = 2;
            this.PathSelectorMainFolderbutton.Text = "Selectionner le dossier";
            this.PathSelectorMainFolderbutton.UseVisualStyleBackColor = true;
            this.PathSelectorMainFolderbutton.Click += new System.EventHandler(this.PathSelectorMainFolderbutton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StartButton.Enabled = false;
            this.StartButton.Location = new System.Drawing.Point(12, 413);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(292, 59);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 478);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(784, 23);
            this.progressBar.TabIndex = 5;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(73, 12);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(231, 20);
            this.textBoxLogin.TabIndex = 8;
            this.textBoxLogin.Text = "EHS_ADM";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(73, 38);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(231, 20);
            this.textBoxPassword.TabIndex = 9;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelLoginTitle
            // 
            this.labelLoginTitle.AutoSize = true;
            this.labelLoginTitle.Location = new System.Drawing.Point(9, 19);
            this.labelLoginTitle.Name = "labelLoginTitle";
            this.labelLoginTitle.Size = new System.Drawing.Size(39, 13);
            this.labelLoginTitle.TabIndex = 10;
            this.labelLoginTitle.Text = "Login :";
            // 
            // labelPasswordTitle
            // 
            this.labelPasswordTitle.AutoSize = true;
            this.labelPasswordTitle.Location = new System.Drawing.Point(9, 41);
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
            this.richTextBoxConsole.Location = new System.Drawing.Point(315, 12);
            this.richTextBoxConsole.Name = "richTextBoxConsole";
            this.richTextBoxConsole.ReadOnly = true;
            this.richTextBoxConsole.Size = new System.Drawing.Size(573, 460);
            this.richTextBoxConsole.TabIndex = 12;
            this.richTextBoxConsole.Text = "";
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.Location = new System.Drawing.Point(12, 150);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(134, 23);
            this.buttonSelectAll.TabIndex = 13;
            this.buttonSelectAll.Text = "Sélectionner tout";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // buttonDeselectAll
            // 
            this.buttonDeselectAll.Location = new System.Drawing.Point(152, 150);
            this.buttonDeselectAll.Name = "buttonDeselectAll";
            this.buttonDeselectAll.Size = new System.Drawing.Size(152, 23);
            this.buttonDeselectAll.TabIndex = 14;
            this.buttonDeselectAll.Text = "Désélectionner tout";
            this.buttonDeselectAll.UseVisualStyleBackColor = true;
            this.buttonDeselectAll.Click += new System.EventHandler(this.buttonDeselectAll_Click);
            // 
            // checkBoxCopiePDF
            // 
            this.checkBoxCopiePDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxCopiePDF.AutoSize = true;
            this.checkBoxCopiePDF.Checked = true;
            this.checkBoxCopiePDF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCopiePDF.Enabled = false;
            this.checkBoxCopiePDF.Location = new System.Drawing.Point(26, 390);
            this.checkBoxCopiePDF.Name = "checkBoxCopiePDF";
            this.checkBoxCopiePDF.Size = new System.Drawing.Size(47, 17);
            this.checkBoxCopiePDF.TabIndex = 15;
            this.checkBoxCopiePDF.Text = "PDF";
            this.checkBoxCopiePDF.UseVisualStyleBackColor = true;
            // 
            // checkBoxCopieApp
            // 
            this.checkBoxCopieApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxCopieApp.AutoSize = true;
            this.checkBoxCopieApp.Checked = true;
            this.checkBoxCopieApp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCopieApp.Location = new System.Drawing.Point(79, 390);
            this.checkBoxCopieApp.Name = "checkBoxCopieApp";
            this.checkBoxCopieApp.Size = new System.Drawing.Size(78, 17);
            this.checkBoxCopieApp.TabIndex = 16;
            this.checkBoxCopieApp.Text = "Application";
            this.checkBoxCopieApp.UseVisualStyleBackColor = true;
            this.checkBoxCopieApp.CheckedChanged += new System.EventHandler(this.checkBoxCopieApp_CheckedChanged);
            // 
            // checkBoxCopieQuiz
            // 
            this.checkBoxCopieQuiz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxCopieQuiz.AutoSize = true;
            this.checkBoxCopieQuiz.Checked = true;
            this.checkBoxCopieQuiz.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCopieQuiz.Location = new System.Drawing.Point(163, 390);
            this.checkBoxCopieQuiz.Name = "checkBoxCopieQuiz";
            this.checkBoxCopieQuiz.Size = new System.Drawing.Size(47, 17);
            this.checkBoxCopieQuiz.TabIndex = 17;
            this.checkBoxCopieQuiz.Text = "Quiz";
            this.checkBoxCopieQuiz.UseVisualStyleBackColor = true;
            // 
            // checkBoxCopieRaccourci
            // 
            this.checkBoxCopieRaccourci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxCopieRaccourci.AutoSize = true;
            this.checkBoxCopieRaccourci.Checked = true;
            this.checkBoxCopieRaccourci.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCopieRaccourci.Location = new System.Drawing.Point(216, 390);
            this.checkBoxCopieRaccourci.Name = "checkBoxCopieRaccourci";
            this.checkBoxCopieRaccourci.Size = new System.Drawing.Size(75, 17);
            this.checkBoxCopieRaccourci.TabIndex = 18;
            this.checkBoxCopieRaccourci.Text = "Raccourci";
            this.checkBoxCopieRaccourci.UseVisualStyleBackColor = true;
            // 
            // buttonRestart
            // 
            this.buttonRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRestart.Location = new System.Drawing.Point(12, 361);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(134, 23);
            this.buttonRestart.TabIndex = 19;
            this.buttonRestart.Text = "Redémarrer le pc";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // richTextBoxMainFolderPath
            // 
            this.richTextBoxMainFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxMainFolderPath.Location = new System.Drawing.Point(12, 93);
            this.richTextBoxMainFolderPath.Name = "richTextBoxMainFolderPath";
            this.richTextBoxMainFolderPath.ReadOnly = true;
            this.richTextBoxMainFolderPath.Size = new System.Drawing.Size(289, 51);
            this.richTextBoxMainFolderPath.TabIndex = 20;
            this.richTextBoxMainFolderPath.Text = "Sélectionner le dossier contenant les dossiers PDF, PdfViewer,Quiz et Raccourci.." +
    ".";
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(798, 478);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(90, 20);
            this.labelVersion.TabIndex = 21;
            this.labelVersion.Text = "© RG 2025 v1";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelVersion.UseCompatibleTextRendering = true;
            this.labelVersion.DoubleClick += new System.EventHandler(this.labelVersion_DoubleClick);
            // 
            // buttonMajList
            // 
            this.buttonMajList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMajList.Location = new System.Drawing.Point(228, 361);
            this.buttonMajList.Name = "buttonMajList";
            this.buttonMajList.Size = new System.Drawing.Size(72, 23);
            this.buttonMajList.TabIndex = 22;
            this.buttonMajList.Text = "Maj liste";
            this.buttonMajList.UseVisualStyleBackColor = true;
            this.buttonMajList.Click += new System.EventHandler(this.buttonMajList_Click);
            // 
            // listViewPcSelector
            // 
            this.listViewPcSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewPcSelector.HideSelection = false;
            this.listViewPcSelector.Location = new System.Drawing.Point(12, 179);
            this.listViewPcSelector.Name = "listViewPcSelector";
            this.listViewPcSelector.Size = new System.Drawing.Size(289, 176);
            this.listViewPcSelector.TabIndex = 23;
            this.listViewPcSelector.UseCompatibleStateImageBehavior = false;
            // 
            // buttonFichierIP
            // 
            this.buttonFichierIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonFichierIP.Location = new System.Drawing.Point(152, 361);
            this.buttonFichierIP.Name = "buttonFichierIP";
            this.buttonFichierIP.Size = new System.Drawing.Size(70, 23);
            this.buttonFichierIP.TabIndex = 24;
            this.buttonFichierIP.Text = "Fichier IP";
            this.buttonFichierIP.UseVisualStyleBackColor = true;
            this.buttonFichierIP.Click += new System.EventHandler(this.buttonFichierIP_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 509);
            this.Controls.Add(this.buttonFichierIP);
            this.Controls.Add(this.listViewPcSelector);
            this.Controls.Add(this.buttonMajList);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.richTextBoxMainFolderPath);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.checkBoxCopieRaccourci);
            this.Controls.Add(this.checkBoxCopieQuiz);
            this.Controls.Add(this.checkBoxCopieApp);
            this.Controls.Add(this.checkBoxCopiePDF);
            this.Controls.Add(this.buttonDeselectAll);
            this.Controls.Add(this.buttonSelectAll);
            this.Controls.Add(this.richTextBoxConsole);
            this.Controls.Add(this.labelPasswordTitle);
            this.Controls.Add(this.labelLoginTitle);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.PathSelectorMainFolderbutton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(893, 548);
            this.Name = "MainForm";
            this.Text = "EHSInstall";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button PathSelectorMainFolderbutton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelLoginTitle;
        private System.Windows.Forms.Label labelPasswordTitle;
        private System.Windows.Forms.RichTextBox richTextBoxConsole;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.Button buttonDeselectAll;
        private System.Windows.Forms.CheckBox checkBoxCopiePDF;
        private System.Windows.Forms.CheckBox checkBoxCopieApp;
        private System.Windows.Forms.CheckBox checkBoxCopieQuiz;
        private System.Windows.Forms.CheckBox checkBoxCopieRaccourci;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.RichTextBox richTextBoxMainFolderPath;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Button buttonMajList;
        private System.Windows.Forms.ListView listViewPcSelector;
        private System.Windows.Forms.Button buttonFichierIP;
    }
}

