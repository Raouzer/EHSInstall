using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Drawing;


namespace EHSInstall
{
    public partial class MainForm : Form
    {
        private string selectedPath;
        private string networkPath;
        private List<string> selectedItems;
        private const string IpFilePath = "ips.txt";
        private bool restartPCAndCopie = false;
        private String ipOfrestart;
        public MainForm()
        {
            InitializeComponent();
            LoadListView();
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
                    richTextBoxMainFolderPath.Text = selectedPath;
                    StartButton.Enabled = true;
                }
            }
        }

        private async Task CopySpecificDirectories(string sourceDir, string username, string password, string ip)
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
                            if (checkBoxCopieQuiz.Checked == true)
                            {
                                if (!Directory.Exists(destinationSubDir))
                                {
                                    Directory.CreateDirectory(destinationSubDir);
                                    SendToConsole("Le dossier" + destinationSubDir + " a été créé.", false);
                                }
                                else
                                {
                                    SendToConsole($"Suppression des éléments du dossier : {destinationSubDir}.", false);
                                    await Task.Run(() => removeAllFile(destinationSubDir, ip));
                                }

                                    
                                    SendToConsole($"Copie du dossier {folderName} vers {destinationSubDir}", false);
                                    await Task.Run(() => CopyDirectory(sourceSubDir, destinationSubDir));
                                    SendToConsole($"Extraction de Quiz.zip", false);
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
                                    SendToConsole("Le dossier" + destinationSubDir + " a été créé.", false);
                                }
                                else
                                {
                                    SendToConsole($"Suppression des éléments du dossier : {destinationSubDir}.", false);
                                    await Task.Run(() => removeAllFile(destinationSubDir, ip));
                                }

                                
                                    SendToConsole($"Copie du dossier {folderName} vers {destinationSubDir}", false);
                                    await Task.Run(() => CopyDirectory(sourceSubDir, destinationSubDir));

                                    SendToConsole($"Extraction de PDFViewer.zip", false);
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
                                    SendToConsole("Le dossier" + destinationDir + " a été créé.", false);
                                }
                                else
                                {
                                    SendToConsole($"Suppression des éléments du dossier : {destinationDir}.", false);
                                    await Task.Run(() => removeAllFile(destinationDir, ip));
                                }

                                    SendToConsole($"Copie du dossier {folderName} vers {destinationDir}", false);
                                    await Task.Run(() => CopyDirectory(sourceSubDir, destinationDir));
                                    UpdateProgressBar();
                                
                            }

                            break;
                        case "Raccourci":
                            if (checkBoxCopieRaccourci.Checked == true)
                            {
                                await Task.Run(() => removeAllFile(destinationDir,ip));

                                    SendToConsole($"Copie du dossier {folderName} vers {destinationDir}", false);
                                    await Task.Run(() => CopyDirectory(sourceSubDir, destinationDir));
                                    UpdateProgressBar();
                                
                            }
                            break;
                        default:

                            break;
                    }
                }
            }
            SendToConsole("Copie des fichier terminée.", false);
            restartPCAndCopie = false;
            ipOfrestart = "";
            DisconnexionFromPC(username, password, ip);

        }

        private void initProgressBar()
        {
            int checkCopie = 0;
            int numberSelectedPC = 0;
            progressBar.Value = 0;
            if (checkBoxCopiePDF.Checked == true)
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
        private async Task removeAllFile(String destinationDir,String ip)
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
                richTextBoxConsole.Invoke(new Action(() => SendToConsole($"Erreur : {ex.Message}", true)));
                restartPCAndCopie = true;
                ipOfrestart = ip;
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

        private async void StartButton_Click(object sender, EventArgs e)
        {

            string username = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            int numberMaxOfItem = 0;

            if (password != "")
            {
                selectedItems = listViewPcSelector.CheckedItems.Cast<ListViewItem>()
                                             .Select(item => item.Text)
                                             .ToList();

                foreach (string item in selectedItems)
                {
                    numberMaxOfItem++;
                }
                initProgressBar();

                foreach (string item in selectedItems)
                {

                    SendToConsole(networkPath, false);
                    try
                    {
                        await Task.Run(() => ConnexionToPC(username, password, item));

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erreur : {ex.Message}");
                        SendToConsole($"Erreur : {ex.Message}", true);
                    }
                }
                if (restartPCAndCopie) {
                    SendToConsole($"Le pc {ipOfrestart} doit être relancé  : {restartPCAndCopie} ", true);
                }
                
                if (restartPCAndCopie)
                {
                    await Task.Run(() => RestartRemotePC(ipOfrestart, textBoxLogin.Text, textBoxPassword.Text));
                    foreach (string item in selectedItems)
                    {

                        SendToConsole(networkPath, false);
                        try
                        {
                            await Task.Run(() => ConnexionToPC(username, password, item));

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erreur : {ex.Message}");
                            SendToConsole($"Erreur : {ex.Message}", true);
                        }
                    }
                }
            }
            else
            {
                SendToConsole("Vérifier vos informations de connection.", true);
            }


        }
        private void DisconnexionFromPC(String username, String password, String item)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C net use {networkPath} /delete /yes",
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

                Console.WriteLine(output);
                Console.WriteLine(error);
                SendToConsole($"Vous êtes déconnecté de {item}", false);
            }
        }


        private async Task ConnexionToPC(string username, string password, string item)
        {
            string networkPath = $"\\\\{item}\\C$"; // Construire correctement le chemin réseau
            richTextBoxConsole.Invoke(new Action(() => SendToConsole("*************************************************", false)));
            richTextBoxConsole.Invoke(new Action(() => SendToConsole($"Tentative de connexion vers {item}", false)));

            ProcessStartInfo psiDisconnect = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C net use {networkPath} /delete /yes",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using (Process process = Process.Start(psiDisconnect))
            {
                process.WaitForExit();
            }

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C net use {networkPath} /user:{username} {password}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            try
            {
                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit(); // Attendre la fin du processus

                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    // richTextBoxConsole.Invoke(new Action(() => SendToConsole(output)));
                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        richTextBoxConsole.Invoke(new Action(() => SendToConsole($"\n ERREUR: {error}", true)));
                    }
                }

                // Vérifier si l'accès est possible
                if (System.IO.Directory.Exists(networkPath))
                {
                    richTextBoxConsole.Invoke(new Action(() => SendToConsole("✅ Accès confirmé !", false)));
                    richTextBoxConsole.Invoke(new Action(() => SendToConsole($"Envoie des fichiers vers {item}", false)));
                    await CopySpecificDirectories(selectedPath, username, password, item);
                }
                else
                {
                    richTextBoxConsole.Invoke(new Action(() => SendToConsole("❌ Accès refusé !", true)));
                }
            }
            catch (Exception ex)
            {
                richTextBoxConsole.Invoke(new Action(() => SendToConsole($"Exception: {ex.Message}" , true)));
            }
        }


        private void SendToConsole(String data,bool Error)
        {

            if (Error)
            {
                // Changer la couleur du texte en rouge
                richTextBoxConsole.Invoke(new Action(() => richTextBoxConsole.SelectionColor = Color.Red));
            }
            else
            {
                // Changer la couleur du texte à la couleur par défaut (noir)
                richTextBoxConsole.Invoke(new Action(() => richTextBoxConsole.SelectionColor = Color.White));
            }

           
            richTextBoxConsole.Invoke(new Action(() => richTextBoxConsole.AppendText(data + "\n")));
            
            richTextBoxConsole.Invoke(new Action(() => richTextBoxConsole.SelectionStart = richTextBoxConsole.Text.Length));
           
            richTextBoxConsole.Invoke(new Action(() => richTextBoxConsole.ScrollToCaret()));
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewPcSelector.Items)
            {
                item.Checked = true; // Cocher chaque élément
            }
        }

        private void buttonDeselectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewPcSelector.Items)
            {
                item.Checked = false; // Décocher chaque élément
            }
        }

        private async void buttonRestart_Click(object sender, EventArgs e)
        {
            // Sélectionner les IPs qui ont été cochées
            selectedItems = listViewPcSelector.CheckedItems.Cast<ListViewItem>()
                                              .Select(item => item.Text)
                                              .ToList();
            int numberOfIp = selectedItems.Count;

            // Si des IPs sont sélectionnées
            if (numberOfIp != 0)
            {
                foreach (string item in selectedItems)
                {
                    // Attendre la fin de chaque redémarrage avant de passer à l'IP suivante
                    await Task.Run(() => RestartRemotePC(item, textBoxLogin.Text, textBoxPassword.Text));
                }
            }
            else
            {
                // Si aucune IP n'est sélectionnée
                SendToConsole("Veuillez sélectionner une adresse IP.", false);
            }
        }


        public async Task RestartRemotePC(string ip, string username, string password ){
            richTextBoxConsole.Invoke(new Action(() => SendToConsole("*************************************************", false)));
            richTextBoxConsole.Invoke(new Action(() => SendToConsole($"Redémarrage du PC : {ip}", false)));

            ProcessStartInfo psiConnect = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C net use {networkPath} /user:{username} {password}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(psiConnect))
            {
                process.WaitForExit();
            }

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
                    SendToConsole("Erreur : " + error, true);
                }
                else
                {
                    // 💡 Attente initiale sans bloquer l'UI
                    int initialWaitTime = 70000;
                    richTextBoxConsole.Invoke(new Action(() => SendToConsole($"Attente de {initialWaitTime / 1000} sec pour le redémarrage...", false)));
                    await Task.Run(() => Task.Delay(initialWaitTime)); // 🔥 Remplace Thread.Sleep()

                    int maxAttempts = 12;
                    int waitTime = 10000;

                    for (int attempt = 1; attempt <= maxAttempts; attempt++)
                    {
                        if (IsRemoteAdminShareAccessible(ip))
                        {
                            richTextBoxConsole.Invoke(new Action(() => SendToConsole($"{ip} est de nouveau disponible !", false)));
                            return;
                        }

                        int remainingTime = (maxAttempts - attempt) * (waitTime / 1000);
                        richTextBoxConsole.Invoke(new Action(() => SendToConsole($"Tentative {attempt}/{maxAttempts} - Attente de {remainingTime} sec restantes...", false)));

                        await Task.Run(() => Task.Delay(waitTime));
                    }

                    richTextBoxConsole.Invoke(new Action(() => SendToConsole($"{ip} n'est pas joignable après plusieurs tentatives.", false)));
                }
            }
        }


        public bool IsRemoteAdminShareAccessible(string ip)
        {
            try
            {
                string networkPath = $"\\\\{ip}\\ADMIN$";
                return Directory.Exists(networkPath);
            }
            catch
            {
                return false;
            }
        }


        private void buttonMajList_Click(object sender, EventArgs e)
        {
            LoadListView();
        }
        private void LoadListView()
        {
            listViewPcSelector.Items.Clear();
            listViewPcSelector.Groups.Clear();
            listViewPcSelector.Columns.Clear();

            listViewPcSelector.View = View.Details;
            listViewPcSelector.CheckBoxes = true;
            listViewPcSelector.FullRowSelect = true;
            listViewPcSelector.MultiSelect = true;

            listViewPcSelector.Columns.Add("IP", -3, HorizontalAlignment.Left);
            listViewPcSelector.HeaderStyle = ColumnHeaderStyle.None;
            listViewPcSelector.Columns[0].Width = 268;

            int SelectedGroup = -1;

            if (!File.Exists("ips.txt"))
            {
                SendToConsole("Le fichier 'ips.txt' n'existe pas.", true);
                return;
            }

            string[] lines = File.ReadAllLines("ips.txt");

            foreach (string line in lines)
            {
                try
                {
                    if (!line.Contains("."))
                    {
                        ListViewGroup groupe = new ListViewGroup(line);
                        listViewPcSelector.Groups.Add(groupe);
                        SelectedGroup++;
                    }
                    else
                    {
                        ListViewItem item = new ListViewItem(line);

                        if (SelectedGroup >= 0 && SelectedGroup < listViewPcSelector.Groups.Count)
                        {
                            item.Group = listViewPcSelector.Groups[SelectedGroup];
                            item.SubItems.Add("Description");
                            listViewPcSelector.Items.Add(item);
                        }
                        else
                        {
                            SendToConsole("Le groupe n'est pas correctement défini.", true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    SendToConsole("Erreur lors du traitement des données dans le fichier 'ips.txt'. Assurez-vous qu'il est bien formaté.", true);
                }
            }

            listViewPcSelector.Refresh();

            listViewPcSelector.ItemSelectionChanged += (sender, e) =>
            {
                e.Item.Checked = e.IsSelected;
            };

            listViewPcSelector.ItemChecked += (sender, e) =>
            {
                e.Item.Selected = e.Item.Checked;
            };

        }

        private void buttonFichierIP_Click(object sender, EventArgs e)
        {
            string filePath = "ips.txt";

            if (File.Exists(filePath))
            {
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            else
            {
                SendToConsole("Le fichier 'ips.txt' n'existe pas.", true);
            }
        }

        private void labelVersion_DoubleClick(object sender, EventArgs e)
        {
            textBoxPassword.Text = "GSK_2030_@128";
        }

        private void checkBoxCopieApp_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxCopieApp.Checked == true)
            {
                checkBoxCopiePDF.Checked = true;
                checkBoxCopiePDF.Enabled = false;
            }
            else
            {
                checkBoxCopiePDF.Enabled = true;
            }
                 
            
        }
    }
}
