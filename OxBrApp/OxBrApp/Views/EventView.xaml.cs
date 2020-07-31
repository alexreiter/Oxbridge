using Newtonsoft.Json;
using OxBrApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OxBrApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventView : ContentPage
    {

        ViewCell lastCell;
        public EventView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set the selected item background color to blue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            if (lastCell != null)
                lastCell.View.BackgroundColor = Color.Transparent;
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Color.CornflowerBlue;
                lastCell = viewCell;
            }
        }

    }
}