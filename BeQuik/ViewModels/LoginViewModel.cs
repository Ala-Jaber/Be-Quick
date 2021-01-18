using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BeQuik.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command SingInCommand { get; }
        public Command SingUpCommand { get; }

        public LoginViewModel()
        {
            SingInCommand = new Command(()=> OnSingInClicked().ConfigureAwait(false));
            SingUpCommand = new Command(OnSingUpClicked);
            OpenAsRootPage(new Views.LoginPage());
        }

        private async Task OnSingInClicked()
        {
            var isMap = await RequestPermissionsLocation();
            new ViewModels.MainViewModel(isMap);
        }
        private void OnSingUpClicked()
        {
            new ViewModels.RegisterViewModel();
        }
        private async Task<bool> RequestPermissionsLocation()
        {
            PermissionStatus status = PermissionStatus.Denied;

            status = await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                return await Permissions.RequestAsync<Permissions.LocationAlways>();
            });

            return (status == PermissionStatus.Granted);
        }
    }
}
