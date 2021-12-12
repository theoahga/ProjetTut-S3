using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AndroidFileManager.Logic
{
    public class Folder : StoredElement
    {
        private string folderName;

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

        public override void Copy()
        {
            throw new NotImplementedException();
        }

        public override Folder Paste()
        {
            throw new NotImplementedException();
        }

        public override Folder Move(StoredElement e)
        {
            throw new NotImplementedException();
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

    }
}
