﻿using Rg.Plugins.Popup.Pages;
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
    public partial class OrderDetails : PopupPage
    {
        public OrderDetails()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed() => false;
        protected override bool OnBackgroundClicked() => false;
    }
}