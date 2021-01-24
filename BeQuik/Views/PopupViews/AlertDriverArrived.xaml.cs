using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeQuik.Views.PopupViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlertDriverArrived : Rg.Plugins.Popup.Pages.PopupPage
    {
        public AlertDriverArrived()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed() => true;
        protected override bool OnBackgroundClicked() => true;
    }
}