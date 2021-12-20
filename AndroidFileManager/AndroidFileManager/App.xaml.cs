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
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/data.json";
            JsonStorage storage = new JsonStorage(path);
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
