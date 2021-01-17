using BeQuik.Resources;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
using Xamarin.Essentials;

namespace BeQuik.Utils
{
    public class LocalizationResourceManager : INotifyPropertyChanged
    {
        private const string LanguageKey = nameof(LanguageKey);
        public CultureInfo CultureInfoArabic { get; set; }
        public CultureInfo CultureInfoEnglish { get; set; }
        public static LocalizationResourceManager Instance { get; } = new LocalizationResourceManager();

        private LocalizationResourceManager()
        {
            CultureInfoArabic = new CultureInfo("ar-JO");
            CultureInfoEnglish = new CultureInfo("en-US");
            SetCulture(new CultureInfo(Preferences.Get(LanguageKey, CurrentCulture.TwoLetterISOLanguageName)));
        }
        public string this[string text]
        {
            get
            {
                return Resource.ResourceManager.GetString(text, Resource.Culture);
            }
        }
        public void SetCulture(CultureInfo language)
        {
            Thread.CurrentThread.CurrentUICulture = language;
            Resource.Culture = language;
            Preferences.Set(LanguageKey, language.TwoLetterISOLanguageName);

            Invalidate();
        }
        public string GetValue(string key)
        {
            return Resource.ResourceManager.GetString(key, Resource.Culture);
        }
        public string GetValue(string key, string ResourceId)
        {
            ResourceManager resourceManager = new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly);
            return resourceManager.GetString(key, CultureInfo.CurrentCulture);
        }

        public CultureInfo CurrentCulture => Resource.Culture ?? Thread.CurrentThread.CurrentUICulture;
        public event PropertyChangedEventHandler PropertyChanged;
        public void Invalidate()
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
