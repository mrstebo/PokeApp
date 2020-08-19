using System.Globalization;
using System.Linq;
using System.Threading;
using Java.Util;
using PokeApp.Droid.Localisation;
using PokeApp.Localisation;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalisationProvider))]

namespace PokeApp.Droid.Localisation
{
    public class LocalisationProvider : ILocalisationProvider
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Locale.Default;
            var language = androidLocale.ToString().Replace("_", "-");
            var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);

            if (!cultures.Any(c => c.Name == language))
            {
                language = "en";
            }

            return new CultureInfo(language);

            // Uncomment to use culture set in the main App, rather than what is on the device
            //return CultureInfo.CurrentCulture;
        }

        public void SetLocale()
        {
            var culture = GetCurrentCultureInfo();

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }
    }
}
