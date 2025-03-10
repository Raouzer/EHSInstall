using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EHSInstall
{
    public partial class MainForm : Form
    {
        private string selectedPath;
        private string networkPath;
        private List<string> selectedItems;
        public MainForm()
        {
            InitializeComponent();
        }

        private void PathSelectorMainFolderbutton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Sélectionnez un dossier";
                dialog.ShowNewFolderButton = true; // Permet de créer un nouveau dossier

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    selectedPath = dialog.SelectedPath;
                    labelMainFolderPath.Text = selectedPath;
                    StartButton.Enabled = true;
                }
            }
        }

        private void CopySpecificDirectories(string sourceDir , string ip)
        {
            // Définir les dossiers et leurs destinations
            var directoriesToCopy = new Dictionary<string, string>
    {
            { "Formation", @"\\"+ ip +"\\c$\\Apps" },
            { "PDFViewer", @"\\"+ ip +"\\c$\\Apps" },
            { "Raccourci", @"\\"+ ip +"\\c$\\Users\\Public\\Desktop" }
    };

            foreach (var directory in directoriesToCopy)
            {
                string folderName = directory.Key;
                string destinationDir = directory.Value;

                // Construire le chemin complet du dossier source
                string sourceSubDir = Path.Combine(sourceDir, folderName);

                // Vérifier si le dossier source existe
                if (Directory.Exists(sourceSubDir))
                {
                    Console.WriteLine($"Copie du dossier {folderName} vers {destinationDir}");
                    // Appel de la méthode pour copier ce dossier spécifique
                    CopyDirectory(sourceSubDir, destinationDir);
                }
                else
                {
                    Console.WriteLine($"Le dossier {folderName} n'existe pas dans {sourceDir}");
                }
            }
        }

        private void CopyDirectory(string sourceDir, string destinationDir)
        {
            // Créer le dossier de destination s'il n'existe pas
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
                SendToConsole("Le dossier {destinationDir} a été créé.");
            }

            // Copier les fichiers
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(destinationDir, Path.GetFileName(file));
                File.Copy(file, destFile, true); // true = écraser si le fichier existe
            }

            // Copier les sous-dossiers récursivement
            foreach (string subDir in Directory.GetDirectories(sourceDir))
            {
                string destSubDir = Path.Combine(destinationDir, Path.GetFileName(subDir));

                // Créer le sous-dossier s'il n'existe pas
                if (!Directory.Exists(destSubDir))
                {
                    Directory.CreateDirectory(destSubDir);
                }

                // Appel récursif pour copier les sous-dossiers
                CopyDirectory(subDir, destSubDir);
            }
            SendToConsole("Fin de copie.");
        }

        /* private void CopyDirectory(string sourceDir, string destinationDir)
         {
             if (!Directory.Exists(destinationDir))
             {
                 Directory.CreateDirectory(destinationDir);
                 MessageBox.Show("Directory créé");
             }

             // Copier les fichiers
             foreach (string file in Directory.GetFiles(sourceDir))
             {
                 string destFile = Path.Combine(destinationDir, Path.GetFileName(file));
                 File.Copy(file, destFile, true); // `true` écrase si le fichier existe
             }

             // Copier les sous-dossiers
             foreach (string subDir in Directory.GetDirectories(sourceDir))
             {
                 if(subDir == "Formation")
                 {
                     string destSubDir = Path.Combine(destinationDir, Path.GetFileName(subDir));
                     CopyDirectory(subDir, destSubDir); // Récursion
                 }

             }

         }*/

        private void CopieFile()
        {
            SendToConsole("Try to copie file.");
            if (Directory.Exists(networkPath))
            {
                CopyDirectory(selectedPath, networkPath);
                SendToConsole("Fichiers copiés !");
            }
            else
            {
                SendToConsole("Network Patch error : "+ networkPath);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
          
            string username = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            int numberMaxOfItem = 0;
            


            SendToConsole("Login " + username);
            SendToConsole("Password " + password);
            SendToConsole("LocalPath " + selectedPath);
            
            selectedItems = checkedListBoxPcSelected.CheckedItems.Cast<string>().ToList();
            SendToConsole("Selected PC : ");
            foreach (string item in selectedItems)
            {
                SendToConsole(item);
                numberMaxOfItem++;
            }
            progressBar.Maximum = numberMaxOfItem;
            int cptItem = 0;
            foreach (string item in selectedItems)
            {

                //networkPath = @"\\"+item+"\\c$" // Remplace par l'IP du PC distant \\Users\\Public\\Desktop"
                SendToConsole("NetworkPath : " + networkPath);
                try
                {

                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/C net use {networkPath} /user: local\\{username} {password}",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    using (Process process = Process.Start(psi))
                    {


                        if (process.WaitForExit(10000)) // Attend max 10 secondes
                        {
                            Console.WriteLine("Connexion réussie !");
                            SendToConsole("Connexion réussie!");
                        }
                        else
                        {
                            Console.WriteLine("⏳ Timeout dépassé ! Fermeture du processus...");
                            SendToConsole("Erreur de connexion, suivant...");
                            process.Kill(); // Forcer l'arrêt si ça prend trop de temps
                        }
                    }

                    // Test d'accès au dossier
                    if (System.IO.Directory.Exists(networkPath))
                    {
                        Console.WriteLine("Accès confirmé !");
                        SendToConsole("Accès confirmé !");
                        // CopieFile();
                        CopySpecificDirectories(selectedPath, item);


                    }
                    else
                    {
                        Console.WriteLine("Accès refusé !");
                        SendToConsole("Accès refusé !");
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur : {ex.Message}");
                    SendToConsole($"Erreur : {ex.Message}");
                }
                cptItem++;
                progressBar.Value = cptItem;
            }
            
        }

        private void SendToConsole(String data)
        {
            richTextBoxConsole.AppendText(data + "\n");
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxPcSelected.Items.Count; i++)
            {
                checkedListBoxPcSelected.SetItemChecked(i, true);
            }
        }

        private void buttonDeselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxPcSelected.Items.Count; i++)
            {
                checkedListBoxPcSelected.SetItemChecked(i, false);
            }
        }
    }
}
