using System;
using System.Collections.Generic;
using System.Text;

namespace BeQuik.ViewModels
{
    public class BalanceOperationViewModel:BaseViewModel
    {
        public BalanceOperationViewModel()
        {
            OpenPage(new Views.BalanceOperationPage());
        }
    }
}
