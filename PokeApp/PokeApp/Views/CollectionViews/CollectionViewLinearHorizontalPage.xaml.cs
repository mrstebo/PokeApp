using System;
using PokeApp.ViewModels.CollectionViews;
using Xamarin.Forms;

namespace PokeApp.Views.CollectionViews
{
    public partial class CollectionViewLinearHorizontalPage : ContentPage
    {
        private readonly CollectionViewViewModel viewModel;

        public CollectionViewLinearHorizontalPage()
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
