using OxBrApp.Models;
using OxBrApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OxBrApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetail()
        {
            InitializeComponent();
            profileImage.Source = ImageSource.FromFile("ship.png");

            navigationList.ItemsSource = GetMenuList();

            IsPresented = false;
        }

        /// <summary>
        /// Creates menu items on MasterMenu
        /// </summary>
        /// <returns></returns>
        public List<MasterMenuItems> GetMenuList()
        {
            var list = new List<MasterMenuItems>();

            list.Add(new MasterMenuItems()
            {
                Text = "Events",
                ImagePath = "race.png",
                TargetViewModel = typeof(EventViewModel)
            });

            list.Add(new MasterMenuItems()
            {
                Text = "Login",
                ImagePath = "login.jpg",
                TargetViewModel = typeof(LoginViewModel)
            });
            list.Add(new MasterMenuItems()
            {
                Text = "Logout",
                ImagePath = "logout.png",
                TargetViewModel = typeof(LogoutViewModel)
            });



            return list;
        }

        /// <summary>
        /// Navigates to the selected view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenuItem = (MasterMenuItems)e.SelectedItem;

            var viewModel = (ViewModels.MasterDetailViewModel)this.BindingContext;
            viewModel.ChangeVMCMD.Execute(selectedMenuItem);

            IsPresented = false;
        }
    }
}