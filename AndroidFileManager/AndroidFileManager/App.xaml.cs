using AndroidFileManager.Data;
using AndroidFileManager.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidFileManager
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            GetPermissions permi = new GetPermissions();
            permi.GetStoragePermissions();
            MainPage = new NavigationPage(new listPage("/storage/emulated/0",null,null));
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
