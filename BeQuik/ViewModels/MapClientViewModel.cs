﻿using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace BeQuik.ViewModels
{
    public class MapClientViewModel : BaseViewModel
    {
        public FlyoutPage Page { get;}
        public Command MenuShow { get; }
        public Command DisplaySummaryOrderCommand { get; }
        public Command RequestServiceCommand { get; }
        public Command EnterPromoCodeCommand { get; }
        public string PromotionCode { get; set; }
        public bool IsPromotionCodeAdded { get; set; }
        public List<Model.MenuItem> MenuItems { get; set; }
        public MapClientViewModel(bool getCurrentLocation)
        {
            InitMenuItem();
            MenuShow = new Command(ShowMenu);
            RequestServiceCommand = new Command(RequestService);
            DisplaySummaryOrderCommand = new Command(DisplaySummaryOrder);
            EnterPromoCodeCommand = new Command(()=> ShowDialogEnterPromoCode());
            Page = new Views.MasterDetailView(new Views.MapClientView(getCurrentLocation));
            OpenAsRootPage(Page);
        }

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

        private void ShowMenu() => Page.IsPresented = true; 
        private void DisplaySummaryOrder()
        {
            var PopupView = new Views.PopupViews.SummaryRequestOrder() { BindingContext = this };
            PopupNavigation.Instance.PushAsync(PopupView);
        }
        private void RequestService()
        {
            PopupNavigation.Instance.PopAllAsync();
            new ViewModels.TracingServiceViewModel();
        }
        private async Task ShowDialogEnterPromoCode()
        {
            var input = await MaterialDialog.Instance.InputAsync(
                                                        title: "Promotion code",
                                                        message: "Enter promotion code",
                                                        inputPlaceholder: "Code",
                                                        dismissiveText: "Cancel",
                                                        confirmingText: "Confirme",
                                                        configuration: App.GetMaterialInputDialogConfiguration());
            IsPromotionCodeAdded = !string.IsNullOrEmpty(input) && IsValidPromotionCode(input);
            if (IsPromotionCodeAdded)
            {
                PromotionCode = input;
                OnPropertyChanged(nameof(PromotionCode));
                OnPropertyChanged(nameof(IsPromotionCodeAdded));
            }
        }
        private bool IsValidPromotionCode(string code)
        {
            return true;
        }
    }
}
