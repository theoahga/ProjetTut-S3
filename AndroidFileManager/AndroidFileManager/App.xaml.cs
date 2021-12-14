using AndroidFileManager.Data;
using AndroidFileManager.Logic;
using AndroidFileManager.Storage;
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
            JsonStorage storage = new JsonStorage("/storage/emulated/0/data.json");
            Memory data = new Memory();
            storage.Save(data);
            MainPage = new NavigationPage(new listPage("/storage/emulated/0"));
            
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
