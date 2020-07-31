﻿using OxBrApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OxBrApp.ViewModels
{
    public abstract class BaseViewModel : ExtendedBindableObject
    {
        protected readonly INavigationService NavigationService;

        internal static string UserName = "";

        public BaseViewModel()
        {
            NavigationService = ViewModelLocator.Resolve<INavigationService>();
            var settingsService = ViewModelLocator.Resolve<ISettingsService>();

        }
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
