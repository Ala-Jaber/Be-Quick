using Android.Graphics;
using Android.Graphics.Drawables;
using BeQuik.UserControl;
using BeQuik.Droid.UserControl;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AndroidX.Core.Content;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace BeQuik.Droid.UserControl
{
#pragma warning disable CS0618 // Type or member is obsolete
    class CustomPickerRenderer : PickerRenderer
    {
        CustomPicker element;

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            element = (CustomPicker)this.Element;

            if (Control != null && this.Element != null && !string.IsNullOrEmpty(element.Image))
                Control.Background = AddPickerStyles(element.Image);
        }

        public LayerDrawable AddPickerStyles(string imagePath)
        {

            Drawable[] layers = { GetDrawable(imagePath) };
            LayerDrawable layerDrawable = new LayerDrawable(layers);
            layerDrawable.SetLayerInset(0, 0, 0, 0, 0);

            return layerDrawable;
        }

        private BitmapDrawable GetDrawable(string imagePath)
        {
            int resID = Resources.GetIdentifier(imagePath, "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(this.Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;
            BitmapDrawable result;
            if (element.ImageSize != 0)
                result = new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, element.ImageSize, element.ImageSize, true));
            else
                result = new BitmapDrawable(Resources);
            result.Gravity = Android.Views.GravityFlags.Right;

            return result;
        }

    }
}
#pragma warning restore CS0618 // Type or member is obsolete