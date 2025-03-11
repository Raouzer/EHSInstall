using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace EHSInstall
{
    public partial class MainForm : Form
    {
        private string selectedPath;
        private string networkPath;
        private List<string> selectedItems;
        private const string IpFilePath = "ips.txt";
        public MainForm()
        {
            InitializeComponent();
            LoadIpList();
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
                                    SendToConsole($"Suppression des éléments du dossier : {destinationSubDir}.");
                                    await Task.Run(() => removeAllFile(destinationSubDir));
                                }
                                    SendToConsole($"Copie du dossier {folderName} vers {destinationSubDir}");
                                await Task.Run(() => CopyDirectory(sourceSubDir, destinationSubDir));
                                SendToConsole($"Extraction de Quiz.zip");
                                await Task.Run(() => ZipFile.ExtractToDirectory(Path.Combine(destinationSubDir, "Quiz.zip"), destinationSubDir));
                                UpdateProgressBar();
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
                                    SendToConsole($"Suppression des éléments du dossier : {destinationSubDir}.");
                                    await Task.Run(() => removeAllFile(destinationSubDir));
                                }
                                SendToConsole($"Copie du dossier {folderName} vers {destinationSubDir}");
                                await Task.Run(() => CopyDirectory(sourceSubDir, destinationSubDir));

                                SendToConsole($"Extraction de PDFViewer.zip");
                                await Task.Run(() => ZipFile.ExtractToDirectory(Path.Combine(destinationSubDir, "PDFViewer.zip"), destinationSubDir));
                                UpdateProgressBar();
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
                                    SendToConsole($"Suppression des éléments du dossier : {destinationDir}.");
                                    await Task.Run(() => removeAllFile(destinationDir));
                                }
                                
                                SendToConsole($"Copie du dossier {folderName} vers {destinationDir}");
                                await Task.Run(() => CopyDirectory(sourceSubDir, destinationDir));
                                UpdateProgressBar();
                            }
                            
                            break;
                        case "Raccourci":
                            if (checkBoxCopieRaccourci.Checked == true)
                            {
                                await Task.Run(() => removeAllFile(destinationDir));
                                SendToConsole($"Copie du dossier {folderName} vers {destinationDir}");
                                await Task.Run(() => CopyDirectory(sourceSubDir, destinationDir));
                                UpdateProgressBar();
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

        private void UpdateProgressBar()
        {
            if (progressBar.InvokeRequired) // Vérifie si on est sur un thread différent
            {
                progressBar.Invoke(new Action(UpdateProgressBar));
            }
            else
            {
                progressBar.Value++;
            }
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

        private void LoadIpList()
        {
            if (File.Exists(IpFilePath))
            {
                string[] ips = File.ReadAllLines(IpFilePath);
                checkedListBoxPcSelected.Items.AddRange(ips);
            }
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
          
            string username = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            int numberMaxOfItem = 0;

            selectedItems = checkedListBoxPcSelected.CheckedItems.Cast<string>().ToList();
            
            foreach (string item in selectedItems)
            {
                numberMaxOfItem++;
            }
            initProgressBar();

            foreach (string item in selectedItems)
            {
                SendToConsole("*************************************************");
                SendToConsole($"Envoie des fichiers vers {item}");
                networkPath = @"\\" + item + "\\c$"; // Remplace par l'IP du PC distant \\Users\\Public\\Deskto
                try
                {
                    String valideConnection = await Task.Run(() => ConnexionToPC(username, password, item));

                    if (valideConnection != null) { 
                        SendToConsole(valideConnection);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur : {ex.Message}");
                    SendToConsole($"Erreur : {ex.Message}");
                }
            }
            
        }

        private String ConnexionToPC(String username, String password,String item) {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C net use {networkPath} /user:.\\{username} {password}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }; 

            if (System.IO.Directory.Exists(networkPath))
            {
                Console.WriteLine("Accès confirmé !");
                CopySpecificDirectories(selectedPath, item);
                return null;
            }
            else
            {
                Console.WriteLine("Accès refusé !");
                return "Accès refusé !";
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

        private async void buttonRestart_Click(object sender, EventArgs e)
        {
            selectedItems = checkedListBoxPcSelected.CheckedItems.Cast<string>().ToList();
            int numberOfIp = 0;
            foreach (string item in selectedItems)
            {
                numberOfIp++;
            }
            if (numberOfIp == 1)
            {
                foreach (string item in selectedItems)
                {
                    SendToConsole($"Tentative de redémarrage du pc : {item}");
                    String reply = await Task.Run(() => RestartRemotePC(item, textBoxLogin.Text, textBoxPassword.Text));
                    SendToConsole(reply);
                } 
            }
            else
            {
                SendToConsole("Veuillez sélectionner une seule ip.");
            }
        }

        public String RestartRemotePC(string ip, string username, string password)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C shutdown /r /m \\\\{ip} /t 10 /f",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(psi))
            {
                process.WaitForExit();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                if (!string.IsNullOrWhiteSpace(error))
                {
                    Console.WriteLine("Erreur : " + error);
                    return ("Erreur : " + error);
                }
                else
                {
                    Console.WriteLine($"Redémarrage du PC {ip} en cours...");
                    return ($"Redémarrage du PC {ip} en cours...");
                }
            }
        }

    }
}
