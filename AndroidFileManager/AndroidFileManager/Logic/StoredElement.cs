using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AndroidFileManager.Logic
{
    public class StoredElement
    {

        private string name;


        public StoredElement(string n)
        {
            Name = n;

        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        public string ShortName
        {
            get
            {
                string shortname = "";
                if (this.GetType() == "fichier")
                {
                    FileInfo a = new FileInfo(Name);
                    shortname = a.Name;
                }
                else if (this.GetType() == "dossier")
                {
                    DirectoryInfo b = new DirectoryInfo(Name);
                    shortname = b.Name;
                }
                return shortname;
            }
        }

        public string Image
        {
            get { return getImage(); }
        }
        public string getImage()
        {
            string ext = System.IO.Path.GetExtension(Name);
            string image = "";
            switch (ext)
            {
                case "":
                    image = "AndroidFileManager/AndroidFileManager.Android/Resources/drawable/dossier.png";
                    break;
                case ".pdf":
                    image = "AndroidFileManager/AndroidFileManager.Android/Resources/drawable/pdf.png";
                    break;
                default:
                    image = "AndroidFileManager/AndroidFileManager.Android/Resources/drawable/autre.png";
                    break;
            }


            return image;
        }

        public void Copy(StoredElement e)
        {

        }

        public Folder Paste(StoredElement e)
        {
            return null;
        }

        public Folder Move(StoredElement e)
        {
            return null;
        }


        public void Remove(StoredElement e)
        {

        }

        public string GetType()
        {
            string p = "fichier";
            if (Path.GetExtension(Name)=="")
            {
                p = "dossier";
            }
            return p;
        }

    }
}
