using System;
using System.Collections.Generic;
using System.Text;

namespace BeQuik.Model
{
    public class Order
    {
        public string ImageSource { get; set; }
        public DateTime Date { get; set; }
        public int OrderID { get; set; }
        public Enums.ServiceType Type { get; set; }
        public double Price { get; set; }
    }
}
