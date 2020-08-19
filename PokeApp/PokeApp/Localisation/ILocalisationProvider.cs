using System.Globalization;

namespace PokeApp.Localisation
{
    public interface ILocalisationProvider
    {
        CultureInfo GetCurrentCultureInfo();

        void SetLocale();
    }
}
