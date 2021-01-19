using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

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
            await MaterialDialog.Instance.AlertAsync(
                                title: "Alert Dialog",
                                message: "This is an alert dialog",
                                acknowledgementText: "Got It",
                                configuration: App.GetMaterialAlertDialogConfiguration());

            using (await MaterialDialog.Instance.LoadingDialogAsync(message: ""))
            {
                await Task.Delay(5000); // Represents a task that is running.
                var isMap = await RequestPermissionsLocation();
                new ViewModels.MainViewModel(isMap);
            }
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
