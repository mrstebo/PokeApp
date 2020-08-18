using PokeApp.CustomControls;
using PokeApp.UWP.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace PokeApp.UWP.CustomRenderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null) return;

            Control.Background = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.LightGreen);
            Control.BorderThickness = new Windows.UI.Xaml.Thickness(0, 0, 0, 2);
        }
    }
}
