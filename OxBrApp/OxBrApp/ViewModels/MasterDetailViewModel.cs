using OxBrApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OxBrApp.ViewModels
{
    class MasterDetailViewModel : BaseViewModel
    {  
        public ICommand ChangeVMCMD => new Command<MasterMenuItems>(async (MasterMenuItems mmi) => {

            await NavigationService.NavigateToAsync(mmi.TargetViewModel);
        });
    }
}
