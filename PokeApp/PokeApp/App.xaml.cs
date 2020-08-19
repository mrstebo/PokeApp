using Xamarin.Forms;
using PokeApp.Views;
using PokeApp.Services;

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
