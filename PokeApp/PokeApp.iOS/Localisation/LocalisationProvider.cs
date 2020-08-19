using System.Globalization;
using System.Threading;
using Foundation;
using PokeApp.iOS.Localisation;
using PokeApp.Localisation;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalisationProvider))]

namespace PokeApp.iOS.Localisation
{
    public class LocalisationProvider : ILocalisationProvider
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "en";
            var prefLanguageOnly = "en";

            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];

                netLanguage = pref.Replace("_", "-");
            }

            CultureInfo cultureInfo;
            try
            {
                cultureInfo = new CultureInfo(netLanguage);
            }
            catch
            {
                // iOS locale not valid .NET culture (eg. "en-ES" : English in Spain)
                // fallback to first characters, in this case "en"
                cultureInfo = new CultureInfo(prefLanguageOnly);
            }

            return cultureInfo;

            // Uncomment to use culture set in the main App, rather than what is on the device
            //return CultureInfo.CurrentCulture;
        }

        public void SetLocale()
        {
            var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;
            var netLocale = iosLocaleAuto.Replace("_", "-");

            CultureInfo cultureInfo;

            try
            {
                cultureInfo = new CultureInfo(netLocale);
            }
            catch
            {
                cultureInfo = GetCurrentCultureInfo();
            }

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            // Uncomment to use culture set in the main App, rather than what is on the device
            //var culture = GetCurrentCultureInfo();

            //Thread.CurrentThread.CurrentCulture = culture;
            //Thread.CurrentThread.CurrentUICulture = culture;
        }
    }
}
