using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AndroidFileManager.Logic
{
    public class File : StoredElement
    {
        private string fileName;

        public File(string n)
        {
            fileName = n;
        }

        public override string Name
        {
            get { return fileName; }
            set
            {
                fileName = value;
            }
        }

        public override string ShortName
        {
            get 
            {
                FileInfo a = new FileInfo(Name);
                return  a.Name;
            }
        }
        
        public override string Type 
        {
            get { return "file"; }
        }

        public override string Image
        {
            get { return getImage(); }
        }

        public string getImage()
        {
            string ext = System.IO.Path.GetExtension(Name);
            string image = "";
            switch (ext)
            {
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



        public override void Remove()
        {
            System.IO.File.Delete(this.Name);
        }

        public override void Copy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            if (copySubDirs)
            {
                System.IO.File.Copy(sourceDirName, destDirName);
               
            }
        }

        public override void Move(string dest)
        {
            System.IO.File.Move(this.Name, dest);
        }
    }
}
