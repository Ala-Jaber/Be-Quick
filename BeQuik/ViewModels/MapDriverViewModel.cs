using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BeQuik.ViewModels
{
    public class MapDriverViewModel:BaseViewModel
    {
        public FlyoutPage Page { get; }
        public Command MenuShow { get; }
        public List<Model.MenuItem> MenuItems { get; set; }
        public static Action<bool> ShowDriverWalletEmptyError;
        public MapDriverViewModel()
        {
            InitMenuItem();
            MenuShow = new Command(ShowMenu);
            Page = new Views.MasterDetailView(new Views.MapDriverView());
            OpenAsRootPage(Page);

            //Optional Code
            Device.StartTimer(TimeSpan.FromSeconds(5), () => { ShowDriverWalletEmptyError?.Invoke(true); return false; });
            Device.StartTimer(TimeSpan.FromSeconds(40), () => { ShowDriverWalletEmptyError?.Invoke(false); return false; });
        }
        private void ShowMenu() => Page.IsPresented = true;

        private void InitMenuItem()
        {
            MenuItems = new List<Model.MenuItem>
            {
                new Model.MenuItem{ImageSource="calendar.png" ,Text="Booking history",Command=new Command(()=> new ViewModels.BookingHistoryViewModel())},
                new Model.MenuItem{ImageSource="digital_wallet_g.png" ,Text="Your wallet",Command=new Command(()=> new ViewModels.WalletPageViewModel())},
                new Model.MenuItem{ImageSource="headphones.png" ,Text="Contact us",Command=new Command(()=> new ViewModels.ContactUsViewModel())},
                new Model.MenuItem{ImageSource="question.png" ,Text="Help",Command=new Command(()=> new ViewModels.HelpPageViewModel())},
            };
        }
    }
}
