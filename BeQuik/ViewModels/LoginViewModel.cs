﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BeQuik.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command SingInCommand { get; }
        public Command SingUpCommand { get; }

        public LoginViewModel()
        {
            SingInCommand = new Command(OnSingInClicked);
            SingUpCommand = new Command(OnSingUpClicked);
            OpenAsRootPage(new Views.LoginPage());
        }

        private void OnSingInClicked(object obj)
        {
            new ViewModels.MainViewModel();
        }
        private void OnSingUpClicked(object obj)
        {
            new ViewModels.RegisterViewModel();
        }
    }
}
