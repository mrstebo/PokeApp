using System;
using PokeApp.ViewModels.CustomRenderers;
using Xamarin.Forms;

namespace PokeApp.Views.CustomRenderers
{
    public partial class ListViewCustomRendererPage : ContentPage
    {
        private readonly ListViewCustomRendererViewModel viewModel;

        public ListViewCustomRendererPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ListViewCustomRendererViewModel();
        }

        void ContentPage_Appearing(object sender, EventArgs e)
        {
            viewModel.LoadData.Execute(null);
        }
    }
}
