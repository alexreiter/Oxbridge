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
    public partial class LoginView: ContentPage
    {
        Random random = new Random();
        public LoginView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates animation on logout button 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_logout_Clicked(object sender, EventArgs e)
        {
            await btn_logout.TranslateTo(0, (Height - btn_logout.Height) / 2, 400, Easing.BounceOut);
            await Task.Delay(500);
            await btn_logout.TranslateTo(0, 0, 400, Easing.SpringOut);
        }

        /// <summary>
        /// Creates transformation on signin button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_signup_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            View container = (View)button.Parent;
            button.TranslationX = (random.NextDouble() - 0.5) * (container.Width - button.Width);
            button.TranslationY = (random.NextDouble() - 0.5) * (container.Height - button.Height);
        }
    }
}