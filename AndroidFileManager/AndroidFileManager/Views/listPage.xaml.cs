using AndroidFileManager.Logic;
using AndroidFileManager.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
        private bool inCharge;

        //Builder for the class
        public listPage(string path_base)
        {
            InitializeComponent();
            this.actualpath = path_base;          
        }

        // Property for the attribute inCharge
        public bool InCharge
        {
            get { return inCharge; }
            set { inCharge = value; OnPropertyChanged(); }
        }

        // Load and refresh the page
        public void initialize()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/data.json";
            this.storage = new JsonStorage(path);
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
                    await Launcher.OpenAsync(new OpenFileRequest
                    {
                        File = new ReadOnlyFile(storedElement.Name)
                    });
                }
                
            }
            
        }
        

        // Button addFolder
        private async void AddFolder(object sender, EventArgs e)
        {
            try
            {
                string nouveau = await DisplayPromptAsync("New Folder", "What is the folder's name created ?");
                string path = this.actualpath + "/" + nouveau;
                Folder newFolder = new Folder(path);
                newFolder.Create();
                BindingContext = new MyListViewModel(actualpath);
            }
            catch (Exception except)
            {
                //popup : error
                await DisplayAlert("Alert", "Error:" + except.Message, "OK");
            }
        }


        // Item Menu : delete
        private async void Deleteclick(object sender, EventArgs e)
        {
            var storedElement = ((MenuItem)sender).BindingContext as StoredElement;
            bool answer = await DisplayAlert("Delete", "Do you really want to delete "+storedElement.Type+" : "+ storedElement.ShortName+ " ?", "Yes", "No");
            try
            {
                if (answer == true)
                {
                    if (storedElement == null)
                        return;

                    storedElement.Remove();
                    BindingContext = new MyListViewModel(actualpath);
                    await DisplayAlert("Information !", "The item has been deleted", "OK");
                }
            }
            catch (Exception except)
            {
                //popup : error
                await DisplayAlert("Alert", "Error:" + except.Message, "OK");
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
            this.data.CopyElementPath = storedElement.Name;
            this.storage.Save(this.data);

            // Button Refresh
            this.data.MoveElementPath = null;
            this.storage.Save(this.data);
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
            this.data.MoveElementPath = storedElement.Name;
            this.storage.Save(this.data);

            // Button Refresh
            this.data.CopyElementPath = null;
            this.storage.Save(this.data);
            this.CheckCopy();

        }


        // On button copy 
        private async void copyclicked(object sender, EventArgs e)
        {
            // Value recovery
            StoredElement copyElement;
            if (System.IO.Path.GetExtension(this.data.CopyElementPath) == null)
            {
                copyElement = new Folder(this.data.CopyElementPath);
            }
            else
            {
                copyElement = new Logic.File(this.data.CopyElementPath);
            }

            bool answer = await DisplayAlert("Copy", "Do you really want to copy " + copyElement.Type + " : " + copyElement.ShortName + " ?", "Yes", "No");
            if (answer == true)
            {
                inCharge = true;
                try
                {
                    // New string to dest path
                    string a = this.actualpath + "/" + copyElement.ShortName;
                    if (a != copyElement.Name)
                    {
                        copyElement.Copy(copyElement.Name, a, true);
                        await DisplayAlert("Alert", "The item has been copied", "OK");

                        // Reset Value
                        this.data.CopyElementPath = null;
                        this.storage.Save(data);

                        // Refresh page & button
                        BindingContext = new MyListViewModel(actualpath);
                        this.CheckCopy();
                    }
                }catch(Exception except)
                {
                    //popup : error
                    await DisplayAlert("Information !", "Error:"+except.Message, "OK");
                }

                inCharge = false;
            }
        }


        // On button move
        private async void moveclicked(object sender, EventArgs e)
        {
            // Value recovery
            StoredElement moveElement;
            if (System.IO.Path.GetExtension(this.data.CopyElementPath) == null)
            {
                moveElement = new Folder(this.data.MoveElementPath);
            }
            else
            {
                moveElement = new Logic.File(this.data.MoveElementPath);
            }

            bool answer = await DisplayAlert("Move", "Do you really want to move " + moveElement.Type + " : " + moveElement.ShortName + " ?", "Yes", "No");
            if (answer == true)
            {
                inCharge = true;
                try
                {
                    string a = this.actualpath + "/" + moveElement.ShortName;
                    if (a != moveElement.Name)
                    {
                        moveElement.Move(a);
                        await DisplayAlert("Information !", "The item has been moved", "OK");

                        // Reset Value
                        this.data.MoveElementPath = null;
                        this.storage.Save(data);

                        // Refresh page & button
                        BindingContext = new MyListViewModel(actualpath);
                        this.CheckCopy();
                    }
                }
                catch(Exception except)
                {
                    //popup : error
                    await DisplayAlert("Alert", "Error:" + except.Message, "OK");
                }

                inCharge = false;
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