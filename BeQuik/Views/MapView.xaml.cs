using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace BeQuik.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapView : ContentPage
    {
        public MapView(bool ShowCurrentLocation)
        {
            InitializeComponent();
            App.AddMapStyle(MapForms);
            MapForms.MyLocationEnabled = ShowCurrentLocation;
        }
        
    }
}