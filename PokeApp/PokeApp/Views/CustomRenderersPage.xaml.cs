﻿using PokeApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomRenderersPage : ContentPage
    {
        public CustomRenderersPage()
        {
            InitializeComponent();

            BindingContext = new CustomRenderersViewModel
            {
                Navigation = Navigation
            };
        }
    }
}