using AndroidFileManager.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace AndroidFileManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listPage : ContentPage
    {
        private string actualpath;
        public listPage(string path_base)
        {
            InitializeComponent();
            this.actualpath = path_base;
            BindingContext = new MyListViewModel(path_base);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs i)
        {
            ((ListView)sender).SelectedItem = null;
        }

        private async void ListView_ItemSelected(object sender, SelectedPositionChangedEventArgs e)
        {

            if (listViewFolder.SelectedItem is StoredElement)
            {
                var storedElement = listViewFolder.SelectedItem as StoredElement;
                if(storedElement.Type == "folder")
                {
                    await Navigation.PushAsync(new listPage(storedElement.Name));
                }else if(storedElement.Type == "file")
                {
                    
                }
                
            }
            
        }

        private async void AddFolder(object sender, EventArgs e)
        {
            string nouveau = await DisplayPromptAsync("Nouveau dossier","Quel est le nom de votre nouveau dossier ?");
            string path = this.actualpath + "/"+nouveau ;
            try
            {
                if (Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory("/storage/emulated/0/exists");
                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }
            }
            catch (Exception a)
            {
                Console.WriteLine("The process failed: {0}", a.ToString());
            }
            BindingContext = new MyListViewModel(actualpath);
        }
    }
}