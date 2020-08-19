using System;
using PokeApp.ViewModels.CustomRenderers;
using Xamarin.Forms;

namespace PokeApp.Views.CustomRenderers
{
    public partial class ListViewDefaultPage : ContentPage
    {
        private readonly ListViewViewModel viewModel;

        public ListViewDefaultPage()
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
