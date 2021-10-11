using Antra.Assignment.CartApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;

namespace Antra.Assignment.CartApp.Data.Repository
{
    public class OrderDetailRepository : IRepository<OrderDetails>
    {
        CartDbContext db;
        public OrderDetailRepository()
        {
            db = new CartDbContext();
        }
        public IEnumerable<OrderDetails> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(OrderDetails item)
        {
           
            using (IDbConnection conn = db.GetDataConnection())
            {
                try
                {

                    //return the number of rows affected
                    return conn.Execute("Insert Into OrderDetails Values(@OrderId,@ProductId,@UnitPrice,@Quantity,@Discount)",
                        new
                        {
                            @OrderId = item.Order.OrderId,
                            @ProductId = item.Product.ProductId,
                            @UnitPrice = item.Product.UnitPrice,
                            @Quantity = item.Quantity,
                            @Discount = item.Discount
                        });

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return 0;
        }
    }
}
