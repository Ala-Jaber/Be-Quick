using System;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.GoogleMaps.Android.Factories;
using AndroidBitmapDescriptor = Android.Gms.Maps.Model.BitmapDescriptor;
using AndroidBitmapDescriptorFactory = Android.Gms.Maps.Model.BitmapDescriptorFactory;


namespace BeQuik.Droid
{
    public sealed class AccessNativeBitmapConfig : IBitmapDescriptorFactory
    {
        public AndroidBitmapDescriptor ToNative(BitmapDescriptor descriptor)
        {
            int resId = 0;
            if (Enum.TryParse(descriptor.Id, out Enums.PinType PinType))
            {
                switch (PinType)
                {
                    case Enums.PinType.pin:
                        resId = Resource.Drawable.pin;
                        break;
                    case Enums.PinType.pin_taxi:
                        resId = Resource.Drawable.pin_taxi;
                        break;
                    case Enums.PinType.pin_delivery:
                        resId = Resource.Drawable.pin_delivery;
                        break;
                    case Enums.PinType.pin_gas:
                        resId = Resource.Drawable.pin_gas;
                        break;
                    case Enums.PinType.pin_winch:
                        resId = Resource.Drawable.pin_winch;
                        break;
                }
                return AndroidBitmapDescriptorFactory.FromResource(resId);
            }
            return AndroidBitmapDescriptorFactory.FromResource(Resource.Drawable.pin);
        }
    }
}