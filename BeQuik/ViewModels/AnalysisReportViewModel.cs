using System;
using System.Collections.Generic;
using System.Text;

namespace BeQuik.ViewModels
{
    public class AnalysisReportViewModel:BaseViewModel
    {
        public AnalysisReportViewModel()
        {
            OpenPage(new Views.AnalysisReportPage());
        }
    }
}
