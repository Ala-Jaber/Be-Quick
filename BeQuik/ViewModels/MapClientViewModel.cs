using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using XF.Material.Forms.UI.Dialogs;

namespace BeQuik.ViewModels
{
    public class MapClientViewModel : BaseViewModel, IMasterCommonViewModel
    {
        public FlyoutPage Page { get;}
        public Command MenuShow { get; }
        public Command RequestServiceCommand { get; }
        public Command EnterPromoCodeCommand { get; }
        public Command OpenProfileCommand { get; }
        public Command OpenWalletCommand { get; }
        public Command LogoutCommand { get; }


        public string PromotionCode { get; set; }
        public bool IsPromotionCodeAdded { get; set; }
        public List<Model.MenuItem> MenuItems { get; set; }

        public static Action<string,bool,bool> ShowMessageAlert { get; set; }
        public static Func<Position> GetPositionSelected { get; set; }

        public MapClientViewModel()
        {
            InitMenuItem(); 
            LogoutCommand = new Command(Logout);
            OpenProfileCommand = new Command(() => new ViewModels.ProfilePageViewModel());
            OpenWalletCommand = new Command(() => new ViewModels.WalletPageViewModel());
            MenuShow = new Command(ShowMenu);
            RequestServiceCommand = new Command(RequestService);
            EnterPromoCodeCommand = new Command(()=> ShowDialogEnterPromoCode());
            Page = new Views.MasterDetailView(new Views.MapClientView());
            OpenAsRootPage(Page);
        }
        private void InitMenuItem()
        {
            MenuItems = new List<Model.MenuItem>
            {
                new Model.MenuItem{ImageSource="calendar.png" ,Text=Utils.LocalizationResourceManager.Instance.GetValue("Booking_history"),Command=new Command(()=> new ViewModels.BookingHistoryViewModel())},
                new Model.MenuItem{ImageSource="digital_wallet_g.png" ,Text=Utils.LocalizationResourceManager.Instance.GetValue("Your_wallet"),Command=new Command(()=> new ViewModels.WalletPageViewModel())},
                new Model.MenuItem{ImageSource="headphones.png" ,Text=Utils.LocalizationResourceManager.Instance.GetValue("Contact_us"),Command=new Command(()=> new ViewModels.ContactUsViewModel())},
            };
        }
        private void ShowMenu() => Page.IsPresented = true; 
        private void RequestService()
        {
            if(GetPositionSelected.Method != null)
            new ViewModels.TracingServiceViewModel(GetPositionSelected());
        }
        private async Task ShowDialogEnterPromoCode()
        {
            var input = await MaterialDialog.Instance.InputAsync(
                                                        title: Utils.LocalizationResourceManager.Instance.GetValue("Promotion_code"),
                                                        message: Utils.LocalizationResourceManager.Instance.GetValue("Enter_promotion_code"),
                                                        inputPlaceholder: Utils.LocalizationResourceManager.Instance.GetValue("Code"),
                                                        dismissiveText: Utils.LocalizationResourceManager.Instance.GetValue("Cancel"),
                                                        confirmingText: Utils.LocalizationResourceManager.Instance.GetValue("Confirme"),
                                                        configuration: App.GetMaterialInputDialogConfiguration());
            if (!string.IsNullOrEmpty(input)) {
                IsPromotionCodeAdded = IsValidPromotionCode(input);
                if (IsPromotionCodeAdded)
                {
                    PromotionCode = input;
                    OnPropertyChanged(nameof(PromotionCode));
                    OnPropertyChanged(nameof(IsPromotionCodeAdded));
                }
                var MessageText = IsPromotionCodeAdded ? Utils.LocalizationResourceManager.Instance.GetValue("Promoation_Code_is_Added_Successfully") :
                                                         Utils.LocalizationResourceManager.Instance.GetValue("Promoation_Code_is_Invalide_Sorry");
                ShowMessageAlert?.Invoke(MessageText, IsPromotionCodeAdded, true);
                Device.StartTimer(TimeSpan.FromSeconds(15), () => { ShowMessageAlert?.Invoke(MessageText, IsPromotionCodeAdded, false); return false; });
            }
        }
        private bool IsValidPromotionCode(string code)
        {
            return true;
        }
        private void Logout()
        {
            new ViewModels.LoginViewModel();
        }

    }
}
