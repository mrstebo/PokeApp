using System;
using System.Collections.Generic;
using PokeApp.ViewModels.CollectionViews;
using Xamarin.Forms;

namespace PokeApp.Views.CollectionViews
{
    public partial class CollectionViewGridPage : ContentPage
    {
        private readonly CollectionViewViewModel viewModel;

        public CollectionViewGridPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CollectionViewViewModel();
        }

        void ContentPage_Appearing(object sender, EventArgs e)
        {
            viewModel.LoadData.Execute(null);
        }
    }
}
