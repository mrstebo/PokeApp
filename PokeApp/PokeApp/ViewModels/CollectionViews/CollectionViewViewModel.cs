using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Dasync.Collections;
using PokeApiNet;
using PokeApp.Models;
using PokeApp.Services;
using PropertyChanged;
using Xamarin.Forms;

namespace PokeApp.ViewModels.CollectionViews
{
    [AddINotifyPropertyChangedInterface]
    public class CollectionViewViewModel
    {
        private const int ItemFetchLimit = 50;

        private IPokemonApi pokemonApi;

        public CollectionViewViewModel()
        {
            pokemonApi = DependencyService.Resolve<IPokemonApi>();

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

                await pokemonApi.GetPokemonAsync(0, ItemFetchLimit).ForEachAsync(pokemon =>
                {
                    Items.Add(new CollectionListViewItem
                    {
                        ImageUrl = pokemon.DefaultImageUrl,
                    });
                });
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
