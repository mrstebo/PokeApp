using System.Collections.ObjectModel;
using System.Windows.Input;
using Dasync.Collections;
using PokeApp.Models;
using PokeApp.Services;
using PropertyChanged;
using Xamarin.Forms;

namespace PokeApp.ViewModels.CustomRenderers
{
    [AddINotifyPropertyChangedInterface]
    public class ListViewViewModel
    {
        private IPokemonApi pokemonApi;

        public ListViewViewModel()
        {
            pokemonApi = DependencyService.Resolve<IPokemonApi>();

            LoadData = new Command(ExecuteLoadData);
            Items = new ObservableCollection<CustomListViewItem>();
        }

        public ICommand LoadData { get; }
        public ObservableCollection<CustomListViewItem> Items { get; }

        private async void ExecuteLoadData()
        {
            Items.Clear();

            await pokemonApi.GetPokemonAsync(0, 151).ForEachAsync(pokemon =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Items.Add(new CustomListViewItem
                    {
                        Id = pokemon.Id,
                        Name = pokemon.Name,
                        ImageUrl = pokemon.DefaultImageUrl
                    });
                });
            });
        }
    }
}
