using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace BeQuik.ViewModels
{
    public class MapDriverViewModel:BaseViewModel
    {
        public FlyoutPage Page { get; }
        public Command TrunOnOffCommand { get; }
        public Command MenuShow { get; }
        public List<Model.MenuItem> MenuItems { get; set; }
        public ObservableCollection<Model.Order> Orders { get; set; }
        public static Action<bool> ShowDriverWalletEmptyError;
        private bool _TrunOnOff;
        public bool TrunOnOff
        {
            get { return _TrunOnOff; }
            set { _TrunOnOff = value; OnPropertyChanged(); }
        }
        private bool _IsReceiveNewOrder;
        public bool IsReceiveNewOrder
        {
            get { return _IsReceiveNewOrder; }
            set { _IsReceiveNewOrder = value; OnPropertyChanged(); }
        }
        private string _TextButton = "Show Order List";
        public string TextButton
        {
            get { return _TextButton; }
            set { _TextButton = value; OnPropertyChanged(); }
        }

        public MapDriverViewModel()
        {
            InitMenuItem();
            InitOrders();
            MenuShow = new Command(ShowMenu);
            TrunOnOffCommand = new Command(() => TrunOnOff = !TrunOnOff);
            Page = new Views.MasterDetailView(new Views.MapDriverView());
            OpenAsRootPage(Page);

            //Optional Code
            Device.StartTimer(TimeSpan.FromSeconds(5), () => { ShowDriverWalletEmptyError?.Invoke(true); return false; });
            Device.StartTimer(TimeSpan.FromSeconds(10), () => { ReceiveNewOrder(); return false; });
            Device.StartTimer(TimeSpan.FromSeconds(40), () => { ShowDriverWalletEmptyError?.Invoke(false); return false; });
        }
        private void ShowMenu() => Page.IsPresented = true;
        private void ReceiveNewOrder()
        {
            TextButton = "Show Order Request";
            IsReceiveNewOrder = true;
        }
        private void InitMenuItem()
        {
            MenuItems = new List<Model.MenuItem>
            {
                new Model.MenuItem{ImageSource="calendar.png" ,Text="Booking history",Command=new Command(()=> new ViewModels.BookingHistoryViewModel())},
                new Model.MenuItem{ImageSource="digital_wallet_g.png" ,Text="Your wallet",Command=new Command(()=> new ViewModels.WalletPageViewModel())},
                //new Model.MenuItem{ImageSource="headphones.png" ,Text="Contact us",Command=new Command(()=> new ViewModels.ContactUsViewModel())},
                //new Model.MenuItem{ImageSource="question.png" ,Text="Help",Command=new Command(()=> new ViewModels.HelpPageViewModel())},
            };
        }
        private void InitOrders()
        {
            Orders ??= new ObservableCollection<Model.Order>();
            Orders.Add(new Model.Order { PhoneNumber = "00962785461900", Address = "Irbid", Position = new Position(36.9628066, -122.0194722), IsServiced = false });
            Orders.Add(new Model.Order { PhoneNumber = "00962785461900", Address = "Irbid", Position = new Position(36.9628066, -122.0194722), IsServiced = false });
            Orders.Add(new Model.Order { PhoneNumber = "00962785461900", Address = "Irbid", Position = new Position(36.9628066, -122.0194722), IsServiced = false });
            Orders.Add(new Model.Order { PhoneNumber = "00962785461900", Address = "Irbid", Position = new Position(36.9628066, -122.0194722), IsServiced = false });
            Orders.Add(new Model.Order { PhoneNumber = "00962785461900", Address = "Irbid", Position = new Position(36.9628066, -122.0194722), IsServiced = false });
        }
    }
}
