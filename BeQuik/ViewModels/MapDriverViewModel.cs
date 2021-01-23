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
        public static Action<bool> ShowDriverWalletEmptyError;
        public MapDriverViewModel()
        {
            MenuShow = new Command(ShowMenu);
            Page = new Views.MasterDetailView(new Views.MapDriverView());
            OpenAsRootPage(Page);

            //Optional Code
            Device.StartTimer(TimeSpan.FromSeconds(15), () => { ShowDriverWalletEmptyError.Invoke(true); return false; });
            Device.StartTimer(TimeSpan.FromSeconds(40), () => { ShowDriverWalletEmptyError.Invoke(false); return false; });
        }
        private void ShowMenu() => Page.IsPresented = true;

    }
}
