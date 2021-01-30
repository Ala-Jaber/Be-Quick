using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace BeQuik.ViewModels
{
    public class MapDriverViewModel:BaseViewModel, IMasterCommonViewModel
    {
        public FlyoutPage Page { get; }
        public Command TrunOnOffCommand { get; }
        public Command MenuShow { get; }
        public Command OpenWalletCommand { get; }
        public Command OpenProfileCommand { get; }
        public Command LogoutCommand { get; }
        public Command ToggelTripCommand { get; }
        public Command ToggelDisplayCancelRideCommand { get; }
        public Command CancelRideCommand { get; }


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

        private string _TextTripButton = Utils.LocalizationResourceManager.Instance.GetValue("Start_Trip");
        public string TextTripButton
        {
            get { return _TextTripButton; }
            set { _TextTripButton = value; OnPropertyChanged(); }
        }
        private bool _IsShowTripInfromation=true;
        public bool IsShowTripInfromation
        {
            get { return _IsShowTripInfromation; }
            set { _IsShowTripInfromation = value; OnPropertyChanged(); }
        }
        private bool _IsShowCancelRide;
        public bool IsShowCancelRide
        {
            get { return _IsShowCancelRide; }
            set { _IsShowCancelRide = value; OnPropertyChanged(); }
        }



        public MapDriverViewModel()
        {
            InitMenuItem();
            InitOrders();
            LogoutCommand = new Command(Logout);
            ToggelTripCommand = new Command(ToggelTrip);
            OpenProfileCommand = new Command(() => new ViewModels.ProfilePageViewModel());
            OpenWalletCommand = new Command(() => new ViewModels.WalletPageViewModel());
            ToggelDisplayCancelRideCommand = new Command(() => SetShowCancelRide(!IsShowCancelRide));
            CancelRideCommand = new Command(() => {TextTripButton = Utils.LocalizationResourceManager.Instance.GetValue("Start_Trip"); IsShowTripInfromation = false; SetShowCancelRide(false); });
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
            IsReceiveNewOrder = true;
        }
        private void ToggelTrip()
        {
            IsShowTripInfromation = !TextTripButton.Equals(Utils.LocalizationResourceManager.Instance.GetValue("End_Trip"));
            TextTripButton = Utils.LocalizationResourceManager.Instance.GetValue("Start_Trip");
        }
        public void SetShowCancelRide(bool show)
        {
            IsShowCancelRide = show;
            OnPropertyChanged(nameof(IsShowCancelRide));
        }
        private void InitMenuItem()
        {
            MenuItems = new List<Model.MenuItem>
            {                
                new Model.MenuItem{ImageSource="profile_gray.png" ,Text=Utils.LocalizationResourceManager.Instance.GetValue("Profile"),Command=new Command(()=> new ViewModels.ProfilePageViewModel())},
                new Model.MenuItem{ImageSource="calendar.png" ,Text=Utils.LocalizationResourceManager.Instance.GetValue("Booking_history"),Command=new Command(()=> new ViewModels.BookingHistoryViewModel())},
                new Model.MenuItem{ImageSource="digital_wallet_g.png" ,Text=Utils.LocalizationResourceManager.Instance.GetValue("Your_wallet"),Command=new Command(()=> new ViewModels.WalletPageViewModel())},
                new Model.MenuItem{ImageSource="headphones.png" ,Text=Utils.LocalizationResourceManager.Instance.GetValue("Contact_us"),Command=new Command(()=> new ViewModels.ContactUsViewModel())},
            };
        }
        private void InitOrders()
        {
            Orders ??= new ObservableCollection<Model.Order>();
            Orders.Add(new Model.Order { FirstName = "Ala'", LastName= "Jaber", PhoneNumber = "00962785461900", Address = "Irbid", Position = new Position(36.9628066, -122.0194722), IsServiced = false });
            Orders.Add(new Model.Order { FirstName = "Ala'", LastName= "Jaber", PhoneNumber = "00962785461900", Address = "Irbid", Position = new Position(36.9628066, -122.0194722), IsServiced = false });
            Orders.Add(new Model.Order { FirstName = "Ala'", LastName= "Jaber", PhoneNumber = "00962785461900", Address = "Irbid", Position = new Position(36.9628066, -122.0194722), IsServiced = false });
            Orders.Add(new Model.Order { FirstName = "Ala'", LastName= "Jaber", PhoneNumber = "00962785461900", Address = "Irbid", Position = new Position(36.9628066, -122.0194722), IsServiced = false });
            Orders.Add(new Model.Order { FirstName = "Ala'", LastName = "Jaber", PhoneNumber = "00962785461900", Address = "Irbid", Position = new Position(36.9628066, -122.0194722), IsServiced = false });
        }
        private void Logout()
        {
            new ViewModels.LoginViewModel();
        }

    }
}
