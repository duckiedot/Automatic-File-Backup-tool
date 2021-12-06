using System;
using System.Diagnostics;
using System.IO;

namespace Zad2
{
    public static class BackupData
    {
        public static bool BackupSuccesful { get; private set; }

        //keeps track of total backups created and later adds it to directory name like backup2303, backup4003 etc
        public static int BackupsCreated { get; private set; }

        //local directories 
        private static string source = @"h:\fakeServer\data";
        private static string backup = @"h:\fakeServer\receive\backup";

        //copies all files from source dir to an array called filesList, if the copy was succesful it calls SaveFiles()
        public static void CopyFiles()
        {
            DirectoryInfo sourceDirectory = new DirectoryInfo(source);
            try
            {
                FileInfo[] filesList = sourceDirectory.GetFiles();
                SaveFiles(filesList);
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg);
                return;
            }
            
        }

        //saves copied files in directory
        public static void SaveFiles(FileInfo[] filesList)
        {
            //creates directory coresponding to current amount of backups created, references to BackupsCreated prop
            Directory.CreateDirectory(backup + $"{BackupsCreated}");

            //tries to copy every file into the new dir
            foreach (FileInfo file in filesList)
            {
                try
                {
                    string tempPath = Path.Combine((backup + $"{BackupsCreated}"), file.Name);
                    Console.WriteLine(tempPath);
                    file.CopyTo(tempPath, false);
                }
                catch (Exception)
                {
                    BackupSuccesful = false;
                    return;
                }
                

            }
            //if exception isnt found and the program isnt returned early it adds another Backup to BackupsCreated prop
            BackupSuccesful = true;
            BackupsCreated++;
        }
    }
}
