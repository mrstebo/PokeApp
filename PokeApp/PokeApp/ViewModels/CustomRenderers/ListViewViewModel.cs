using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PokeApiNet;
using PokeApp.Models;
using PropertyChanged;
using Xamarin.Forms;

namespace PokeApp.ViewModels.CustomRenderers
{
    [AddINotifyPropertyChangedInterface]
    public class ListViewViewModel
    {
        private PokeApiClient pokeApiClient;

        public ListViewViewModel()
        {
            pokeApiClient = new PokeApiClient();

            LoadData = new Command(ExecuteLoadData);
            Items = new ObservableCollection<CustomListViewItem>();
        }

        public ICommand LoadData { get; }
        public ObservableCollection<CustomListViewItem> Items { get; }

        private async void ExecuteLoadData()
        {
            var page = await pokeApiClient.GetNamedResourcePageAsync<Pokemon>(30, 0);

            foreach(var result in page.Results)
            {
                var pokemon = await pokeApiClient.GetResourceAsync<Pokemon>(result.Name);

                Items.Add(new CustomListViewItem
                {
                    Id = pokemon.Id,
                    Name = pokemon.Name,
                    ImageUrl = pokemon.Sprites.FrontDefault
                });
            }
        }
    }
}
