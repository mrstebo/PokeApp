using System.Collections.ObjectModel;
using System.Windows.Input;
using PokeApiNet;
using PokeApp.Models;
using PropertyChanged;
using Xamarin.Forms;

namespace PokeApp.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CollectionViewExampleViewModel
    {
        private PokeApiClient pokeApiClient;

        public CollectionViewExampleViewModel()
        {
            pokeApiClient = new PokeApiClient();

            LoadData = new Command(ExecuteLoadData);
            Items = new ObservableCollection<CollectionListViewItem>();
        }

        public ICommand LoadData { get; }
        public ObservableCollection<CollectionListViewItem> Items { get; }

        private async void ExecuteLoadData()
        {
            var page = await pokeApiClient.GetNamedResourcePageAsync<Pokemon>(30, 0);

            foreach (var result in page.Results)
            {
                var pokemon = await pokeApiClient.GetResourceAsync<Pokemon>(result.Name);

                Items.Add(new CollectionListViewItem
                {
                    ImageUrl = pokemon.Sprites.FrontShiny
                });
            }
        }
    }
}
