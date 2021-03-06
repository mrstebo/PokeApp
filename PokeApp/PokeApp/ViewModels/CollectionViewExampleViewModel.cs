﻿using System.Windows.Input;
using PokeApp.Views.CollectionViews;
using Xamarin.Forms;

namespace PokeApp.ViewModels
{
    public class CollectionViewExampleViewModel
    {
        public CollectionViewExampleViewModel()
        {
            GoToCollectionViewGridPage = new Command(ExecuteGoToCollectionViewGridPage);
            GoToCollectionViewInfiniteScrollPage = new Command(ExecuteGoToCollectionViewInfiniteScrollPage);
            GoToCollectionViewLinearHorizontalPage = new Command(ExecuteGoToCollectionViewLinearHorizontalPage);
            GoToCollectionViewLinearVerticalPage = new Command(ExecuteGoToCollectionViewLinearVerticalPage);
        }

        public ICommand GoToCollectionViewGridPage { get; }
        public ICommand GoToCollectionViewInfiniteScrollPage { get; }
        public ICommand GoToCollectionViewLinearHorizontalPage { get; }
        public ICommand GoToCollectionViewLinearVerticalPage { get; }
        public INavigation Navigation { get; set; }

        private async void ExecuteGoToCollectionViewGridPage()
        {
            await Navigation.PushAsync(new CollectionViewGridPage());
        }

        private async void ExecuteGoToCollectionViewInfiniteScrollPage()
        {
            await Navigation.PushAsync(new CollectionViewInfiniteScrollPage());
        }

        private async void ExecuteGoToCollectionViewLinearHorizontalPage()
        {
            await Navigation.PushAsync(new CollectionViewLinearHorizontalPage());
        }

        private async void ExecuteGoToCollectionViewLinearVerticalPage()
        {
            await Navigation.PushAsync(new CollectionViewLinearVerticalPage());
        }
    }
}
