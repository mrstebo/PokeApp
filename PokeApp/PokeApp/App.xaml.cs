using Xamarin.Forms;
using PokeApp.Views;
using PokeApp.Services;
using System.Threading;
using System.Globalization;

namespace PokeApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Device.SetFlags(new[]
            {
                "CollectionView_Experimental",
                "Shapes_Experimental"
            });

            DependencyService.RegisterSingleton<IPokemonApi>(new PokemonApi());

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
