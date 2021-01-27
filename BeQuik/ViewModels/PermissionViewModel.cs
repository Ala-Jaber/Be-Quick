using System;
using System.Collections.Generic;
using System.Text;

namespace BeQuik.ViewModels
{
    public class PermissionViewModel : BaseViewModel
    {
        public PermissionViewModel()
        {
            OpenPage(new Views.PermissionPage());
        }
    }
}
