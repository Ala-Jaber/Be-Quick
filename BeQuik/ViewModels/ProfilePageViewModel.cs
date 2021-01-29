using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BeQuik.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        public IList ListAreaCode { get; }
        public Command LogoutCommand { get; set; }
        public ProfilePageViewModel()
        {
            ListAreaCode = new List<string> { "JO\t+962", "JO\t+962", "JO\t+962", "JO\t+962", "JO\t+962", };
            LogoutCommand = new Command(Logout);
            OpenPage(new Views.ProfilePage());
        }
        private void Logout()
        {
            new ViewModels.LoginViewModel();
        }
    }
}
