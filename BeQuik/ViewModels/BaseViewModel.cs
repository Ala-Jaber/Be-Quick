using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BeQuik.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        private string _LanguageSelected;
        public string LanguageSelected
        {
            get { return _LanguageSelected; }
            set { _LanguageSelected = value; OnPropertyChanged(); }
        }

        public Command SetArabicLanguageCommand { get; }
        public Command SetEnglishLanguageCommand { get; }
        public Command ToggelLanguageCommand { get; }
        public event EventHandler LanguageHasChanged;
        public BaseViewModel()
        {
            LanguageSelected = Xamarin.Essentials.Preferences.Get("LanguageKey", System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName) == "ar" ? "العربية" : "English";
            SetArabicLanguageCommand = new Command(() => { Utils.LocalizationResourceManager.SetArabicCulture(); LanguageSelected = "العربية"; });
            SetEnglishLanguageCommand = new Command(() => { Utils.LocalizationResourceManager.SetEnglishCulture(); LanguageSelected = "English"; });
            ToggelLanguageCommand = new Command(() =>
            {
                if (LanguageSelected == "العربية")
                { Utils.LocalizationResourceManager.SetEnglishCulture(); LanguageSelected = "English"; }
                else
                { Utils.LocalizationResourceManager.SetArabicCulture(); LanguageSelected = "العربية"; }
                LanguageHasChanged?.Invoke(this,null);
            });
        }
        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        public async Task OpenPage(Page page)
        {
            page.BindingContext = this;
            page.SetBinding(VisualElement.FlowDirectionProperty, new Binding("FlowDirection", source: Utils.LocalizationResourceManager.Instance));

            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
        public void OpenAsRootPage(Page page)
        {
            page.BindingContext = this;
            page.SetBinding(VisualElement.FlowDirectionProperty, new Binding("FlowDirection", source: Utils.LocalizationResourceManager.Instance));

            Application.Current.MainPage = new NavigationPage(page);
        }
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
