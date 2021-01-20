using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms.GoogleMaps.Android;
using Android.Content.Res;

namespace BeQuik.Droid
{
    [Activity(Label = "BeQuick", Icon = "@drawable/logo_app", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Rg.Plugins.Popup.Popup.Init(this);

            Xamarin.Essentials.Platform.Init(this, bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            XF.Material.Droid.Material.Init(this, bundle);

            var platformConfig = new PlatformConfig { BitmapDescriptorFactory = new CachingNativeBitmapDescriptorFactory() };
            Xamarin.FormsGoogleMaps.Init(this, bundle, platformConfig); 

            LoadApplication(new App());
        }
        public override Android.Content.Res.Resources Resources
        {
            get
            {
                Configuration config = new Configuration();
                config.SetToDefaults();

                Android.Content.Context context = CreateConfigurationContext(config);
                var resources = context.Resources;

                return resources;
            }
        }
        public override void OnBackPressed()
        {
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {
                // Do something if there are some pages in the `PopupStack`
            }
            else
            {
                base.OnBackPressed();
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}