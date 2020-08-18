using Android.Content;
using PokeApp.CustomControls;
using PokeApp.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TemplateEntry), typeof(TemplateEntryRenderer))]
namespace PokeApp.Droid.CustomRenderers
{
    public class TemplateEntryRenderer : EntryRenderer
    {
        public TemplateEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null) return;

            Control.SetBackgroundResource(Resource.Layout.TemplateEntry);
        }
    }
}
