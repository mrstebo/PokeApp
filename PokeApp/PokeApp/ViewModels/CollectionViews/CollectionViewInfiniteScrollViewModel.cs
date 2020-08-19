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
    public class CollectionViewInfiniteScrollViewModel
    {
        private const int ItemFetchLimit = 20;

        private PokeApiClient pokeApiClient;

        public CollectionViewInfiniteScrollViewModel()
        {
            pokeApiClient = new PokeApiClient();

            Items = new ObservableCollection<CollectionListViewItem>();
            LoadData = new Command(ExecuteLoadData);
            RefreshItems = new Command(ExecuteRefreshItems);
            RemainingItemsThresholdReached = new Command(ExecuteRemainingItemsThresholdReached);
        }

        public ObservableCollection<CollectionListViewItem> Items { get; }
        public bool IsBusy { get; set; }
        public bool IsRefreshing { get; set; }
        public int RemainingItemsThreshold { get; set; } = 1;
        public ICommand LoadData { get; }
        public ICommand RefreshItems { get; }
        public ICommand RemainingItemsThresholdReached { get; }

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
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to get data: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void ExecuteRefreshItems()
        {
            IsRefreshing = true;

            LoadData.Execute(null);

            IsRefreshing = false;
        }

        private async void ExecuteRemainingItemsThresholdReached()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;

                var page = await pokeApiClient.GetNamedResourcePageAsync<Pokemon>(ItemFetchLimit, Items.Count);

                foreach (var result in page.Results)
                {
                    var pokemon = await pokeApiClient.GetResourceAsync<Pokemon>(result.Name);

                    Items.Add(new CollectionListViewItem
                    {
                        ImageUrl = pokemon.Sprites.FrontShiny
                    });
                }
            }
            catch (Exception ex)
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
