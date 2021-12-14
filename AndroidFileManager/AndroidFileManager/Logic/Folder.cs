using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;


namespace AndroidFileManager.Logic
{
    [DataContract]
    public class Folder : StoredElement
    {
        [DataMember]private string folderName;

        public Folder(string n) 
        {
            folderName = n;
        }


        public override string Name 
        {
            get { return folderName; }
            set
            {
                folderName = value;
            }
        }

        public override string ShortName
        {
            get 
            {
                DirectoryInfo b = new DirectoryInfo(Name);
                return b.Name;
            }
        }

        public override string Image
        {
            get { return "AndroidFileManager/AndroidFileManager.Android/Resources/drawable/dossier.png"; }
        }

        public override string Type
        {
            get { return "folder"; }
        }

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


        public override void Remove()
        {
                Directory.Delete(this.Name);
        }

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

        public override void Move(string dest)
        {
            Directory.Move(this.Name, dest);
        }
    }
}
