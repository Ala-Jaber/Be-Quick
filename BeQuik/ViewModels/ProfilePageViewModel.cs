using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BeQuik.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        public IList ListAreaCode { get; }

        public ProfilePageViewModel()
        {
            ListAreaCode = new List<string> { "JO\t+962", "JO\t+962", "JO\t+962", "JO\t+962", "JO\t+962", };
            OpenPage(new Views.ProfilePage());
        }

    }
}
