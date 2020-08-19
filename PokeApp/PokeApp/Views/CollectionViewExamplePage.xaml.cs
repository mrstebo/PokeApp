using System;
using PokeApp.ViewModels;
using Xamarin.Forms;

namespace PokeApp.Views
{
    public partial class CollectionViewExamplePage : ContentPage
    {
        private readonly CollectionViewExampleViewModel viewModel;

        public CollectionViewExamplePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CollectionViewExampleViewModel();
        }

        void ContentPage_Appearing(object sender, EventArgs e)
        {
            viewModel.LoadData.Execute(null);
        }
    }
}
