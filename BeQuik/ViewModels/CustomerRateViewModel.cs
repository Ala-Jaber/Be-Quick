using System;
using System.Collections.Generic;
using System.Text;

namespace BeQuik.ViewModels
{
    public class CustomerRateViewModel : BaseViewModel
    {
        public CustomerRateViewModel()
        {
            OpenPage(new Views.CustomerRatePage()).ConfigureAwait(false);
        }
    }
}
