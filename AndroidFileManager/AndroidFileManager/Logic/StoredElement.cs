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

                case ".css":
                    image = "AndroidFileManager/AndroidFileManager.Android/Resources/drawable/css.png";
                    break;

                case ".xlsx":
                    image = "AndroidFileManager/AndroidFileManager.Android/Resources/drawable/excel.png";
                    break;

                case ".html":
                    image = "AndroidFileManager/AndroidFileManager.Android/Resources/drawable/html.png";
                    break;

                case ".jpg":
                    image = "AndroidFileManager/AndroidFileManager.Android/Resources/drawable/jpg.png";
                    break;

                case ".js":
                    image = "AndroidFileManager/AndroidFileManager.Android/Resources/drawable/js.png";
                    break;

                case ".mp3":
                    image = "AndroidFileManager/AndroidFileManager.Android/Resources/drawable/mp3.png";
                    break;

                case ".mp4":
                    image = "AndroidFileManager/AndroidFileManager.Android/Resources/drawable/mp4.png";
                    break;

                case ".pdf":
                    image = "AndroidFileManager/AndroidFileManager.Android/Resources/drawable/pdf.png";
                    break;

                case ".php":
                    image = "AndroidFileManager/AndroidFileManager.Android/Resources/drawable/php.png";
                    break;

                case ".png":
                    image = "AndroidFileManager/AndroidFileManager.Android/Resources/drawable/png.png";
                    break;

                case ".pptx":
                    image = "AndroidFileManager/AndroidFileManager.Android/Resources/drawable/powerpoint.png";
                    break;

                case ".ods":
                    image = "AndroidFileManager/AndroidFileManager.Android/Resources/drawable/tableur.png";
                    break;

                case ".odt":
                    image = "AndroidFileManager/AndroidFileManager.Android/Resources/drawable/texte.png";
                    break;

                case ".txt":
                    image = "AndroidFileManager/AndroidFileManager.Android/Resources/drawable/txt.png";
                    break;

                case ".docx":
                    image = "AndroidFileManager/AndroidFileManager.Android/Resources/drawable/word.png";
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
