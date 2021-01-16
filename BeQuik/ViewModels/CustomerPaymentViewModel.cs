using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BeQuik.ViewModels
{
    public class CustomerPaymentViewModel : BaseViewModel
    {
        public Command BackButtonCommand { get; }
        public Command ConfirmePaymentCommand { get; }
        public CustomerPaymentViewModel()
        {
            BackButtonCommand = new Command(BackButtonClicked);
            ConfirmePaymentCommand = new Command(ConfirmePaymentClick);
            OpenPage(new Views.CustomerPaymentPage());
        }
        public void BackButtonClicked()
        {
            try
            {
                Application.Current.MainPage.Navigation.PopAsync();
            }
            catch
            {

            }
        }
        public void ConfirmePaymentClick()
        {
            new ViewModels.CustomerRateViewModel();
        }
    }
}
