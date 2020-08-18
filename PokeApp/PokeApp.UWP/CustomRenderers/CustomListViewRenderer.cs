using PokeApp.CustomControls;
using PokeApp.Models;
using PokeApp.UWP.CustomRenderers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomListView), typeof(CustomListViewRenderer))]
namespace PokeApp.UWP.CustomRenderers
{
    public class CustomListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);

            var listView = Control as ListView;

            if (e.OldElement != null)
            {
                ((ObservableCollection<CustomListViewItem>)e.NewElement.ItemsSource).CollectionChanged -= CustomListViewRenderer_CollectionChanged;
            }

            if (e.NewElement != null)
            {
                listView.SelectionMode = ListViewSelectionMode.Single;
                listView.IsItemClickEnabled = false;
                listView.ItemsSource = e.NewElement.ItemsSource;
                listView.ItemTemplate = App.Current.Resources["CustomListViewItemTemplate"] as Windows.UI.Xaml.DataTemplate;

                ((ObservableCollection<CustomListViewItem>)e.NewElement.ItemsSource).CollectionChanged += CustomListViewRenderer_CollectionChanged;
            }
        }

        /// <summary>
        /// Used to handle situations where the ItemsSource property changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CustomListView.ItemsSourceProperty.PropertyName)
            {
                ((ListView)Control).ItemsSource = Element.ItemsSource;
            }
        }

        /// <summary>
        /// Called when the ObservableCollection on the CustomListView has items added or removed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomListViewRenderer_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ((ListView)Control).ItemsSource = Element.ItemsSource;
        }
    }
}
