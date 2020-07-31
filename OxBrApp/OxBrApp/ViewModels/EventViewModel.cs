using Newtonsoft.Json;
using OxBrApp.Models;
using OxBrApp.Services;
using OxBrApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OxBrApp.ViewModels
{
    class EventViewModel : BaseViewModel
    {

       
        private RestService restService;
        private SingletonSharedData sharedData;

        private List<Event> events;

        public List<Event> Events
            {
            get { return events; }
            set { events = value; OnPropertyChanged(); }
            }

        private Event selectedEvent;

        [Obsolete]
        public Event SelectedEvent
        {
            get { return selectedEvent; }
            set { selectedEvent = value; OnPropertyChanged(); OpenEvent(); }
        }


        public EventViewModel()

        {
            restService = new RestService();
            sharedData = SingletonSharedData.GetInstance();
            GetAllEvents();
        }

        /// <summary>
        /// Retrieve all upcoming events from backend and display them in a listview
        /// </summary>
        public async void GetAllEvents()
        {
            var content = "";
            HttpClient client = new HttpClient();
            var RestURL = "https://oxbridge-back.herokuapp.com/api/race/";
            client.BaseAddress = new Uri(RestURL);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(RestURL);
            content = await response.Content.ReadAsStringAsync();
            var Items = JsonConvert.DeserializeObject<List<Event>>(content);
            Events = Items;
        }


        /// <summary>
        /// Navigate to another view with the selected event
        /// </summary>
        private async void OpenEvent()
        {
            if(selectedEvent !=null)
            {
                sharedData.SelectedEvent = selectedEvent;

                await NavigationService.NavigateToAsync(typeof(RaceViewModel));
            }
           
        }      

    }
}



    

