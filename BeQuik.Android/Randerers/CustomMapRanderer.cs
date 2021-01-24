using Android.Content;
using Android.Gms.Maps;
using BeQuik.Droid.Randerers;
using BeQuik.UserControl;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.GoogleMaps.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRanderer))]
namespace BeQuik.Droid.Randerers
{
    public class CustomMapRanderer : MapRenderer
    {
        public CustomMapRanderer(Context context) : base(context) { }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            this.Element.Padding = new Thickness(0,250);
        }
        protected override void OnMapReady(GoogleMap nativeMap, Map map)
        {
            base.OnMapReady(nativeMap, map);
            this.Element.UiSettings.MyLocationButtonEnabled = true;
            this.Element.UiSettings.ZoomControlsEnabled = true;
        }
    }
}

