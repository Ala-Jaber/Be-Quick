using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using XF.Material.Forms.UI;

namespace BeQuik.Triggers
{
    public class ShowPasswordTriggerAction : TriggerAction<ImageButton>, INotifyPropertyChanged
    {
        public string ShowIcon { get; set; }
        public string HideIcon { get; set; }

        private MaterialTextFieldInputType _hidePassword = MaterialTextFieldInputType.Password;

        public MaterialTextFieldInputType HidePassword
        {
            set
            {
                if (_hidePassword != value)
                {
                    _hidePassword = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HidePassword)));
                }
            }
            get => _hidePassword;
        }

        protected override void Invoke(ImageButton sender)
        {
            var IsPasswordHiddin = HidePassword == MaterialTextFieldInputType.Password;
            sender.Source = IsPasswordHiddin ? ShowIcon : HideIcon;
            HidePassword = IsPasswordHiddin? MaterialTextFieldInputType.Text : MaterialTextFieldInputType.Password;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
