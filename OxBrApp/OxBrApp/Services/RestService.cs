using OxBrApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;
using OxBrApp.Views;
using System.Collections.ObjectModel;

namespace OxBrApp.Services
{
    public class RestService
    {
        private SingletonSharedData sharedData;

        HttpClient client = new HttpClient();

        public RestService()
        {

            sharedData = SingletonSharedData.GetInstance();
        }

        /// <summary>
        /// Gets every single events through api
        /// </summary>
        public async void GetAllEvents()
        {
            var content = "";
            var RestURL = "https://oxbridge-back.herokuapp.com/api/race/";
            client.BaseAddress = new Uri(RestURL);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(RestURL);
            content = await response.Content.ReadAsStringAsync();
            var Items = JsonConvert.DeserializeObject<List<Event>>(content);

        }

        /// <summary>
        /// Send login request to server and return existing user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<User> Login(string email, string password)
        {

            using (var httpClient = new HttpClient { BaseAddress = new Uri("https://oxbridge-back.herokuapp.com") })
            {
                var user = new { email, password };
                string jsonUser = JsonConvert.SerializeObject(user);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "authentication/login/");
                request.Content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
                User existingUser = null;
                try
                {
                    var response = await httpClient.GetAsync($"/api/user/verify/{email}/{password}");

                    Console.WriteLine("status code = " + response.IsSuccessStatusCode);
                    if (!response.IsSuccessStatusCode)
                    {                     
                        return null;

                    }
                    else
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(result);
                        return JsonConvert.DeserializeObject<User>(result);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return existingUser;
            }
        }

        /// <summary>
        /// Retreive gps coordinates from backend
        /// </summary>
        public async void GetLocations()
        {
            var content = "";
            var RestURL = "https://oxbridge-back.herokuapp.com/api/race/";
            client.BaseAddress = new Uri(RestURL);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(RestURL);
            content = await response.Content.ReadAsStringAsync();
            var locations = JsonConvert.DeserializeObject<List<Models.Location>>(content);
        }
    }
    }



