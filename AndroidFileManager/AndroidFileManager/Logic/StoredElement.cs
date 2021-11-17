using System;
using System.Collections.Generic;
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

        public string ShortName(StoredElement e)
        {
            return null;
        } 


    }
}
