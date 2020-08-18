using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PokeApp.Models;
using PropertyChanged;
using Xamarin.Forms;

namespace PokeApp.ViewModels.CustomRenderers
{
    [AddINotifyPropertyChangedInterface]
    public class ListViewCustomRendererViewModel
    {
        public ListViewCustomRendererViewModel()
        {
            LoadData = new Command(ExecuteLoadData);
            Items = new ObservableCollection<CustomListViewItem>();
        }

        public ICommand LoadData { get; }
        public ObservableCollection<CustomListViewItem> Items { get; }

        private void ExecuteLoadData()
        {
            Items.Add(new CustomListViewItem
            {
                Id = 1,
                Name = "Item 1",
                ImageUrl = "https://picsum.photos/seed/item1/200"
            });
            Items.Add(new CustomListViewItem
            {
                Id = 2,
                Name = "Item 2",
                ImageUrl = "https://i.imgur.com/DvpvklR.png"
            });
            Items.Add(new CustomListViewItem
            {
                Id = 3,
                Name = "Item 3",
                ImageUrl = "https://loremflickr.com/200/200"
            });
        }
    }
}
