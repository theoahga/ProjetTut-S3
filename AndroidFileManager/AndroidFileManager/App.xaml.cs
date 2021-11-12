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
            //MainPage = new MainPage();                         //Ouvre la page de menu principal
            //MainPage = new PageDetailDossier();                  //Ouvre la page de detail d'un dossier

            MainPage = new NavigationPage(new MainPage());
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
