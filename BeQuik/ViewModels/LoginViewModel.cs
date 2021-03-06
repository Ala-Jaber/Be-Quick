﻿using System;
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
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; OnPropertyChanged(); }
        }
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; OnPropertyChanged(); }
        }

        public Command SingInCommand { get; }
        public Command SingUpCommand { get; }

        public LoginViewModel()
        {
            SingInCommand = new Command(() => OnSingInClicked().ConfigureAwait(false));
            SingUpCommand = new Command(OnSingUpClicked);

            OpenAsRootPage(new Views.LoginPage());
        }

        private async Task OnSingInClicked()
        {
            switch (UserName.Trim().ToLower())
            {
                case "alert":
                    await ShowAlert().ConfigureAwait(false);
                    break;
                case "loading":
                    await ShowLoading().ConfigureAwait(false);
                    break;
                case "client":
                    new ViewModels.MapClientViewModel();
                    break;
                case "driver":
                    new ViewModels.MapDriverViewModel();
                    break;
                case "admin":
                    new ViewModels.MapAdminViewModel();
                    break;
            }
        }
        private async Task ShowAlert()
        {
            await MaterialDialog.Instance.AlertAsync(
                                title: "Alert Dialog",
                                message: "This is an alert dialog",
                                acknowledgementText: "Got It",
                                configuration: App.GetMaterialAlertDialogConfiguration());
        }
        private async Task ShowLoading() 
        {
            using (await MaterialDialog.Instance.LoadingDialogAsync(message: "Wait Sing in...", configuration: App.GetMaterialLoadingDialogConfiguration()))
            {
                await Task.Delay(5000);
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
