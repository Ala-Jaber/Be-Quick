using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BeQuik.ViewModels
{
    public interface IMasterCommonViewModel
    {
        public Command OpenProfileCommand { get;}
        public Command LogoutCommand { get;}
    }
}
