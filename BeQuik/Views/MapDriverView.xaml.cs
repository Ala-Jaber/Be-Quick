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
    public partial class MapDriverView : ContentPage
    {
        public MapDriverView()
        {
            InitializeComponent();
            App.AddMapStyle(MapForms);
            ViewModels.MapDriverViewModel.ShowDriverWalletEmptyError = this.ShowDriverWalletEmptyError;
        }
        public async void ShowDriverWalletEmptyError(bool show)
        {
            if(show) ErrorCard.IsVisible = show;
            ErrorCard.FadeTo(opacity: show ? 100 : 0, 950).ConfigureAwait(false);
            await ErrorCard.TranslateTo(0, show ? 0 : -50, 1000);
            if(!show) ErrorCard.IsVisible = show;
        }
    }
}