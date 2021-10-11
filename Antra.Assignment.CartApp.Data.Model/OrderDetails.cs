using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.Assignment.CartApp.Data.Model
{
    public class OrderDetails
    {
        public Decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public bool? Discount { get; set; }

        public Orders Order { get; set; }
        public Products Product { get; set; }
    }
}
