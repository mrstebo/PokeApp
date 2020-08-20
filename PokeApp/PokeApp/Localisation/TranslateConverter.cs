using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;

namespace PokeApp.Localisation
{
    public class TranslateConverter : IValueConverter
    {
        private const string ResourceId = "PokeApp.Resources.Locale";
        private static readonly Lazy<ResourceManager> ResMgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = value as string;

            if (text == null)
                return "";

            var translation = ResMgr.Value.GetString(text, culture);

            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    string.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", text, ResourceId, culture.Name),
                    "Text");
#else
                translation = text; // returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
