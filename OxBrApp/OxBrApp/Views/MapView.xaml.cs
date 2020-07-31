using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using OxBrApp.ViewModels;
using OxBrApp.Models;

namespace OxBrApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapView : ContentPage
    {
        public MapView()
        {
            InitializeComponent();
           
            
            CustomPin pin1 = new CustomPin
            {
                Position = new Position(55.491559, 9.508921),
                Label = "ship 1",

            };

            CustomPin pin2 = new CustomPin
            {
                Position = new Position(55.489304, 9.511987),
                Label = "ship 2",
                
            };

            CustomPin pin3 = new CustomPin
            {
                Position = new Position(55.488673, 9.513923),
                Label = "ship 3"
            };

            MyMap.Pins.Add(pin1);
            MyMap.Pins.Add(pin2);
            MyMap.Pins.Add(pin3);


            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(55.488574, 9.500157), Distance.FromKilometers(1.0)));
        }

       


    }
}