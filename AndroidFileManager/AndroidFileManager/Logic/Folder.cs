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
            return null;
        }

        public override void Copy(StoredElement e)
        {
            throw new NotImplementedException();
        }

        public override Folder Paste(StoredElement e)
        {
            throw new NotImplementedException();
        }

        public override Folder Move(StoredElement e)
        {
            throw new NotImplementedException();
        }

        public override void Remove(StoredElement e)
        {
            throw new NotImplementedException();
        }

    }
}
