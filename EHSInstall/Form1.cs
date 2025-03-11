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
using System.IO.Compression;

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

        private async void CopySpecificDirectories(string sourceDir , string ip)
        {
            // Définir les dossiers et leurs destinations
            var directoriesToCopy = new Dictionary<string, string>
    {
            { "Quiz", @"\\"+ ip +"\\c$\\Apps" },
            { "PDFViewer", @"\\"+ ip +"\\c$\\Apps" },
            { "PDF", @"\\"+ ip +"\\c$\\Apps\\PDFViewer\\PDF" },
            { "Raccourci", @"\\"+ ip +"\\c$\\Users\\Public\\Desktop" }
    };

            foreach (var directory in directoriesToCopy)
            {
                string folderName = directory.Key;
                string destinationDir = directory.Value;

                // Construire le chemin complet du dossier source
                string sourceSubDir = Path.Combine(sourceDir, folderName);
                String destinationSubDir = Path.Combine(destinationDir, folderName);

                // Vérifier si le dossier source existe
                if (Directory.Exists(sourceSubDir))
                {
                    switch (folderName)
                    {
                        case "Quiz":
                            if(checkBoxCopieQuiz.Checked == true) {
                                if (!Directory.Exists(destinationSubDir))
                                {
                                    Directory.CreateDirectory(destinationSubDir);
                                    SendToConsole("Le dossier" + destinationSubDir + " a été créé.");
                                }
                                else 
                                {
                                    SendToConsole($"Suppression des éléments du dossier.");
                                    await Task.Run(() => removeAllFile(destinationSubDir));
                                }
                                    SendToConsole($"Copie du dossier {folderName} vers {destinationSubDir}");
                                await Task.Run(() => CopyDirectory(sourceSubDir, destinationSubDir));
                                SendToConsole($"Extraction de Quiz.zip");
                                await Task.Run(() => ZipFile.ExtractToDirectory(Path.Combine(destinationSubDir, "Quiz.zip"), destinationSubDir));
                                progressBar.Value++;
                            }
                            
                            break;
                        case "PDFViewer":
                            if (checkBoxCopieApp.Checked == true)
                            {
                                if (!Directory.Exists(destinationSubDir))
                                {
                                    Directory.CreateDirectory(destinationSubDir);
                                    SendToConsole("Le dossier" + destinationSubDir + " a été créé.");
                                }
                                else
                                {
                                    SendToConsole($"Suppression des éléments du dossier.");
                                    await Task.Run(() => removeAllFile(destinationSubDir));
                                }
                                SendToConsole($"Copie du dossier {folderName} vers {destinationSubDir}");
                                await Task.Run(() => CopyDirectory(sourceSubDir, destinationSubDir));

                                SendToConsole($"Extraction de PDFViewer.zip");
                                await Task.Run(() => ZipFile.ExtractToDirectory(Path.Combine(destinationSubDir, "PDFViewer.zip"), destinationSubDir));
                                progressBar.Value++;
                            }
                            
                            break;
                        case "PDF":
                            if (checkBoxCopiePDF.Checked == true)
                            {
                                if (!Directory.Exists(destinationDir))
                                {
                                    Directory.CreateDirectory(destinationDir);
                                    SendToConsole("Le dossier" + destinationDir + " a été créé.");
                                }
                                else
                                {
                                    SendToConsole($"Suppression des éléments du dossier.");
                                    await Task.Run(() => removeAllFile(destinationDir));
                                }
                                
                                SendToConsole($"Copie du dossier {folderName} vers {destinationDir}");
                                await Task.Run(() => CopyDirectory(sourceSubDir, destinationDir));
                                progressBar.Value++;
                            }
                            
                            break;
                        case "Raccourci":
                            if (checkBoxCopieRaccourci.Checked == true)
                            {
                                await Task.Run(() => removeAllFile(destinationDir));
                                SendToConsole($"Copie du dossier {folderName} vers {destinationDir}");
                                await Task.Run(() => CopyDirectory(sourceSubDir, destinationDir));
                                progressBar.Value++;
                            }
                            break;
                        default:

                            break;
                    }
                }
            }
            SendToConsole("Copie des fichier terminée.");
        }

        private void initProgressBar()
        {
            int checkCopie = 0;
            int numberSelectedPC = 0;
            progressBar.Value = 0;
            if(checkBoxCopiePDF.Checked == true)
            {
                checkCopie++;
            }
            if (checkBoxCopieApp.Checked == true)
            {
                checkCopie++;
            }
            if (checkBoxCopieQuiz.Checked == true)
            {
                checkCopie++;
            }
            if (checkBoxCopieRaccourci.Checked == true)
            {
                checkCopie++;
            }
            foreach (string item in selectedItems)
            {
                numberSelectedPC++;
            }

            progressBar.Maximum = numberSelectedPC * checkCopie;
        }
        private void removeAllFile(String destinationDir)
        {
            try
            {
                // Supprime tous les fichiers
                foreach (string file in Directory.GetFiles(destinationDir))
                {
                    File.Delete(file);
                }

                // Supprime tous les sous-dossiers
                foreach (string dir in Directory.GetDirectories(destinationDir))
                {
                    Directory.Delete(dir, true); // `true` pour supprimer récursivement
                }

                Console.WriteLine("Dossier vidé avec succès !");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }
        }
        private void CopyDirectory(string sourceDir, string destinationDir)
        {
            // Créer le dossier de destination s'il n'existe pas
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
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


        private void StartButton_Click(object sender, EventArgs e)
        {
          
            string username = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            int numberMaxOfItem = 0;

            selectedItems = checkedListBoxPcSelected.CheckedItems.Cast<string>().ToList();
            SendToConsole("Selected PC : ");
            foreach (string item in selectedItems)
            {
                SendToConsole(item);
                numberMaxOfItem++;
            }
            initProgressBar();

            int cptItem = 0;
            foreach (string item in selectedItems)
            {

                networkPath = @"\\" + item + "\\c$"; // Remplace par l'IP du PC distant \\Users\\Public\\Deskto
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
            }
            
        }

        private void SendToConsole(String data)
        {
            richTextBoxConsole.AppendText(data + "\n");
            richTextBoxConsole.SelectionStart = richTextBoxConsole.Text.Length;
            richTextBoxConsole.ScrollToCaret();
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
