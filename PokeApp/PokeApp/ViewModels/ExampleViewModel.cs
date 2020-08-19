using PropertyChanged;

namespace PokeApp.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ExampleViewModel
    {
        public string Title { get; set; }
    }
}
