using AndroidFileManager.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidFileManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listPage : ContentPage
    {
        public listPage(string path_base)
        {
            InitializeComponent();
            BindingContext = new MyListViewModel(path_base);
        }

        async void click_open_file(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageDetailDossier());
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

                await Navigation.PushAsync(new listPage(storedElement.Name));
            }
            
        }
    }
}