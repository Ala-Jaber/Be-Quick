using System;
using System.Collections.Generic;
using System.Text;

namespace BeQuik.ViewModels
{
    public class PricingViewModel:BaseViewModel
    {
        public PricingViewModel()
        {
            OpenPage(new Views.PricingPage());
        }
    }
}
