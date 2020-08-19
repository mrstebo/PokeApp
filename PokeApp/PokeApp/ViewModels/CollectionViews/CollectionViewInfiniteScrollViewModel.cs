using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Dasync.Collections;
using PokeApp.Models;
using PokeApp.Services;
using PropertyChanged;
using Xamarin.Forms;

namespace PokeApp.ViewModels.CollectionViews
{
    [AddINotifyPropertyChangedInterface]
    public class CollectionViewInfiniteScrollViewModel
    {
        private const int ItemFetchLimit = 20;

        private IPokemonApi pokemonApi;

        public CollectionViewInfiniteScrollViewModel()
        {
            pokemonApi = DependencyService.Resolve<IPokemonApi>();

            Items = new ObservableCollection<CollectionListViewItem>();
            LoadData = new Command(ExecuteLoadData);
            RefreshItems = new Command(ExecuteRefreshItems);
            RemainingItemsThresholdReached = new Command(ExecuteRemainingItemsThresholdReached);
        }

        public ObservableCollection<CollectionListViewItem> Items { get; }
        public bool IsBusy { get; set; }
        public bool IsRefreshing { get; set; }
        public int RemainingItemsThreshold { get; set; } = 6;
        public ICommand LoadData { get; }
        public ICommand RefreshItems { get; }
        public ICommand RemainingItemsThresholdReached { get; }

        private async void ExecuteLoadData()
        {
            try
            {
                IsBusy = true;
                Items.Clear();

                await pokemonApi.GetPokemonAsync(0, ItemFetchLimit).ForEachAsync(pokemon =>
                {
                    Items.Add(new CollectionListViewItem
                    {
                        ImageUrl = pokemon.ShinyImageUrl
                    });
                });
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

                await pokemonApi.GetPokemonAsync(Items.Count, ItemFetchLimit).ForEachAsync(pokemon =>
                {
                    Items.Add(new CollectionListViewItem
                    {
                        ImageUrl = pokemon.ShinyImageUrl
                    });
                });
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
