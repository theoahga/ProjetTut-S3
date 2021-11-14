using AndroidFileManager.Models;
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
        public listPage()
        {
            InitializeComponent();         
            
            BindingContext = new MyListViewModel();
        }

        async void click_open_file(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageDetailDossier());
        }

    }
}