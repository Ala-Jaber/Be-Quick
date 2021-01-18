﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeQuik.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailView : FlyoutPage
    {
        public MasterDetailView(ContentPage page)
        {
            InitializeComponent();
            Detail = new NavigationPage(page);
            IsPresented = false;
        }
    }
}