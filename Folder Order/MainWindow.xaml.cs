using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ookii.Dialogs.Wpf;


namespace Folder_Order
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class ItemInList
        {
            public string opath { get; set; }
            public string dpath { get; set; }
        }

        public MainWindow()
        {
            logcreator("Inizializzazione programma.");
            CreateListFile();
            InitializeComponent();
            logcreator("Caricamento files necessari.");
            load_into_folders_box();
            populate();
            logcreator("Programma inizializzato.");
        }

        public string global_path;

        private bool CreateListFile()
        {
            try
            {
                logcreator("Inizio controllo esistenza file elenco cartelle.");
                if (!File.Exists("folders.txt"))
                {
                    StreamWriter folderslist;
                    folderslist = new StreamWriter("folders.txt");
                    folderslist.WriteLine("Anime");
                    folderslist.WriteLine("Musica");
                    folderslist.WriteLine("Giochi");
                    folderslist.WriteLine("Programmi");
                    folderslist.WriteLine("Libri");
                    folderslist.WriteLine("Film");
                    logcreator("File non esistente, creato.");
                    folderslist.Close();
                    return true;
                }
                else
                {
                    logcreator("File esistente.");
                    return true;
                }
            }
            catch (Exception e)
            {
                logcreator("Errore durante creazione file. Descrizione: "+ e.ToString());
                return false;
            }
        }

        private bool AppendListFile(string text)
        {
            try
            {
                logcreator("Inizio aggiunta valore '" + text + "' nel file.");
                StreamWriter folderslist;
                folderslist = File.AppendText("folders.txt");
                folderslist.WriteLine(text);
                folderslist.Close();
                logcreator("Fine aggiunta valore '" + text + "' nel file.");
                return true;
            }
            catch (Exception e)
            {
                logcreator("Errore durante aggiornamento file. Descrizione: " + e.ToString());
                return false;
            }
        }

        private void logcreator(string text)
        {
            StreamWriter log;
            if (!File.Exists("logfile.txt"))
            {
              log = new StreamWriter("logfile.txt");
            }
            else
            {
              log = File.AppendText("logfile.txt");
            }

            // Write to the file:
            log.WriteLine(DateTime.Now);
            log.WriteLine(text);
            log.WriteLine();
            // Close the stream:
            log.Close();
        }

        private bool load_into_folders_box()
        {
            try
            {
                logcreator("Inizio caricamento elementi in C_List.");
                StreamReader foldersfile;
                string line;
                int counter = 0;
                foldersfile = new StreamReader("folders.txt");
                while ((line = foldersfile.ReadLine()) != null)
                {
                    if (line != "")
                    {
                        C_List.Items.Add(line);
                        counter++;
                    }
                }
                C_List.SelectedIndex = 0;
                logcreator("Caricamento completato. Aggiunti " + counter.ToString() + " elementi.");
                return true;
            }
            catch (Exception e)
            {
                logcreator("Errore durante lettura file. Descrizione: " + e.ToString());
                return false;
            }
        }

        private bool populate()
        {
            try
            {
                logcreator("Inizio popolamento cartelle.");
                int counter = 0;
                var dialogo = new VistaFolderBrowserDialog();
                dialogo.ShowDialog();
                global_path = dialogo.SelectedPath;
                string[] filePaths = Directory.GetDirectories(@global_path);
                foreach (string paths in filePaths)
                {
                    var pathsPart = paths.Split(System.IO.Path.DirectorySeparatorChar);
                    string path = pathsPart[pathsPart.Length - 1].ToString();
                    if (CheckList(path))
                    {
                        LV_Folders.Items.Add(new ItemInList { opath = path, dpath = "No" });
                        counter++;
                    }
                }
                logcreator("Popolamento completato. Aggiunte " + counter + " cartelle.");
                return true;
            }
            catch (Exception e)
            {
                logcreator("Errore durante popolamento cartelle. Descrizione: " + e.ToString());
                return false;
            }
        }

        private void B_Ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                logcreator("Inizio aggiornamento lista.");
                if (R_List.IsChecked == true)
                {
                    logcreator("Aggiornando con valore trovato in C_List.");
                    ItemInList dpath_final = new ItemInList();
                    dpath_final = (ItemInList)LV_Folders.SelectedItem;
                    if (dpath_final != null)
                    {
                        dpath_final.dpath = C_List.SelectedValue.ToString();
                        LV_Folders.Items.Refresh();
                    }
                }
                else if (R_Text.IsChecked == true)
                {
                    if (T_FolderName.Text != "")
                    {
                        logcreator("Aggiornando con valore non trovato in C_List.");
                        ItemInList dpath_final = new ItemInList();
                        dpath_final = (ItemInList)LV_Folders.SelectedItem;
                        if (dpath_final != null)
                        {
                            dpath_final.dpath = T_FolderName.Text;
                            LV_Folders.Items.Refresh();
                        }
                        MessageBoxResult result = MessageBox.Show("Vuoi aggiungere " + T_FolderName.Text + " alla lista delle cartelle?",
                                                                "Attenzione.",
                                                                MessageBoxButton.YesNo,
                                                                MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            logcreator("Inizio aggiunta valore in folders.txt");
                            AppendListFile(T_FolderName.Text);
                            C_List.Items.Add(T_FolderName.Text);
                            R_List.IsChecked = true;
                            C_List.SelectedItem = C_List.Items.GetItemAt(C_List.Items.Count - 1);
                            logcreator("Aggiunta valore in folders.txt completata");
                        }
                        T_FolderName.Text = "";
                        logcreator("Aggiornamento valore completato.");
                    }
                    else
                    {
                        MessageBox.Show("Attenzione!\nNon hai inserito nulla!", "Attenzione.", MessageBoxButton.OK, MessageBoxImage.Error);
                        logcreator("Tentativo di aggiungere un valore nullo alla lista.");
                    }
                }
            }
            catch (Exception a)
            {
                logcreator("Errore durante aggiornamento lista. Descrizione: " + a.ToString());
            }
        }

        private void B_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                logcreator("Inizio annullamento.");
                T_FolderName.Text = "";
                ItemInList dpath_final = new ItemInList();
                dpath_final = (ItemInList)LV_Folders.SelectedItem;
                if (dpath_final != null)
                {
                    dpath_final.dpath = "No";
                    LV_Folders.Items.Refresh();
                }
                C_List.SelectedIndex = 0;
                logcreator("Annullamento completato.");
            }
            catch (Exception a)
            {
                logcreator("Errore durante annullamento. Descrizione: " + a.ToString());
            }
        }

        private void B_Start_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Sei sicuro di voler spostare queste cartelle?\nÈ un'azione che non può essere annullata!",
                "Attenzione!!",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {

                try
                {
                    logcreator("Inizio spostamento cartelle.");
                    int number_of_folders = LV_Folders.Items.Count;
                    int i;
                    PB_Progress.Maximum = number_of_folders;
                    PB_Progress.Value = 2;
                    for (i = 0; i < number_of_folders; i++)
                    {
                        PB_Progress.Value = i;
                        L_Status.Content = "Cartella " + i.ToString() + " di " + number_of_folders.ToString();
                        ItemInList itemlist = (ItemInList)LV_Folders.Items[i];
                        if (itemlist.dpath != "No")
                            MoveAndCreate(itemlist.opath, itemlist.dpath);
                    }
                    L_Status.Content = "Cartella " + i.ToString() + " di " + number_of_folders.ToString();
                    logcreator("Fine spostamento cartelle.");
                    L_Status.Content = "In attesa...";
                    PB_Progress.Value = 1;
                }
                catch (Exception a)
                {
                    logcreator("Errore durante spostamento cartelle. Descrizione: " + a.ToString());
                }
            }
        }

        private bool MoveAndCreate(string original_folder, string destination_folder)
        {
            try
            {
                B_Ok.IsEnabled = false;
                logcreator("Inizio spostamento cartella " + original_folder + " a " + destination_folder + ".");
                string or_folder = global_path + System.IO.Path.DirectorySeparatorChar + original_folder;
                string path_folder = global_path + System.IO.Path.DirectorySeparatorChar + destination_folder;
                string des_folder = global_path + System.IO.Path.DirectorySeparatorChar + destination_folder + System.IO.Path.DirectorySeparatorChar + original_folder;
                if (!Directory.Exists(path_folder))
                {
                    System.IO.Directory.CreateDirectory(path_folder);
                }
                System.IO.Directory.Move(or_folder, des_folder);
                logcreator("Fine spostamento cartella.");
                B_Ok.IsEnabled = true;
                return true;
            }
            catch (Exception e)
            {
                logcreator("Errore durante spostamento cartella" + original_folder + " a " +destination_folder+". Descrizione: " + e.ToString());
                return false;
            }
        }

        private bool CheckList(string text)
        {
            int i = 0;
            int counter = 0;
            int num = C_List.Items.Count;
            if (text != "$RECYCLE.BIN")
            {
                for (i = 0; i < num; i++)
                {
                    if (text != C_List.Items[i].ToString())
                    {
                        counter++;
                    }
                }
            }
            if (counter == num)
                return true;
            else
                return false;
        }

        private void W_Main_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            logcreator("Chiudendo il programma...");
        }

        private void menuItem_Property_Click(object sender, RoutedEventArgs e)
        {
            ItemInList current_item = new ItemInList();
            current_item = (ItemInList)LV_Folders.SelectedItem;
            try
            {
                logcreator("Inizio processo di proprietà.");
                string path = global_path + System.IO.Path.DirectorySeparatorChar + current_item.opath;
                DirectoryInfo dir = new DirectoryInfo(path);

                int fCount = Directory.GetFiles(path, "*", SearchOption.AllDirectories).Length;

                MessageBox.Show("Dimensione cartella (approssimativo): " + Size(DirSize(dir)) + "\n" +
                                "Numero files in cartella: " + fCount.ToString(),
                                "Proprietà cartella " + current_item.opath,
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                logcreator("Fine processo di proprietà.");
            }
            catch (Exception a)
            {
                logcreator("Errore processamento proprietà della cartella " + current_item.opath + ". Descrizione: " + a.ToString());
            }
        }

        public static long DirSize(DirectoryInfo d)
        {
            long Size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                Size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                Size += DirSize(di);
            }
            return (Size);
        }

        public string Size(long dirsize)
        {
            if (dirsize < 1024)
                return dirsize.ToString() + " bytes.";
            else if (dirsize >= 1024 && dirsize < 1048576)
                return (dirsize / 1024).ToString() + " KB.";
            else if (dirsize >= 1048576 && dirsize < 1073741824)
                return (dirsize / 1024 / 1024).ToString() + " MB.";
            else if (dirsize >= 1073741824)
                return (dirsize / 1024 / 1024 / 1024).ToString() + " GB.";
            else
                return dirsize.ToString();
        }

        private void menuItem_Remove_Click(object sender, RoutedEventArgs e)
        {
            ItemInList current_item = new ItemInList();
            current_item = (ItemInList)LV_Folders.SelectedItem;
            try
            {
                logcreator("Inizio eliminazione elemento " + current_item.opath + ".");
                MessageBoxResult result = MessageBox.Show("Sei sicuro di voler rimuovere " + current_item.opath + " dalla lista?",
                                                                    "Attenzione.",
                                                                    MessageBoxButton.YesNo,
                                                                    MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    LV_Folders.Items.Remove(current_item);
                }
                logcreator("Fine eliminazione elemento " + current_item.opath + ".");
            }
            catch (Exception a)
            {
                logcreator("Errore eliminazione elemento " + current_item.opath + ". Descrizione: " + a.ToString());
            }
        }
    }
}
