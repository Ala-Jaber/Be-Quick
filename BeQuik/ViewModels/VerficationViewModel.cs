using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BeQuik.ViewModels
{
    public class VerficationViewModel:BaseViewModel
    {
        public TimeSpan TimeAtTrySendMessage { get; set; }
        public string PhoneNumber { get; set; }
        public TimeSpan RemainTime { get; set; } = TimeSpan.FromSeconds(60);
        public Command TrySendVerifivationCodeAgain { get; }
        public VerficationViewModel(string phonenumber)
        {
            this.PhoneNumber = phonenumber;
            OpenPage(new Views.VerficationPage());
            TrySendVerifivationCodeAgain = new Command(SendVerifivationCodeAgain);
            ShowRemainTimer();
        }
        public void SendVerifivationCodeAgain() 
        {
            if (RemainTime != TimeSpan.Zero) return;
            RemainTime = TimeSpan.FromSeconds(60); OnPropertyChanged(nameof(RemainTime));
            ShowRemainTimer();
        }
        private bool CalculateRemainTime()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var StanderTime = TimeSpan.FromSeconds(60);
                var TimeAgo = DateTime.Now.TimeOfDay.Subtract(TimeAtTrySendMessage);
                var TimeRe = StanderTime.Subtract(TimeAgo);
                if (TimeRe.TotalSeconds > 0)
                { RemainTime = TimeRe; OnPropertyChanged(nameof(RemainTime)); }
                else
                { RemainTime = TimeSpan.Zero; OnPropertyChanged(nameof(RemainTime)); }
            });
            return RemainTime != TimeSpan.Zero;
        }
        private void ShowRemainTimer()
        {
            TimeAtTrySendMessage = DateTime.Now.TimeOfDay;
            Device.StartTimer(TimeSpan.FromMilliseconds(500), CalculateRemainTime);
        }
    }
}
