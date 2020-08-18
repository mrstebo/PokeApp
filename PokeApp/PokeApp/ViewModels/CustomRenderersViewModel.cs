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
        }

        public ICommand GoToEntryCustomRenderersPage { get; }
        public INavigation Navigation { get; set; }

        private async void ExecuteGoToEntryCustomRenderersPage(object obj)
        {
            await Navigation.PushAsync(new EntryCustomRendererPage());
        }
    }
}
