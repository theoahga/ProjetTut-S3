using AndroidFileManager.Data;
using AndroidFileManager.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Essentials;

namespace AndroidFileManager
{
    public class MyListViewModel_documents
    {
        public ObservableCollection<MyListModel> listFilesDoc { get; set; }

        private GetPermissions permi;

        public MyListViewModel_documents()
        {
            listFilesDoc = new ObservableCollection<MyListModel>();
            permi = new GetPermissions();
            initialize_documents();
        }


        public void initialize_documents()
        {
            try
            {

                permi.GetStoragePermissions();
                foreach (string pth in System.IO.Directory.GetDirectories("/storage/emulated/0/Documents"))
                {
                    listFilesDoc.Add(new MyListModel { Name = pth, Image = "/AndroidFileManager/AndroidFileManager.Android/Resources/drawable/dossier.png" });
                }
                foreach (string pth in System.IO.Directory.GetFiles("/storage/emulated/0/Documents"))
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