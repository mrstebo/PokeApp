using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows.Input;
using PropertyChanged;
using Xamarin.Forms;

namespace PokeApp.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class LocalisationExampleViewModel
    {
        private static readonly IReadOnlyList<string> words = new List<string>
        {
            "ColourLabel",
            "CentreLabel",
        };
        private int selectedIndex = 0;

        public LocalisationExampleViewModel()
        {
            CurrentCulture = CultureInfo.CurrentCulture.DisplayName;
            CurrentLabel = words[selectedIndex];
            SwitchWord = new Command(ExecuteSwitchWord);
        }

        public string CurrentCulture { get; }
        public string CurrentLabel { get; set; }
        public ICommand SwitchWord { get; }

        private void ExecuteSwitchWord()
        {
            CurrentLabel = words[++selectedIndex % words.Count];
        }

        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by Fody")]
        private void OnCurrentLabelChanged()
        {
            Debug.WriteLine($"CurrentLabel changed: {CurrentLabel}");
        }
    }
}
