using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace BeQuik.ViewModels
{
    public class BookingHistoryViewModel: BaseViewModel
    {
        private ObservableCollection<Model.Order> _OrdersHistory;
        public ObservableCollection<Model.Order> OrdersHistory
        {
            get { return _OrdersHistory; }
            set { _OrdersHistory = value; OnPropertyChanged(); }
        }
        private string _ActiveTabName;
        public string ActiveTabName
        {
            get { return _ActiveTabName; }
            set { _ActiveTabName = value; OnPropertyChanged(); }
        }

        public Command ChangeActiveTabCommand { get; set; }
        public BookingHistoryViewModel()
        {
            ActiveTabName = "Weekly";
            OrdersHistory = new ObservableCollection<Model.Order>();
            ChangeActiveTabCommand = new Command(ChangeActiveTab);
            OpenPage(new Views.BookingHistoryPage());
        }
        private void ChangeActiveTab()
        {
            var PreviousActiveTabName = ActiveTabName;
            if(PreviousActiveTabName == "Weekly")
            {
                OrdersHistory.Clear();
                ActiveTabName = "Monthly";
            }
            else
            {
                OrdersHistory.Add(new Model.Order { Date = DateTime.Now, ImageSource = "delivery", OrderID = 258, Price = 1.25, Type = Enums.ServiceType.Delivery });
                OrdersHistory.Add(new Model.Order { Date = DateTime.Now, ImageSource = "tow_truck", OrderID = 258, Price = 1.25, Type = Enums.ServiceType.Winch });
                OrdersHistory.Add(new Model.Order { Date = DateTime.Now, ImageSource = "delivery", OrderID = 258, Price = 1.25, Type = Enums.ServiceType.Delivery });
                OrdersHistory.Add(new Model.Order { Date = DateTime.Now, ImageSource = "delivery", OrderID = 258, Price = 1.25, Type = Enums.ServiceType.Delivery });
                OrdersHistory.Add(new Model.Order { Date = DateTime.Now, ImageSource = "gas", OrderID = 258, Price = 1.25, Type = Enums.ServiceType.Gas });
                OrdersHistory.Add(new Model.Order { Date = DateTime.Now, ImageSource = "taxi", OrderID = 258, Price = 1.25, Type = Enums.ServiceType.Taxi });

                ActiveTabName = "Weekly";
            }
        }
    }
}