using Android.Graphics;
using Android.Graphics.Drawables;
using BeQuik.UserControl;
using BeQuik.Droid.UserControl;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AndroidX.Core.Content;
using Android.Content;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace BeQuik.Droid.UserControl
{
    public class CustomPickerRenderer : PickerRenderer
    {
        public CustomPickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            var CustomPicker = this.Element as CustomPicker;
            if (!string.IsNullOrEmpty(CustomPicker?.Image))
                Control.Background = AddPickerStyles(CustomPicker.Image, CustomPicker.ImageSize, CustomPicker.ImageSize);
            base.OnElementChanged(e);
        }

        public LayerDrawable AddPickerStyles(string imagePath,int width, int height)
        {
            var layers = new Drawable[] { GetDrawable(imagePath,width, height) };
            var layerDrawable = new LayerDrawable(layers);
            layerDrawable.SetLayerInset(0, 0, 0, 0, 0);
            return layerDrawable;
        }

        private BitmapDrawable GetDrawable(string imagePath, int width, int height)
        {
            int resID = Resources.GetIdentifier(imagePath, "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(this.Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;
            var Image = Bitmap.CreateScaledBitmap(bitmap, width, height, true);
            var result = new BitmapDrawable(Resources, Image)
            {
                Gravity = Android.Views.GravityFlags.Right
            };
            return result;
        }

    }
}
