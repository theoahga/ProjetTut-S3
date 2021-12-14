using AndroidFileManager.Logic;
using AndroidFileManager.Storage;
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
        private Memory data;
        private iStorage storage;
        public listPage(string path_base)
        {
            InitializeComponent();
            this.actualpath = path_base;          
        }

        // Load and refresh the page
        public void initialize()
        {
            this.storage = new JsonStorage("/storage/emulated/0/data.json");
            this.data = this.storage.Load();
            this.CheckCopy();
            MyListViewModel a = new MyListViewModel(this.actualpath);
            BindingContext = a;
        }

        // Set the selected background to unvisible
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs i)
        {
            ((ListView)sender).SelectedItem = null;
        }


        // Open new page when you click on a listview element 
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
        

        // Button addFolder
        private async void AddFolder(object sender, EventArgs e)
        {
            string nouveau = await DisplayPromptAsync("New Folder","What is the folder's name created ?");
            string path = this.actualpath + "/"+nouveau ;
            Folder newFolder = new Folder(path);
            newFolder.Create();
            BindingContext = new MyListViewModel(actualpath);
        }


        // Item Menu : delete
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


        // Item Menu : copy
        private void copyclick(object sender, EventArgs e)
        {
            // Value recovery 
            var storedElement = ((MenuItem)sender).BindingContext as StoredElement;
            if (storedElement == null)
                return;

            // Save copyElement in storage
            this.data.CopyElementPath = storedElement;
            this.storage.save(this.data);

            // Button Refresh
            this.CheckCopy();
        }


        // Item Menu : move
        private void moveclick(object sender, EventArgs e)
        {
            // Value recovery
            var storedElement = ((MenuItem)sender).BindingContext as StoredElement;
            if (storedElement == null)
                return;

            // Save copyElement in storage
            this.data.MoveElementPath = storedElement;
            this.storage.save(this.data);

            // Button Refresh
            this.CheckCopy();
        }


        // On button copy 
        private async void copyclicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Copy", "Do you really want to copy this element ?", "Yes", "No");
            if (answer == true)
            {
                // Value recovery
                StoredElement copyElement = this.data.CopyElementPath;

                // New string to dest path
                string a = this.actualpath +"/"+ copyElement.ShortName;
                if(a != copyElement.Name)
                { 
                    
                    copyElement.Copy(copyElement.Name, a, true);
                    

                    // Reset Value
                    this.data.CopyElementPath = null;
                    this.storage.save(data);

                    // Refresh page & button
                    BindingContext = new MyListViewModel(actualpath);
                    this.CheckCopy();
                }
                else
                {
                    //popup : fichier/dossier déja existant dans ce chemin
                }
            }
            
            
        }


        // On button move
        private async void moveclicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Move", "Do you really want to move this element ?", "Yes", "No");
            if (answer == true)
            {
                // Value recovery
                StoredElement moveElement = this.data.MoveElementPath;

                string a = this.actualpath + "/" + moveElement.ShortName;
                if (a != moveElement.Name)
                {
                    moveElement.Move(a);

                    // Reset Value
                    this.data.MoveElementPath = null;
                    this.storage.save(data);

                    // Refresh page & button
                    BindingContext = new MyListViewModel(actualpath);
                    this.CheckCopy();
                }


                // Exception to manage : move a rootfolder in a folder in this first folder.

                else
                {
                    //popup: Vous ne pouvez pas déplacer une élément dans le même répertoire;
                }
            }
        }

        // Check if copyElement and moveElement == null to update btn.
        private void CheckCopy()
        {
            if(this.data.CopyElementPath == null)
            {
                this.copybtn.IsVisible = false;
            }
            else
            {
                this.copybtn.IsVisible = true;
            }

            if (this.data.MoveElementPath == null)
            {
                this.movebtn.IsVisible = false;
            }
            else
            {
                this.movebtn.IsVisible = true;
            }
        }


        // This function allows to refresh previous pages
        protected override void OnAppearing()
        {
            base.OnAppearing();
            initialize();
        }
    }
}