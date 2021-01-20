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
    public class MainViewModel : BaseViewModel
    {
        public FlyoutPage Page { get;}
        public Command MenuShow { get; }
        public Command DisplaySummaryOrderCommand { get; }
        public Command RequestServiceCommand { get; }
        public Command EnterPromoCodeCommand { get; }
        public string PromotionCode { get; set; }
        public bool IsPromotionCodeAdded { get; set; }
        public MainViewModel(bool getCurrentLocation)
        {
            MenuShow = new Command(ShowMenu);
            RequestServiceCommand = new Command(RequestService);
            DisplaySummaryOrderCommand = new Command(DisplaySummaryOrder);
            EnterPromoCodeCommand = new Command(()=> ShowDialogEnterPromoCode());
            Page = new Views.MasterDetailView(new Views.MapView(getCurrentLocation));
            OpenAsRootPage(Page);
        }
        private void ShowMenu() => Page.IsPresented = true; 
        private void DisplaySummaryOrder()
        {
            var PopupView = new Views.PopupViews.SummaryRequestOrder();
            PopupView.BindingContext = this;
            PopupNavigation.Instance.PushAsync(PopupView);
        }
        private void RequestService()
        {
            new ViewModels.TracingServiceViewModel();
        }
        private async Task ShowDialogEnterPromoCode()
        {
            var input = await MaterialDialog.Instance.InputAsync(
                                                        title: "Promotion code",
                                                        message: "Enter promotion code",
                                                        inputPlaceholder: "Code",
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
