using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.GoogleMaps;

namespace BeQuik.Model
{
    public class Order
    {
        public string ImageUser { get; set; } = "img_profile.png";
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Position Position { get; set; }
        public bool IsServiced { get; set; }
    }
}
