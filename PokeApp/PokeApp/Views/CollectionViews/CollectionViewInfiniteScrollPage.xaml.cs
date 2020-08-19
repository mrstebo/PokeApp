using System;
using PokeApp.ViewModels.CollectionViews;
using Xamarin.Forms;

namespace PokeApp.Views.CollectionViews
{
    public partial class CollectionViewInfiniteScrollPage : ContentPage
    {
        private readonly CollectionViewInfiniteScrollViewModel viewModel;

        public CollectionViewInfiniteScrollPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CollectionViewInfiniteScrollViewModel();
        }

        void ContentPage_Appearing(object sender, EventArgs e)
        {
            viewModel.LoadData.Execute(null);
        }
    }
}
