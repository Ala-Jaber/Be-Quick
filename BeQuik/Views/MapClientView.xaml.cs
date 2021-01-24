using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace BeQuik.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapClientView : ContentPage
    {
        public MapClientView()
        {
            InitializeComponent();
            App.AddMapStyle(MapForms);
            ViewModels.MapClientViewModel.GetPositionSelected = ()=> GetPostionSelected();
            ViewModels.MapClientViewModel.ShowMessageAlert = this.ShowMessageAlert;
        }
        public Position GetPostionSelected() => MapForms.VisibleRegion.Center;
        public async void ShowMessageAlert(string Message,bool isSuccessed,bool show)
        {
            MessageText.Text = Message;
            MessageCard.BackgroundColor = Color.FromHex(isSuccessed ? "#43B372" : "#E93832");
            if (show) MessageCard.IsVisible = show;
            MessageCard.FadeTo(opacity: show ? 100 : 0, 950).ConfigureAwait(false);
            await MessageCard.TranslateTo(0, show ? 0 : -50, 1000);
            if (!show) MessageCard.IsVisible = show;
        }

    }
}