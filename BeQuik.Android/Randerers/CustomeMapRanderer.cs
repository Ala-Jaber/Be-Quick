using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BeQuik.Droid.Randerers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.GoogleMaps.Map), typeof(CustomeMapRanderer))]
namespace BeQuik.Droid.Randerers
{
    public class CustomeMapRanderer : MapRenderer
    {
        public CustomeMapRanderer(Context context) : base(context) { }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            NativeMap.UiSettings.ZoomControlsEnabled = false;
        }
    }
}