using System;
using PokeApp.CustomControls;
using PokeApp.iOS.CustomRenderers;
using PokeApp.iOS.ListViewSources;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomListView), typeof(CustomListViewRenderer))]
namespace PokeApp.iOS.CustomRenderers
{
    public class CustomListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (e.NewElement != null)
            {
                Control.Source = new CustomListViewSource(e.NewElement as CustomListView);
            }
        }
    }
}
