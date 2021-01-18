using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BeQuik.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public FlyoutPage Page { get;}
        public Command MenuShow { get; }
        public Command RequestServiceCommand { get; }
        public MainViewModel(bool getCurrentLocation)
        {
            MenuShow = new Command(ShowMenu);
            RequestServiceCommand = new Command(RequestService);
            Page = new Views.MasterDetailView(new Views.MapView(getCurrentLocation));
            OpenAsRootPage(Page);
        }
        private void ShowMenu() => Page.IsPresented = true;
        private void RequestService()
        {
            new ViewModels.TracingServiceViewModel();
        }
    }
}
