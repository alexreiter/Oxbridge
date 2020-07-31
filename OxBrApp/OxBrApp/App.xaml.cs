using OxBrApp.Models;
using OxBrApp.Services;
using OxBrApp.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OxBrApp
{
    public partial class App : Application
    {
        ISettingsService _settingsService;
        public App()
        {
            InitializeComponent();



            ServiceContainer.Register<ISettingsService>(() => new SettingsService());
            _settingsService = ServiceContainer.Resolve<ISettingsService>();
            ServiceContainer.Register<INavigationService>(() => new NavigationService(_settingsService));

            ServiceContainer.Register(() => new LoginViewModel());
            ServiceContainer.Register(() => new EventViewModel());
            ServiceContainer.Register(() => new RaceViewModel());
            ServiceContainer.Register(() => new MapViewModel());


            var masterDetailViewModel = new MasterDetailViewModel();
            ServiceContainer.Register(() => masterDetailViewModel);

            //MainPage = new MainPage();
            var master = new Views.MasterDetail();
            MainPage = master;
            master.BindingContext = masterDetailViewModel;
        }

        private Task InitNavigation()
        {
            var navigationService = ServiceContainer.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected async override void OnStart()
        {
            // Handle when your app starts
            base.OnStart();
            await InitNavigation();
            base.OnResume();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
