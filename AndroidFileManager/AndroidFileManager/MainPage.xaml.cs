using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;




namespace AndroidFileManager
{
    public partial class MainPage : ContentPage
    {
        private ListView listview1;
        private Button button1;
        private List<string> files;

        private readonly string[] sourceItems = new[]
        {
            "su","dih","khkdiz","ufvuf","vydv"
        };

        public ObservableCollection<string> MyItems { get; set; }
        public MainPage()
        {
            
            InitializeComponent();
            MyItems = new ObservableCollection<string>(sourceItems);
            BindingContext = this;
        }

        /*private void Documents_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageDetailDossier());
        }*/

    }
}
