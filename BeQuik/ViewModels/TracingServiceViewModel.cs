using System;
using System.Collections.Generic;
using System.Text;

namespace BeQuik.ViewModels
{
    public class TracingServiceViewModel : BaseViewModel
    {
        public TracingServiceViewModel()
        {
            OpenPage(new Views.TracingServicePage()).ConfigureAwait(false);
        }
    }
}
