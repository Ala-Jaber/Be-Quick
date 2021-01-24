using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace BeQuik.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TracingServicePage : ContentPage
    {
        public TracingServicePage(Position clientPosition)
        {
            InitializeComponent();
            App.AddMapStyle(MapForms);
            PutPinOnCoordinates(Enums.PinType.pin, clientPosition);
            ViewModels.TracingServiceViewModel.UpdateLocationDriver = this.ChangePinOnCoordinates;
        }
        protected override bool OnBackButtonPressed() => true;
        private void PutPinOnCoordinates(Enums.PinType pinType,Position position) 
        {
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "client",
                Icon = BitmapDescriptorFactory.FromBundle(pinType.ToString()),
            };
            MapForms.Pins.Add(pin);
            MapForms.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1.0)));
        }
        private void ChangePinOnCoordinates(Enums.PinType pinType,Position position) 
        {
            var PinDriver = MapForms.Pins.FirstOrDefault(item => item.Label == "driver");
            if (PinDriver == null)
                MapForms.Pins.Add(new Pin
                {
                    Type = PinType.Place,
                    Position = position,
                    Label = "driver",
                    Icon = BitmapDescriptorFactory.FromBundle(pinType.ToString()),
                });
            else
                PinDriver.Position = position;
        }
    }
}