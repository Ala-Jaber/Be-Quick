using BeQuik.Services;
using BeQuik.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeQuik
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            XF.Material.Forms.Material.Init(this);
            new ViewModels.LoginViewModel();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
