using System;
using PokeApp.ViewModels.CollectionViews;
using Xamarin.Forms;

namespace PokeApp.Views.CollectionViews
{
    public partial class CollectionViewLinearVerticalPage : ContentPage
    {
        private readonly CollectionViewViewModel viewModel;

        public CollectionViewLinearVerticalPage()
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
