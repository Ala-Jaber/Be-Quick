using System;
using System.Collections.Generic;
using System.Text;

namespace BeQuik.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        public ProfilePageViewModel()
        {
            OpenPage(new Views.ProfilePage());
        }
    }
}
