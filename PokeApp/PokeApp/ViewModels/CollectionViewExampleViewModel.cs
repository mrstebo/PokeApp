using System.Windows.Input;
using PokeApp.Views.CollectionViews;
using Xamarin.Forms;

namespace PokeApp.ViewModels
{
    public class CollectionViewExampleViewModel
    {
        public CollectionViewExampleViewModel()
        {
            GoToGridCollectionViewPage = new Command(ExecuteGoToGridCollectionViewPage);
        }

        public ICommand GoToGridCollectionViewPage { get; }
        public INavigation Navigation { get; set; }

        private async void ExecuteGoToGridCollectionViewPage()
        {
            await Navigation.PushAsync(new CollectionViewGridPage());
        }
    }
}
