using Android.Content;
using BeQuik.Droid.Randerers;
using BeQuik.UserControl;
using System.ComponentModel;
using Xamarin.Forms;
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
            this.Element.Padding = new Thickness(0,250,0,150);
            this.Element.UiSettings.MyLocationButtonEnabled = true;
            this.Element.UiSettings.ZoomControlsEnabled = true;
        }
    }
}

