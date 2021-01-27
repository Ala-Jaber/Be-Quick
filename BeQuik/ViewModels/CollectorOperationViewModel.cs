using System;
using System.Collections.Generic;
using System.Text;

namespace BeQuik.ViewModels
{
    public class CollectorOperationViewModel:BaseViewModel
    {
        public CollectorOperationViewModel()
        {
            OpenPage(new Views.CollectorOperationPage());
        }
    }
}
