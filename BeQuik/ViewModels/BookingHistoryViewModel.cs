using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace BeQuik.ViewModels
{
    public class BookingHistoryViewModel: BaseViewModel
    {
        private ObservableCollection<Model.BookingOrder> _OrdersWeeklyHistory;
        public ObservableCollection<Model.BookingOrder> OrdersWeeklyHistory
        {
            get { return _OrdersWeeklyHistory; }
            set { _OrdersWeeklyHistory = value; OnPropertyChanged(); }
        }
        private ObservableCollection<Model.BookingOrder> _OrdersMonthlyHistory;
        public ObservableCollection<Model.BookingOrder> OrdersMonthlyHistory
        {
            get { return _OrdersMonthlyHistory; }
            set { _OrdersMonthlyHistory = value; OnPropertyChanged(); }
        }
        private string _ActiveTabName;
        public string ActiveTabName
        {
            get { return _ActiveTabName; }
            set { _ActiveTabName = value; OnPropertyChanged(); }
        }

        public Command ChangeActiveTabCommand { get; set; }
        public Command ShowDetailsCommand { get; set; }
        public Command BackCommand { get; set; }
        public BookingHistoryViewModel()
        {
            ActiveTabName = "Weekly";
            OrdersWeeklyHistory = new ObservableCollection<Model.BookingOrder>();
            FullListOrder();
            ChangeActiveTabCommand = new Command(ChangeActiveTab);
            ShowDetailsCommand = new Command((e) => ShowDetailsPopup(e as Model.BookingOrder));
            BackCommand = new Command(BackButtonPressed);
            OpenPage(new Views.BookingHistoryPage());
        }
        private void ChangeActiveTab()
        {
            var PreviousActiveTabName = ActiveTabName;
            if(PreviousActiveTabName == "Weekly")
            {
                ActiveTabName = "Monthly";
            }
            else
            {
                FullListOrder();
                ActiveTabName = "Weekly";
            }
        }
        private void ShowDetailsPopup(Model.BookingOrder Order)
        {
            var view = new Views.PopupViews.OrderDetails();
            view.BindingContext = Order;
            view.SetBinding(VisualElement.FlowDirectionProperty, new Binding("FlowDirection", source: Utils.LocalizationResourceManager.Instance));
            PopupNavigation.Instance.PushAsync(view);
        }
        private void BackButtonPressed()=> Application.Current.MainPage.Navigation.PopAsync();
        private void FullListOrder()
        {
            OrdersMonthlyHistory ??= new ObservableCollection<Model.BookingOrder>();
            OrdersMonthlyHistory.Add(new Model.BookingOrder { Date = DateTime.Now, ImageSource = "delivery", OrderID = 258, Price = 1.25, Type = Enums.ServiceType.Delivery });
            OrdersMonthlyHistory.Add(new Model.BookingOrder { Date = DateTime.Now, ImageSource = "tow_truck", OrderID = 208, Price = 10.75, Type = Enums.ServiceType.Winch });
            OrdersMonthlyHistory.Add(new Model.BookingOrder { Date = DateTime.Now, ImageSource = "delivery", OrderID = 158, Price = 1.00, Type = Enums.ServiceType.Delivery });
            OrdersMonthlyHistory.Add(new Model.BookingOrder { Date = DateTime.Now, ImageSource = "delivery", OrderID = 220, Price = 1.15, Type = Enums.ServiceType.Delivery });
            OrdersMonthlyHistory.Add(new Model.BookingOrder { Date = DateTime.Now, ImageSource = "gas", OrderID = 262, Price = 20.05, Type = Enums.ServiceType.Gas });
            OrdersMonthlyHistory.Add(new Model.BookingOrder { Date = DateTime.Now, ImageSource = "taxi", OrderID = 118, Price = 75.00, Type = Enums.ServiceType.Taxi });
        }
    }
}