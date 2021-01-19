using BeQuik.Utils;
using BeQuik.Views;
using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;
using XF.Material.Forms.Resources;
using XF.Material.Forms.UI.Dialogs.Configurations;

namespace BeQuik
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            XF.Material.Forms.Material.Init(this);
            new ViewModels.LoginViewModel();
        }
        public static MaterialLoadingDialogConfiguration GetMaterialLoadingDialogConfiguration()
        {
            return new MaterialLoadingDialogConfiguration
            {
                BackgroundColor = XF.Material.Forms.Material.GetResource<Color>(MaterialConstants.Color.PRIMARY),
                MessageTextColor = XF.Material.Forms.Material.GetResource<Color>(MaterialConstants.Color.ON_PRIMARY).MultiplyAlpha(0.8),
                TintColor = XF.Material.Forms.Material.GetResource<Color>(MaterialConstants.Color.ON_PRIMARY),
                CornerRadius = 8,
                ScrimColor = Color.FromHex("#011A27").MultiplyAlpha(0.32),
            };
        }
        public static MaterialAlertDialogConfiguration GetMaterialAlertDialogConfiguration()
        {
            return new MaterialAlertDialogConfiguration
            {
                BackgroundColor = XF.Material.Forms.Material.GetResource<Color>(MaterialConstants.Color.PRIMARY),
                TitleTextColor = XF.Material.Forms.Material.GetResource<Color>(MaterialConstants.Color.ON_PRIMARY),
                MessageTextColor = XF.Material.Forms.Material.GetResource<Color>(MaterialConstants.Color.ON_PRIMARY).MultiplyAlpha(0.8),
                TintColor = XF.Material.Forms.Material.GetResource<Color>(MaterialConstants.Color.ON_PRIMARY),
                CornerRadius = 8,
                ScrimColor = Color.FromHex("#011A27").MultiplyAlpha(0.32),
                ButtonAllCaps = false
            };
        }
        public static void AddMapStyle(Xamarin.Forms.GoogleMaps.Map MapForms)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream($"BeQuik.MapResources.StyleMap.json");
            if (stream != null)
            {
                string styleFile;
                using (var reader = new System.IO.StreamReader(stream))
                {
                    styleFile = reader.ReadToEnd();
                }
                MapForms.MapStyle = MapStyle.FromJson(styleFile);
            }
        }
        public static FlowDirection GetFlowDirection()
        {
            try
            {
                if (LocalizationResourceManager.Instance.CurrentCulture.TextInfo.IsRightToLeft)
                    return FlowDirection.RightToLeft;
                return FlowDirection.LeftToRight;
            }
            catch
            {
                return default;
            }
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
