using System;

namespace ViewModel
{
    public class MyBindingObject
    {
        public ObservableCollection<string> FilesDoc { get; set; }

        public MyBindingObject()
        {
            FilesDoc = new ObservableCollection<string>();

            FilesDoc.Add("gud");
            FilesDoc.Add("bob");
        }
    }
}
