using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeQuik.UserControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Badge : ContentView
    {
        #region Size Image Proprety
        public static readonly BindableProperty SizeImageProperty = BindableProperty.Create(nameof(SizeImage), typeof(double), typeof(Badge), 25.0, BindingMode.OneWay, propertyChanged: OnSizeImageChanged);
        public double SizeImage
        {
            get { return (double)GetValue(SizeImageProperty); }
            set { SetValue(SizeImageProperty, value); }
        }
        private static void OnSizeImageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (bindable as Badge);
            if (newValue != null && newValue != oldValue && newValue is double size)
            {
                control.BadgeImage.HeightRequest = size;
            }

        }
        #endregion
        #region Size Badge Proprety
        public static readonly BindableProperty SizeLayoutProperty = BindableProperty.Create(nameof(SizeLayout), typeof(double), typeof(Badge),39.0, BindingMode.OneWay, propertyChanged: OnSizeLayoutChanged);
        public double SizeLayout
        {
            get { return (double)GetValue(SizeLayoutProperty); }
            set { SetValue(SizeLayoutProperty, value); }
        }
        private static void OnSizeLayoutChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (bindable as Badge);
            if(newValue != null && newValue != oldValue && newValue is double size)
            {
                control.ImageBorderCard.HeightRequest= control.ImageBorderCard.WidthRequest = size * 2;
                control.ImageBorderCard.CornerRadius = (float)size;

                control.NumberBorderCard.HeightRequest = control.NumberBorderCard.WidthRequest = size;
                control.NumberBorderCard.CornerRadius = (float)Math.Round(size / 2);
                control.GridLayout.RowDefinitions = new RowDefinitionCollection 
                { 
                    new RowDefinition() { Height = Math.Round(size / 2) }, 
                    new RowDefinition() { Height = Math.Round(size / 2) },
                    new RowDefinition() { Height = GridLength.Star } 
                };
                control.GridLayout.ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition() { Width = Math.Round(size / 3) },
                    new ColumnDefinition() { Width = Math.Round(size / 3) },
                    new ColumnDefinition() { Width = Math.Round(size / 3) },
                    new ColumnDefinition() { Width = size }
                };
            }

        }
        #endregion
        #region Number Badge Proprety
        public static readonly BindableProperty NumberBadgeProperty = BindableProperty.Create(nameof(NumberBadge), typeof(int), typeof(Badge),0, BindingMode.OneWay, propertyChanged: OnNumberBadgeChanged);
        public int NumberBadge
        {
            get { return (int)GetValue(NumberBadgeProperty); }
            set { SetValue(NumberBadgeProperty, value); }
        }
        private static void OnNumberBadgeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (bindable as Badge);
            if (newValue != null && newValue != oldValue && newValue is int number)
            {
                control.BadgeLabel.Text = number.ToString();
            }

        }
        #endregion
        #region Image Source Proprety
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(Badge),string.Empty, BindingMode.OneWay, propertyChanged: OnImageSourceChanged);
        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        private static void OnImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (bindable as Badge);
            if (newValue != null && newValue != oldValue)
            {
                control.BadgeImage.Source = newValue.ToString();
            }

        }
        #endregion
        #region Text Proprety
        public static readonly BindableProperty TextImageProperty = BindableProperty.Create(nameof(TextImage), typeof(string), typeof(Badge), string.Empty, BindingMode.OneWay, propertyChanged: OnTextImageChanged);
        public string TextImage
        {
            get { return (string)GetValue(TextImageProperty); }
            set { SetValue(TextImageProperty, value); }
        }
        private static void OnTextImageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (bindable as Badge);
            if (newValue != null && newValue != oldValue)
            {
                control.ImageLabel.Text = newValue.ToString();
            }

        }
        #endregion
        #region Text Image Size Proprety
        public static readonly BindableProperty TextImageSizeProperty = BindableProperty.Create(nameof(TextImageSize), typeof(NamedSize), typeof(Badge), NamedSize.Small, BindingMode.OneWay, propertyChanged: OnTextImageSizeChanged);
        public NamedSize TextImageSize
        {
            get { return (NamedSize)GetValue(TextImageSizeProperty); }
            set { SetValue(TextImageSizeProperty, value); }
        }
        private static void OnTextImageSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (bindable as Badge);
            if (newValue != null && newValue != oldValue && newValue is double size)
            {
                FontSizeConverter myFontSizeConverter = new FontSizeConverter();
                control.ImageLabel.FontSize = (Double)myFontSizeConverter.ConvertFromInvariantString(size.ToString());
            }

        }
        #endregion
        #region Text Image Size Proprety
        public static readonly BindableProperty TextBadgeSizeProperty = BindableProperty.Create(nameof(TextBadgeSize), typeof(NamedSize), typeof(Badge), NamedSize.Small, BindingMode.OneWay, propertyChanged: OnTextBadgeSizeChanged);
        public NamedSize TextBadgeSize
        {
            get { return (NamedSize)GetValue(TextBadgeSizeProperty); }
            set { SetValue(TextBadgeSizeProperty, value); }
        }
        private static void OnTextBadgeSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (bindable as Badge);
            if (newValue != null && newValue != oldValue && newValue is double size)
            {
                FontSizeConverter myFontSizeConverter = new FontSizeConverter();
                control.ImageLabel.FontSize = (Double)myFontSizeConverter.ConvertFromInvariantString(size.ToString());
            }

        }
        #endregion
        public Badge()
        {
            InitializeComponent();
        }
    }
}