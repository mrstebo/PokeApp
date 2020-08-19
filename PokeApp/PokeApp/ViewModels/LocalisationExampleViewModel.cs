using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace PokeApp.ViewModels
{
    public class LocalisationExampleViewModel
    {
        public LocalisationExampleViewModel()
        {
            ChangeCurrentCulture = new Command<string>(ExecuteChangeCurrentCulture);
        }

        public ICommand ChangeCurrentCulture { get; }

        private void ExecuteChangeCurrentCulture(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }
    }
}
