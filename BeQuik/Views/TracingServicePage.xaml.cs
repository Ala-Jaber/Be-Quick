using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeQuik.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TracingServicePage : ContentPage
    {
        public TracingServicePage()
        {
            InitializeComponent();
            App.AddMapStyle(MapForms);
        }
        protected override bool OnBackButtonPressed() => true;
    }
}