using System;
using System.Collections.Generic;
using System.Text;

namespace BeQuik.ViewModels
{
    public class AdministrationViewModel:BaseViewModel
    {
        private string _SelectedRegisterAs;
        public string RegisterAs
        {
            get { return _SelectedRegisterAs; }
            set { _SelectedRegisterAs = value; OnPropertyChanged(); }
        }
        private string _SelectedServiceType;
        public string ServiceType
        {
            get { return _SelectedServiceType; }
            set { _SelectedServiceType = value; OnPropertyChanged(); }
        }
        private string _SelectedWorkType;
        public string WorkType
        {
            get { return _SelectedWorkType; }
            set { _SelectedWorkType = value; OnPropertyChanged(); }
        }

        public AdministrationViewModel()
        {
            OpenPage(new Views.AdministrationPage());
        }
    }
}
