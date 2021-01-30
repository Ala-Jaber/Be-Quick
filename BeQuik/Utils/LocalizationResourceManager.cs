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
        private CultureInfo CurrentCulture => Resource.Culture ?? Thread.CurrentThread.CurrentUICulture;
        private LocalizationResourceManager()
        {
            SetCulture(new CultureInfo(Preferences.Get(LanguageKey, CurrentCulture.TwoLetterISOLanguageName)));
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
        public static void SetArabicCulture() => Instance.SetCulture(new CultureInfo("ar-JO"));
        public static void SetEnglishCulture() => Instance.SetCulture(new CultureInfo("en-US"));
        private void SetCulture(CultureInfo language)
        {
            Thread.CurrentThread.CurrentUICulture = language;
            Resource.Culture = language;
            FlowDirection = GetFlowDirection();
            Invalidate();
            Preferences.Set(LanguageKey, language.TwoLetterISOLanguageName);
        }
        private FlowDirection GetFlowDirection()
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
