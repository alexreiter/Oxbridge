using OxBrApp.Models;
using OxBrApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace OxBrApp.ViewModels
{
    class MapViewModel : BaseViewModel
    {

		private RestService restService;

		private SingletonSharedData sharedData;

		public List<Location> locations;



		public List<Location> Locations
        {
            get { return locations; }
            set { locations = value; OnPropertyChanged(); }
        }

		private ObservableCollection<Pin> pins { get; set; }

		public ObservableCollection<Pin> Pins
        {
            get { return pins; }
            set { pins = value; OnPropertyChanged(); }
        }

		private Event selectedEvent;

		public Event SelectedEvent
        {
			get { return selectedEvent; }
            set { selectedEvent = value; OnPropertyChanged(); }
        }

		public MapViewModel()
		{
			sharedData = SingletonSharedData.GetInstance();
			restService = new RestService();
			SelectedEvent = sharedData.SelectedEvent;          
        }

       /// <summary>
       /// Retrieve pins from the backend
       /// </summary>
        private void  GetPins()
        {
            Pins = new ObservableCollection<Pin>();
             //locations =  restService.GetLocations();

            foreach (var item in locations)
            {
                Pin pin = new Pin
                {
                    Label = "ID: " + item.RaceTitle,
                    Address = item.Street,
                    Type = PinType.Place,
                    Position = new Position(item.Lat, item.Lng),
                };
                Pins.Add(pin);
            }
        }

        
    }
}
