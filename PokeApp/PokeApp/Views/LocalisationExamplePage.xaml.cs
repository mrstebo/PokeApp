using PokeApp.ViewModels;
using Xamarin.Forms;

namespace PokeApp.Views
{
    public partial class LocalisationExamplePage : ContentPage
    {
        public LocalisationExamplePage()
        {
            InitializeComponent();

            BindingContext = new LocalisationExampleViewModel();
        }
    }
}
