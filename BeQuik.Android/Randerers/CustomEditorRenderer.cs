using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using BeQuik.UserControl;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using BeQuik.Droid.UserControl;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]

namespace BeQuik.Droid.UserControl
{
    public class CustomEditorRenderer : EditorRenderer
    {
        public CustomEditorRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e); 
            Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
        }
    }

}