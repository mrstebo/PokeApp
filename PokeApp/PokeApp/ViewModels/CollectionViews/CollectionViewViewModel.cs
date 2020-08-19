using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using PokeApiNet;
using PokeApp.Models;
using PropertyChanged;
using Xamarin.Forms;

namespace PokeApp.ViewModels.CollectionViews
{
    [AddINotifyPropertyChangedInterface]
    public class CollectionViewViewModel
    {
        private const int ItemFetchLimit = 50;

        private PokeApiClient pokeApiClient;

        public CollectionViewViewModel()
        {
            pokeApiClient = new PokeApiClient();

            LoadData = new Command(ExecuteLoadData);
            Items = new ObservableCollection<CollectionListViewItem>();
        }

        public ICommand LoadData { get; }
        public ObservableCollection<CollectionListViewItem> Items { get; }
        public bool IsBusy { get; set; }

        private async void ExecuteLoadData()
        {
            try
            {
                IsBusy = true;
                Items.Clear();

                var page = await pokeApiClient.GetNamedResourcePageAsync<Pokemon>(ItemFetchLimit, 0);

                foreach (var result in page.Results)
                {
                    var pokemon = await pokeApiClient.GetResourceAsync<Pokemon>(result.Name);

                    Items.Add(new CollectionListViewItem
                    {
                        ImageUrl = pokemon.Sprites.FrontShiny
                    });
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Failed to get data: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
