using AndroidFileManager.Data;
using AndroidFileManager.Logic;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AndroidFileManager
{
    public class MyListViewModel
    {
        public ObservableCollection<StoredElement> listFilesDoc { get; set; }
        public Command LongPress { get; set; }
        

        public MyListViewModel(string path)
        {
            listFilesDoc = new ObservableCollection<StoredElement>();
            initialize(path);
        }


        public void initialize(string path)
        {
            string a = path;
            try
            {

                
                foreach (string pth in System.IO.Directory.GetDirectories(a))
                {
                    listFilesDoc.Add(new Folder(pth));
                }
                foreach (string pth in System.IO.Directory.GetFiles(a))
                {
                    listFilesDoc.Add(new Logic.File(pth));
                }
            }
            catch
            {
                
            }
        }

    }
}