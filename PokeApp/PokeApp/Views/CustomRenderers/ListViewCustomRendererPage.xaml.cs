﻿using System;
using PokeApp.ViewModels.CustomRenderers;
using Xamarin.Forms;

namespace PokeApp.Views.CustomRenderers
{
    public partial class ListViewCustomRendererPage : ContentPage
    {
        private readonly ListViewViewModel viewModel;

        public ListViewCustomRendererPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ListViewViewModel();
        }

        void ContentPage_Appearing(object sender, EventArgs e)
        {
            viewModel.LoadData.Execute(null);
        }
    }
}
