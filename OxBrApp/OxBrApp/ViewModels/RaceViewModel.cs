using OxBrApp.Models;
using OxBrApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OxBrApp.ViewModels
{
    class RaceViewModel : BaseViewModel
    {
        private SingletonSharedData sharedData;
        public ICommand NavigateToMap { get; set; }

        private Event selectedEvent;

        public Event SelectedEvent
        {
            get { return selectedEvent; }
            set { selectedEvent = value; OnPropertyChanged(); }
        }

        public RaceViewModel()

        {
            sharedData = SingletonSharedData.GetInstance();
            SelectedEvent = sharedData.SelectedEvent;

            NavigateToMap = new Command(ShowMap);
        }

       
        /// <summary>
        /// Navigates to the MapView 
        /// </summary>
        public async void ShowMap()
        {
            await NavigationService.NavigateToAsync(typeof(MapViewModel));
        }
       
    }
}
