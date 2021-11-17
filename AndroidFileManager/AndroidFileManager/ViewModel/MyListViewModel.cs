using AndroidFileManager.Data;
using AndroidFileManager.Logic;
using AndroidFileManager.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Essentials;

namespace AndroidFileManager
{
    public class MyListViewModel
    {
        public ObservableCollection<StoredElement> listFilesDoc { get; set; }
        
        private GetPermissions permi;

        public MyListViewModel()
        {
            //listFilesDoc = new ObservableCollection<MyListModel>();
            listFilesDoc = new ObservableCollection<StoredElement>();
            permi = new GetPermissions();
            permi.GetStoragePermissions();
            initialize();
        }


        public void initialize()
        {
            try
            {

                
                foreach (string pth in System.IO.Directory.GetDirectories("/storage/emulated/0"))
                {
                    listFilesDoc.Add(new Folder(pth));
                }
                foreach (string pth in System.IO.Directory.GetFiles("/storage/emulated/0"))
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