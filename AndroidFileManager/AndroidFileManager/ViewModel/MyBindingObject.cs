using System.Collections.ObjectModel;

namespace AndroidFileManager
{
    public class MyBindingObject
    {
        public MyBindingObject()
        {
            listFilesDoc = new ObservableCollection<string>();

            listFilesDoc.Add("dede");
            listFilesDoc.Add("dede");
            listFilesDoc.Add("dede");
            listFilesDoc.Add("dede");
            listFilesDoc.Add("dede");
            listFilesDoc.Add("dede");
        }

        private ObservableCollection<string> listFilesDoc { get; set; }
    }
}