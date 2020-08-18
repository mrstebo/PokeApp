using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Android.Content;
using PokeApp.CustomControls;
using PokeApp.Droid.CustomRenderers;
using PokeApp.Droid.ListAdapters;
using PokeApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomListView), typeof(CustomListViewRenderer))]
namespace PokeApp.Droid.CustomRenderers
{
    public class CustomListViewRenderer : ListViewRenderer
    {
        private readonly Context context;

        public CustomListViewRenderer(Context context): base(context)
        {
            this.context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                ((ObservableCollection<CustomListViewItem>)((CustomListView)e.NewElement).ItemsSource).CollectionChanged -= CustomListViewRenderer_CollectionChanged;
            }

            if (e.NewElement != null)
            {
                Control.Adapter = new CustomListViewAdapter(context as Android.App.Activity, e.NewElement as CustomListView);

                ((ObservableCollection<CustomListViewItem>)((CustomListView)e.NewElement).ItemsSource).CollectionChanged += CustomListViewRenderer_CollectionChanged;
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
                Control.Adapter = new CustomListViewAdapter(context as Android.App.Activity, Element as CustomListView);
            }
        }

        /// <summary>
        /// Called when the ObservableCollection on the CustomListView has items added or removed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomListViewRenderer_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Control.Adapter = new CustomListViewAdapter(context as Android.App.Activity, Element as CustomListView);
        }
    }
}
