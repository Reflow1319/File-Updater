using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Timers;
using System.Threading;
using MySql.Data.MySqlClient;

namespace ODBS_Updater
{
    public partial class Form1 : Form
    {
        string startupPath = AppDomain.CurrentDomain.BaseDirectory;
        string settings;
        string[] setarry;
        //private string conn;
       // private MySqlConnection connect;

        public Form1()
        {
            InitializeComponent();

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            settings = startupPath + "settings.txt";
            setarry = File.ReadAllLines("settings.txt");
            this.Text = setarry[7];
            string revisionFile = startupPath + "Revision.txt";
            current.Text = "Current Version: " + File.ReadAllText(revisionFile);
            this.web.Navigate(setarry[5]);
            this.onstat.Navigate(setarry[9]);

            string hostFile = startupPath + "Host.txt";

            string baseURL = File.ReadAllText(hostFile);
            // Download and convert the file list into a byte stream.
            var fileList = new DataBuffer(DownloadFile(baseURL + "FileList.dat"));

            // Get the current product revision as determined by the FileIndexer
            // by the number of patch folders, and store it for later use.
            int serverRevision = fileList.ReadInt();

            if (serverRevision == Int32.Parse(File.ReadAllText(revisionFile)) )
            {
                up.Text = "PLAY";
            }else {
                up.Text = "UPDATE";
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void up_Click(object sender, EventArgs e)
        {
            if (up.Text == "UPDATE")
            {
                // Necessary paths and URLs.
                string startupPath = AppDomain.CurrentDomain.BaseDirectory;
                string revisionFile = startupPath + "Revision.txt";
                string hostFile = startupPath + "Host.txt";
                stat.Text = "Status: UPDATING";

                // Check the host file. If it does not exist, or the
                // specified url is blank, let the user know and close the updater.
                string baseURL = "";

                if (File.Exists(hostFile))
                {
                    baseURL = File.ReadAllText(hostFile);
                }
                else
                {
                    File.WriteAllText(hostFile, "");
                }
                if (baseURL == "")
                {
                    CloseProgram("Please write the host you are trying to receive an update from in your Host.txt file.");
                }

                // Check the revision file. If it does not exist,
                // leave the revision at 0 to signify a lack of files.
                int clientRevision = 0;
                if (File.Exists(revisionFile))
                {
                    clientRevision = Int32.Parse(File.ReadAllText(revisionFile));
                }


                // Download and convert the folder list into a byte stream and create 
                // the necessary folders.
                var folderList = new DataBuffer(DownloadFile(baseURL + "FolderList.dat"));
                int folderCount = folderList.ReadInt();
                for (int i = 0; i < folderCount; i++)
                {
                    Directory.CreateDirectory(startupPath + folderList.ReadString());
                }

                // Download and convert the file list into a byte stream.
                var fileList = new DataBuffer(DownloadFile(baseURL + "FileList.dat"));

                // Get the current product revision as determined by the FileIndexer
                // by the number of patch folders, and store it for later use.
                int serverRevision = fileList.ReadInt();

                // Create a webclient for downloading files and instantly saving them
                // onto the disk.
                var client = new WebClient();

                // Loop through the file list and retrieve information about the required files.
                int fileCount = fileList.ReadInt();
                for (int i = 0; i < fileCount; i++)
                {
                    string clientpath = fileList.ReadString();
                    string serverpath = fileList.ReadString();
                    int revision = fileList.ReadInt();
                    int j = 1 + i;
                    pro.Text = "Progress: " + j + "/" + fileCount.ToString();

                    // If the file already exists and the revision it was introduced in
                    // is older than our current version, then continue to the next
                    // file in the file list.
                    if (File.Exists(startupPath + clientpath) && revision <= clientRevision)
                    {
                        continue;
                    }

                    // If the file doesn't exist, or if the file exists but was 
                    // introduced in a newer version than our current version, then download the file.
                    Console.WriteLine("Downloading " + clientpath);

                    progress.Increment(10);

                    client.DownloadFile(baseURL + serverpath, startupPath + clientpath);
                    // Task.Delay(300);
                }


                // Store the current revision we installed, and terminate the program
                // with a message of success.
                File.WriteAllText(revisionFile, serverRevision.ToString());

                CloseProgram("Your software is up to date.");

                stat.Text = "Status: DONE";
                //current.Text = "Current Version: " + clientRevision.ToString();
                current.Text = "Current Version: " + File.ReadAllText(revisionFile);
                up.Text = "PLAY";
            }
            else
            {
                try
                {

                    Process.Start(setarry[1]);
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(setarry[3]);
                    stat.Text = "Status: Error Opening Game";
                }
            }

        }

        private void progress_Click(object sender, EventArgs e)
        {

        }

        private void play_Click(object sender, EventArgs e)
        {
           
                Process.Start(setarry[11]);
            
            
        }

        private static byte[] DownloadFile(string url)
        {
            try
            {
                var request = FileWebRequest.Create(url);
                using (var response = request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var memory = new MemoryStream())
                        {
                            stream.CopyTo(memory);
                            return memory.ToArray();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            CloseProgram("Could not download the file at " + url);
            return null;
        }

        private static void CloseProgram(string msg)
        {

            Console.WriteLine(msg);
            Console.WriteLine("Press any key to continue...");

            //Console.Read();
            //Console.ReadKey(false);

           // Environment.Exit(1);
        }

        //private void db_connection()
        //{
        //    try
        //    {
        //        conn = "Server=so1.infinitysrv.com;Database=xbytex10_test;Uid=xbytex10_admin;Pwd=114690;";
        //        connect = new MySqlConnection(conn);
        //        connect.Open();
        //    }
        //    catch (MySqlException e)
        //    {
        //        throw;
        //    }
        //}

        //private bool validate_login(string user, string pass)
        //{
        //    db_connection();
        //    MySqlCommand cmd = new MySqlCommand();
        //    string hpass;
           
        //    cmd.CommandText = "Select * from members where username=@user and password=@pass";

        //    cmd.CommandText = "Select * from members where username=@user ";
        //    pass = cmd.ExecuteReader().ToString();
        //    MessageBox.Show(pass);
        //    hpass = "";

        //    cmd.Parameters.AddWithValue("@user", user);
        //    cmd.Parameters.AddWithValue("@pass", hpass);
        //    cmd.Connection = connect;
        //    MySqlDataReader login = cmd.ExecuteReader();
        //    if (login.Read())
        //    {
        //        connect.Close();
        //        return true;
        //    }
        //    else
        //    {
        //        connect.Close();
        //        return false;
        //    }
        //}

        //private void submit_Click_1(object sender, EventArgs e)
        //{



        //    string user = username.Text;
        //    string pass = password.Text;
        //    if (user == "" || pass == "")
        //    {
        //        MessageBox.Show("Empty Fields Detected ! Please fill up all the fields");
        //        return;
        //    }
        //    bool r = validate_login(user, pass);
        //    if (r)
        //        MessageBox.Show("Correct Login Credentials");
        //    else
        //        MessageBox.Show("Incorrect Login Credentials");
        //}
    }
}
