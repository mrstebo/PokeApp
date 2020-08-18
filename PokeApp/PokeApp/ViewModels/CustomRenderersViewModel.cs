using System;
using System.Windows.Input;
using PokeApp.Views.CustomRenderers;
using Xamarin.Forms;

namespace PokeApp.ViewModels
{
    public class CustomRenderersViewModel
    {
        public CustomRenderersViewModel()
        {
            GoToEntryCustomRenderersPage = new Command(ExecuteGoToEntryCustomRenderersPage);
            GoToListViewCustomRendererPage = new Command(ExecuteGoToListViewCustomRendererPage);
        }

        public ICommand GoToEntryCustomRenderersPage { get; }
        public ICommand GoToListViewCustomRendererPage { get; }
        public INavigation Navigation { get; set; }

        private async void ExecuteGoToEntryCustomRenderersPage()
        {
            await Navigation.PushAsync(new EntryCustomRendererPage());
        }

        private async void ExecuteGoToListViewCustomRendererPage()
        {
            await Navigation.PushAsync(new ListViewCustomRendererPage());
        }
    }
}
