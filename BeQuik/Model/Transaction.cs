using System;
using System.Collections.Generic;
using System.Text;

namespace BeQuik.Model
{
    public class Transaction
    {
        public string Name { get; set; }
        public double Credit { get; set; }
        public double Depth { get; set; }
        public DateTime Date { get; set; }
    }
}
