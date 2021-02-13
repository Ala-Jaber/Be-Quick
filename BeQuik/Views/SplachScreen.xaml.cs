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
    public partial class SplachScreen : ContentPage
    {
        public SplachScreen()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            PlayAnimation();
        }
        public async Task PlayAnimation()
        {
            await Task.WhenAll(new Task[]
            {
                your_life.ScaleTo(2/3.0,3*1000),
                logo_app.ScaleTo(5.5/7.0,3*1000),
                logoStackLayout.TranslateTo(-30,0,3*1000),
                ImageCars.FadeTo(1,7*1000),

                taxi.ScaleTo(1.2,2*1000),
                truck.ScaleTo(1.2,2*1000),
                gas.ScaleTo(1.2,2*1000),
                delivery.ScaleTo(1.2,2*1000),
            });
            await Task.Delay(3 * 1000);
            await Task.WhenAll(new Task[] {

                ImageCars.FadeTo(0,3*1000),
                logoStackLayout.TranslateTo(0,0,3*1000),
                });
            new ViewModels.LoginViewModel();
        }
    }
}