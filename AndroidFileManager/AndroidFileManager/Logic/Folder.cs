using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace AndroidFileManager.Logic
{
    // This class extends from the class StoredElement 
    public class Folder : StoredElement
    {
        // Attribute
        private string folderName;

        // The Folder class constructor
        public Folder(string n) 
        {
            folderName = n;
        }

        // The Name property (Long Path)
        public override string Name 
        {
            get { return folderName; }
            set
            {
                folderName = value;
            }
        }

        // The Name property (Short Path)
        public override string ShortName
        {
            get 
            {
                DirectoryInfo b = new DirectoryInfo(Name);
                return b.Name;
            }
        }

        // This function return the image path of a folder
        public override string Image
        {
            get { return "AndroidFileManager/AndroidFileManager.Android/Resources/drawable/dossier.png"; }
        }

        // This function return the type of this StoredElement
        public override string Type
        {
            get { return "folder"; }
        }


        // This function return the list of folders and files in the actual folder
        public StoredElement[] ListFolder()
        {
            List<StoredElement> e = new List<StoredElement>();

            foreach (string pth in System.IO.Directory.GetDirectories(Name))
            {
                e.Add(new Folder(pth));
            }

            foreach (string pth in System.IO.Directory.GetFiles(Name))
            {
                e.Add(new Logic.File(pth));
            }

            return e.ToArray();
        }

        // This function allows you to delete in cascade this actual folder
        public override void Remove()
        {
                Directory.Delete(this.Name);
        }

        // This function allows to create in phone internal folders this Folder object
        public void Create()
        {
            try
            {
                if (Directory.Exists(this.Name))
                {
                    Console.WriteLine("This file already exits!");
                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(this.Name);
                }
            }
            catch (Exception a)
            {
                Console.WriteLine("The process failed: {0}", a.ToString());
            }
        }

        // This function allows to copy a folder(with all its content) in a other folder
        public override void Copy(string sourceDirName, string destDirName, bool copySubDirs)
        {
 
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            DirectoryInfo[] dirs = dir.GetDirectories();
   
            Directory.CreateDirectory(destDirName);

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    Copy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        // This function allows to move this actual folder(with all its content) in a other folder
        public override void Move(string dest)
        {
            Directory.Move(this.Name, dest);
        }
    }
}
