using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.Assignment.CartApp.Data.Model
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime OrderDate { get; set; }

        public Customers Customer { get; set; }
    }
}
