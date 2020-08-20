using System;
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

        void ContentPage_Appearing(object sender, EventArgs e)
        {
            var animation = new Animation
            {
                { 0, 0.5,  new Animation(v => MyLabel.Scale = v, 1, 1.5) },
                { 0.5, 1,  new Animation(v => MyLabel.Scale = v, 1.5, 1) },
            };

            //animation.Add(0.5, 1, new Animation(v => MyLabel.RotationX = v, 0, 360, Easing.SpringOut));

            animation.Commit(this, "LabelAnimation", 16, 4000, Easing.SinInOut, null, () => true);
        }
    }
}