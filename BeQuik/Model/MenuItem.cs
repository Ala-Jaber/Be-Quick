using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BeQuik.Model
{
    public class MenuItem
    {
        public string Text { get; set; }
        public string ImageSource { get; set; }
        public Command Command { get; set; }
    }
}
