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
        private StoredElement copyElement = null;
        private StoredElement moveElement = null;
        public listPage(string path_base, StoredElement elt, StoredElement elt2)
        {
            InitializeComponent();
            this.actualpath = path_base;
            this.copyElement = elt;
            this.moveElement = elt2;
            this.CheckCopy();
            MyListViewModel a = new MyListViewModel(path_base);
            BindingContext = a;
           
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
                    await Navigation.PushAsync(new listPage(storedElement.Name,this.copyElement,this.moveElement));
                }else if(storedElement.Type == "file")
                {
                    
                }
                
            }
            
        }

        private async void AddFolder(object sender, EventArgs e)
        {
            string nouveau = await DisplayPromptAsync("New Folder","What is the folder's name created ?");
            string path = this.actualpath + "/"+nouveau ;
            Folder newFolder = new Folder(path);
            newFolder.Create();
            BindingContext = new MyListViewModel(actualpath);
        }

        private async void Deleteclick(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Delete", "Do you really want to delete this element ?", "Yes", "No");
            if(answer == true)
            {
                var storedElement = ((MenuItem)sender).BindingContext as StoredElement;
                if (storedElement == null)
                    return;

                storedElement.Remove();
                BindingContext = new MyListViewModel(actualpath);
                await DisplayAlert("Alert", "The item has been deleted", "OK");
            } else
            {

            }
        }

        private void copyclick(object sender, EventArgs e)
        {
            var storedElement = ((MenuItem)sender).BindingContext as StoredElement;
            if (storedElement == null)
                return;
            this.copyElement = storedElement;
            this.CheckCopy();
        }

        private void moveclick(object sender, EventArgs e)
        {
            var storedElement = ((MenuItem)sender).BindingContext as StoredElement;
            if (storedElement == null)
                return;
            this.moveElement = storedElement;
            this.CheckCopy();
        }

        private async void copyclicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Copy", "Do you really want to copy this element ?", "Yes", "No");
            if (answer == true)
            {
                string a = this.actualpath +"/"+ this.copyElement.ShortName;
                if(a != this.copyElement.Name)
                { 
                    this.copyElement.Copy(this.copyElement.Name, a, true);
                    BindingContext = new MyListViewModel(actualpath);
                    this.copyElement = null;
                    this.CheckCopy();
                }
            }
            else
            {
                //popup
            }
            
        }

        private async void moveclicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Move", "Do you really want to move this element ?", "Yes", "No");
            if (answer == true)
            {
                string a = this.actualpath + "/" + this.moveElement.ShortName;
                if (a != this.moveElement.Name)
                {
                    this.moveElement.Move(a);
                    BindingContext = new MyListViewModel(actualpath);
                    this.moveElement = null;
                    this.CheckCopy();
                }
                else
                {
                    //popup
                }
            }
        }

        private void CheckCopy()
        {
            if(this.copyElement == null)
            {
                this.copybtn.IsVisible = false;
            }
            else
            {
                this.copybtn.IsVisible = true;
            }

            if (this.moveElement == null)
            {
                this.movebtn.IsVisible = false;
            }
            else
            {
                this.movebtn.IsVisible = true;
            }
        }
    }
}