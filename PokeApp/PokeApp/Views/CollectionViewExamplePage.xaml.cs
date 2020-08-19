using PokeApp.ViewModels;
using Xamarin.Forms;

namespace PokeApp.Views
{
    public partial class CollectionViewExamplePage : ContentPage
    {
        public CollectionViewExamplePage()
        {
            InitializeComponent();

            BindingContext = new CollectionViewExampleViewModel
            {
                Navigation = Navigation
            };
        }
    }
}
