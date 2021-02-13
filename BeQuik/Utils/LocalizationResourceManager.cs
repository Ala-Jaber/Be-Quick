using BeQuik.Resources;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BeQuik.Utils
{
    public class LocalizationResourceManager : NotifyPropertyChanged
    {
        public static LocalizationResourceManager Instance { get; } = new LocalizationResourceManager();
        public FlowDirection FlowDirection { get; set; }

        private const string LanguageKey = nameof(LanguageKey);
        private CultureInfo CurrentCulture => Thread.CurrentThread.CurrentUICulture ?? Resource.Culture;
        private LocalizationResourceManager()
        {
            ChangeCulture(new CultureInfo(Preferences.Get(LanguageKey, Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName)));
        }
        public string this[string text]
        {
            get
            {
                return Resource.ResourceManager.GetString(text, Resource.Culture);
            }
        }
        public string GetValue(string key)
        {
            return Resource.ResourceManager.GetString(key, Resource.Culture);
        }
        public static void SetArabicCulture() => Instance.ChangeCulture(new CultureInfo("ar-JO"));
        public static void SetEnglishCulture() => Instance.ChangeCulture(new CultureInfo("en-US"));
        private void ChangeCulture(CultureInfo language)
        {
            Thread.CurrentThread.CurrentUICulture = Resource.Culture = language;
            SetFlowDirection();
            Preferences.Set(LanguageKey, language.TwoLetterISOLanguageName);
        }
        private void SetFlowDirection()
        {
            FlowDirection = Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft ? 
                                FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            Invalidate();
        }

    }
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void Invalidate()
        {
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
            catch
            {

            }
        }
    }
}
