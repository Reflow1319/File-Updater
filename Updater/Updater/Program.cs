using System;
using System.IO;
using System.Net;

namespace Updater
{
    public static class Program
    {
        private static void Main() {

            // Necessary paths and URLs.
            string startupPath = AppDomain.CurrentDomain.BaseDirectory;
            string revisionFile = startupPath + "Revision.txt";
            string hostFile = startupPath + "Host.txt";

            // Check the host file. If it does not exist, or the
            // specified url is blank, let the user know and close the updater.
            string baseURL = "";
            if (File.Exists(hostFile)) {
                baseURL = File.ReadAllText(hostFile);
            } else {
                File.WriteAllText(hostFile, "");
            }
            if (baseURL == "") {
                CloseProgram("Please write the host you are trying to receive an update from in your Host.txt file.");
            }

            // Check the revision file. If it does not exist,
            // leave the revision at 0 to signify a lack of files.
            int clientRevision = 0;
            if (File.Exists(revisionFile)) {
                clientRevision = Int32.Parse(File.ReadAllText(revisionFile));
            }

            // Download and convert the folder list into a byte stream and create 
            // the necessary folders.
            var folderList = new DataBuffer(DownloadFile(baseURL + "FolderList.dat"));
            int folderCount = folderList.ReadInt();
            for (int i = 0; i < folderCount; i++) {
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
            for (int i = 0; i < fileCount; i++) {
                string clientpath = fileList.ReadString();
                string serverpath = fileList.ReadString();
                int revision = fileList.ReadInt();

                // If the file already exists and the revision it was introduced in
                // is older than our current version, then continue to the next
                // file in the file list.
                if (File.Exists(startupPath + clientpath) && revision <= clientRevision) {
                    continue;
                }

                // If the file doesn't exist, or if the file exists but was 
                // introduced in a newer version than our current version, then download the file.
                Console.WriteLine("Downloading " + clientpath);
                client.DownloadFile(baseURL + serverpath, startupPath + clientpath);
            }

            // Store the current revision we installed, and terminate the program
            // with a message of success.
            File.WriteAllText(revisionFile, serverRevision.ToString());
            CloseProgram("Your software is up to date.");
        }

        private static byte[] DownloadFile(string url) {
            try {
                var request = FileWebRequest.Create(url);
                using (var response = request.GetResponse()) {
                    using (var stream = response.GetResponseStream()) {
                        using (var memory = new MemoryStream()) {
                            stream.CopyTo(memory);
                            return memory.ToArray();
                        }
                    }
                }
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }

            CloseProgram("Could not download the file at " + url);
            return null;
        }

        private static void CloseProgram(string msg) {
            Console.WriteLine(msg);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(false);
            Environment.Exit(1);
        }
    }
}
