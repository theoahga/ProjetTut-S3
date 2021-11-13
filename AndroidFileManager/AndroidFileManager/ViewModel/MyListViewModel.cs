using AndroidFileManager.Data;
using AndroidFileManager.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Essentials;

namespace AndroidFileManager
{
    public class MyListViewModel
    {
        public ObservableCollection<MyListModel> listFilesDoc { get; set; }
        
        private GetPermissions permi;
        public MyListViewModel()
        {
            listFilesDoc = new ObservableCollection<MyListModel>();
            permi = new GetPermissions();
            initialize();
        }


        public void initialize()
        {
            try
            {

                permi.GetStoragePermissions();
                foreach (string pth in System.IO.Directory.GetDirectories("/storage/emulated/0"))
                {
                    listFilesDoc.Add(new MyListModel { Name = pth , Image = "/AndroidFileManager/AndroidFileManager.Android/Resources/drawable/dossier.png" });
                }
                foreach (string pth in System.IO.Directory.GetFiles("/storage/emulated/0"))
                {
                    listFilesDoc.Add(new MyListModel { Name = pth, Image = "/AndroidFileManager/AndroidFileManager.Android/Resources/drawable/autre.png" });
                }
            }
            catch
            {
                
            }
        }

        
    }
}