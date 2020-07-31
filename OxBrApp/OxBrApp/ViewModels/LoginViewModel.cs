using OxBrApp.Models;
using OxBrApp.Services;
using OxBrApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OxBrApp.ViewModels
{
    class LoginViewModel : BaseViewModel
    {

        private RestService restService;
        private SingletonSharedData sharedData;

        private bool isLoginFailed;

        public bool IsLoginFailed
        {
            get { return isLoginFailed; }
            set { isLoginFailed = value; OnPropertyChanged(); }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); }
        }

        private string password;
       

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand OnEntryFocusedCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            OnEntryFocusedCommand = new Command(OnEntryFocused);
            restService = new RestService();
            sharedData = SingletonSharedData.GetInstance();
        }

        private void OnEntryFocused()
        {
            IsLoginFailed = false;
        }

       
        /// <summary>
        /// If the user logged in successfully will be navigated to another view
        /// </summary>
        private async void Login()
        {
            User user = await restService.Login(email, password);
           
            if (user != null)
            {
                
                await NavigationService.NavigateToAsync(typeof(EventViewModel));
            }
            else
            {
                IsLoginFailed = true;
                Password = "";
            }
        }  
}
}


   


    


    

