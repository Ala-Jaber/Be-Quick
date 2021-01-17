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
        public MainViewModel()
        {
            MenuShow = new Command(ShowMenu);
            RequestServiceCommand = new Command(RequestService);
            var isMap = RequestLocation().GetAwaiter().GetResult();
            Page = new Views.MasterDetailView(new Views.MapView(isMap));
            OpenAsRootPage(Page);
        }
        private void ShowMenu() => Page.IsPresented = true;
        private async Task<bool> RequestLocation()
        {
            PermissionStatus status = PermissionStatus.Denied;

            status = await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                return await Permissions.RequestAsync<Permissions.LocationAlways>();
            });

            return (status == PermissionStatus.Granted);
        }
        private void RequestService()
        {
            new ViewModels.TracingServiceViewModel();
        }
    }
}
