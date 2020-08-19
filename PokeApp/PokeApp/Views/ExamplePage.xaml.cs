using PokeApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExamplePage : ContentPage
    {
        public ExamplePage()
        {
            InitializeComponent();

            BindingContext = new ExampleViewModel
            {
                Title = "Example Page",
            };
        }
    }
}