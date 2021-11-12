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
            //listFilesDoc.Add("dede");
            listFilesDoc.Add("dede");
            //Louis le gros baiseur
        }

        private ObservableCollection<string> listFilesDoc { get; set; }
    }
}