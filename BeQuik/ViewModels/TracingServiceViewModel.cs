using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace BeQuik.ViewModels
{
    public class TracingServiceViewModel : BaseViewModel
    {
        public Command AcceptAlertArrivedDeriverCommand { get; }
        public Command ToggelDisplayCancelRideCommand { get; }
        public Command CancelRideCommand { get; }
        public Command CallCommand { get; }
        public Command MessageCommand { get; }
        public bool IsShowCancelRide { get; set; } = false;
        public static Action<Enums.PinType, Position> UpdateLocationDriver { get; set; }
        public TracingServiceViewModel(Xamarin.Forms.GoogleMaps.Position position)
        {
            AcceptAlertArrivedDeriverCommand = new Command(HidePoupArrivedDriver);
            ToggelDisplayCancelRideCommand = new Command(() => SetShowCancelRide(!IsShowCancelRide));
            CancelRideCommand = new Command(()=> OnCancelRide());
            CallCommand = new Command(OnCall);
            MessageCommand = new Command(OnMessage);

            OpenPage(new Views.TracingServicePage(position)).ConfigureAwait(false);
        }
        public async Task OnCancelRide() {
            await Application.Current.MainPage.Navigation.PopToRootAsync();
        }
        public void OnCall() {
        }
        public void OnMessage() { 
        }
        public void SetShowCancelRide(bool show)
        {
            IsShowCancelRide = show;
            OnPropertyChanged(nameof(IsShowCancelRide));
        }
        public void SetShowPopupArrivedDeriver()
        {
            PopupNavigation.Instance.PushAsync(new Views.PopupViews.AlertDriverArrived() { BindingContext = this });
        }
        public void HidePoupArrivedDriver() 
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}