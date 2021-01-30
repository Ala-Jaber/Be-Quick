using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BeQuik.ViewModels
{
    public class MapAdminViewModel : BaseViewModel, IMasterCommonViewModel
    {
        public FlyoutPage Page { get; }
        public Command MenuShow { get; }
        public List<Model.MenuItem> MenuItems { get; set; }
        public Command OpenProfileCommand { get ; }
        public Command LogoutCommand { get; }


        public MapAdminViewModel()
        {
            InitMenuItem();
            LogoutCommand = new Command(Logout);
            OpenProfileCommand = new Command(OpenProfilePage);
            MenuShow = new Command(ShowMenu);
            Page = new Views.MasterDetailView(new Views.MapAdminView());
            OpenAsRootPage(Page);
        }
        private void InitMenuItem()
        {
            MenuItems = new List<Model.MenuItem>
            {
                new Model.MenuItem{ImageSource="calendar_white.png" ,Text=Utils.LocalizationResourceManager.Instance.GetValue("Booking_history"),Command=new Command(()=> new ViewModels.BookingHistoryViewModel())},
                new Model.MenuItem{ImageSource="digital_wallet_white.png" ,Text=Utils.LocalizationResourceManager.Instance.GetValue("Your_wallet"),Command=new Command(()=> new ViewModels.WalletPageViewModel())},
                new Model.MenuItem{ImageSource="money_discount_white.png" ,Text=Utils.LocalizationResourceManager.Instance.GetValue("Balance_code_operation"),Command=new Command(()=> new ViewModels.BalanceCodeOperationViewModel())},
                new Model.MenuItem{ImageSource="permission_white.png" ,Text=Utils.LocalizationResourceManager.Instance.GetValue("Permission"),Command=new Command(()=> new ViewModels.PermissionViewModel())},
                new Model.MenuItem{ImageSource="admin_white.png" ,Text=Utils.LocalizationResourceManager.Instance.GetValue("Administration"),Command=new Command(()=> new ViewModels.AdministrationViewModel())},
                new Model.MenuItem{ImageSource="scale_white.png" ,Text=Utils.LocalizationResourceManager.Instance.GetValue("Balance_operation"),Command=new Command(()=> new ViewModels.BalanceOperationViewModel())},
                new Model.MenuItem{ImageSource="money_collector_operation_white.png" ,Text=Utils.LocalizationResourceManager.Instance.GetValue("Collector_operation"),Command=new Command(()=> new ViewModels.CollectorOperationViewModel())},
                new Model.MenuItem{ImageSource="price_tag_white.png" ,Text=Utils.LocalizationResourceManager.Instance.GetValue("Pricing"),Command=new Command(()=> new ViewModels.PricingViewModel())},
                new Model.MenuItem{ImageSource="analysis_report_white.png" ,Text=Utils.LocalizationResourceManager.Instance.GetValue("Analysis_report"),Command=new Command(()=> new ViewModels.AnalysisReportViewModel())},
            };
        }
        private void ShowMenu() => Page.IsPresented = true;
        private void OpenProfilePage()
        {
            new ViewModels.ProfilePageViewModel();
        }
        private void Logout()
        {
            new ViewModels.LoginViewModel();
        }

    }
}
