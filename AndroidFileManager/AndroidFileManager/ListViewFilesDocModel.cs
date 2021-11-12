using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ViewModel
{
    public class ListViewFilesDocModel: ContentPage
    {
        public ObservableCollection<string> FilesDoc { get; set; }

        public ListViewFilesDocModel()
        {
            FilesDoc = new ObservableCollection<string>();

            FilesDoc.Add("gud");
            FilesDoc.Add("bob");
        }
    }
}
