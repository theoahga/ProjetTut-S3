using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidFileManager.Logic
{
    public class Folder : StoredElement
    {
        private string folderName;

        public Folder(string n) : base(n)
        {

        }

        public StoredElement[] ListFolder()
        {
            return null;
        }

        public string FolderName
        {
            get { return folderName; }
            set
            {
                folderName = value;
            }
        }


    }
}
