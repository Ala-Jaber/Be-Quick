using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BeQuik.ViewModels
{
    public class BalanceCodeOperationViewModel : BaseViewModel
    {
        private bool _IsCodeGenerated;
        public bool IsCodeGenerated
        {
            get { return _IsCodeGenerated; }
            set { _IsCodeGenerated = value; OnPropertyChanged(); }
        }
        public Command GenerateCodeCommand { get; set; }
        public BalanceCodeOperationViewModel()
        {
            GenerateCodeCommand = new Command(CodeGenerator);
            OpenPage(new Views.BalanceCodeOperationPage());
        }
        private void CodeGenerator()
        {
            IsCodeGenerated = true;
        }

    }
}
