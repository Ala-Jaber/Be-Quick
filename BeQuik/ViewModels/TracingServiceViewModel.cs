using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BeQuik.ViewModels
{
    public class TracingServiceViewModel : BaseViewModel
    {
        public Command ToggelDisplayPopupArrivedDeriverCommand { get; }
        public Command ToggelDisplayCancelRideCommand { get; }
        public Command CancelRideCommand { get; }
        public Command CallCommand { get; }
        public Command MessageCommand { get; }
        public bool IsShowCancelRide { get; set; } = false;
        public bool IsPopupArrivedDeriver { get; set; } = true;
        public TracingServiceViewModel()
        {
            ToggelDisplayCancelRideCommand = new Command(() => SetShowCancelRide(!IsShowCancelRide));
            ToggelDisplayPopupArrivedDeriverCommand = new Command(() => SetShowPopupArrivedDeriver(!IsPopupArrivedDeriver));
            CancelRideCommand = new Command(()=> OnCancelRide());
            CallCommand = new Command(OnCall);
            MessageCommand = new Command(OnMessage);

            OpenPage(new Views.TracingServicePage()).ConfigureAwait(false);
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
        public void SetShowPopupArrivedDeriver(bool show)
        {
            IsPopupArrivedDeriver = show;
            OnPropertyChanged(nameof(IsPopupArrivedDeriver));
        }
    }
}