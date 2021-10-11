using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.Assignment.CartApp.Data.Model
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit  { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStick { get; set; }
    }
}
