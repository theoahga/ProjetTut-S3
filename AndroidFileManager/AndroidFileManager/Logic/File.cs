using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidFileManager.Logic
{
    public class File : StoredElement
    {
        private string fileName;

        public File(string n) : base(n)
        {

        }

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
            }
        }

        //Louis à compléter pour obtenir les extentions 
        public string FileExtention
        {
            get { return null; }
            set
            {

            }
        }
        //a completer en fonction de l'extension

    }
}
