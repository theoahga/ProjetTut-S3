﻿using AndroidFileManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidFileManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageDetailDossier : ContentPage
    {
        public PageDetailDossier()
        {
            InitializeComponent();

            BindingContext = new MyListViewModel_documents();
        }

       
        
    }
}