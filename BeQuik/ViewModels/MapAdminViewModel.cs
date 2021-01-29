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

        public MapAdminViewModel()
        {
            InitMenuItem();
            OpenProfileCommand = new Command(OpenProfilePage);
            MenuShow = new Command(ShowMenu);
            Page = new Views.MasterDetailView(new Views.MapAdminView());
            OpenAsRootPage(Page);
        }
        private void InitMenuItem()
        {
            MenuItems = new List<Model.MenuItem>
            {
                new Model.MenuItem{ImageSource="calendar.png" ,Text="Booking history",Command=new Command(()=> new ViewModels.BookingHistoryViewModel())},
                new Model.MenuItem{ImageSource="digital_wallet_g.png" ,Text="Your wallet",Command=new Command(()=> new ViewModels.WalletPageViewModel())},
                new Model.MenuItem{ImageSource="money_discount_gray.png" ,Text="Balance code operation",Command=new Command(()=> new ViewModels.BalanceCodeOperationViewModel())},
                new Model.MenuItem{ImageSource="permission.png" ,Text="Permission",Command=new Command(()=> new ViewModels.PermissionViewModel())},
                new Model.MenuItem{ImageSource="admin.png" ,Text="Administration",Command=new Command(()=> new ViewModels.AdministrationViewModel())},
                new Model.MenuItem{ImageSource="money_discount_gray.png" ,Text="Balance operation",Command=new Command(()=> new ViewModels.BalanceOperationViewModel())},
                new Model.MenuItem{ImageSource="money_collector_operation.png" ,Text="Collector operation",Command=new Command(()=> new ViewModels.CollectorOperationViewModel())},
                new Model.MenuItem{ImageSource="price_tag.png" ,Text="Pricing",Command=new Command(()=> new ViewModels.PricingViewModel())},
                new Model.MenuItem{ImageSource="analysis_report.png" ,Text="Analysis report",Command=new Command(()=> new ViewModels.AnalysisReportViewModel())},
            };
        }
        private void ShowMenu() => Page.IsPresented = true;
        private void OpenProfilePage()
        {
            new ViewModels.ProfilePageViewModel();
        }
    }
}
