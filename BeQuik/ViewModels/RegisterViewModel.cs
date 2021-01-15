using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BeQuik.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public Command SendVerficationCodeCommand { get; }
        private string _PhoneNumber;
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; OnPropertyChanged(); }
        }


        public RegisterViewModel()
        {
            SendVerficationCodeCommand = new Command(OnSendVerficationCodeClicked);
            OpenPage(new Views.RegisterPage()).ConfigureAwait(false);
        }

        private void OnSendVerficationCodeClicked(object obj)
        {
            new ViewModels.VerficationViewModel(PhoneNumber);
        }
    }
}
