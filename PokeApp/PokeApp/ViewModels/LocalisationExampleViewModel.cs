using System.Globalization;

namespace PokeApp.ViewModels
{
    public class LocalisationExampleViewModel
    {
        public LocalisationExampleViewModel()
        {
            CurrentCulture = CultureInfo.CurrentCulture.DisplayName;
        }

        public string CurrentCulture { get; }
    }
}
