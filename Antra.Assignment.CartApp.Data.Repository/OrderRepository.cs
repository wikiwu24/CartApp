using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
using Antra.Assignment.CartApp.Data.Model;

namespace Antra.Assignment.CartApp.Data.Repository
{
    public class OrderRepository : IRepository<Orders>
    {
        CartDbContext db;
        public OrderRepository()
        {
            db = new CartDbContext();
        }
        public IEnumerable<Orders> GetAll()
        {
            string query = @"Select o.OrderId, o.OrderDate, c.CustomerId, c.FullName from Orders o 
                                join Customers c on c.CustomerId = o.OrderIda";
            using (IDbConnection conn = db.GetDataConnection())
            {
                
                try
                {

                    return conn.Query<Orders, Customers, Orders>(query, (o,c) => { o.Customer = c; return o; });

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

            }

            return null;
        
        }

        public int Insert(Orders item)
        {
            string insertQuery = @"INSERT INTO Orders
                        OUTPUT INSERTED.[OrderId]
                        VALUES(@CustomerId,@OrderDate);";
            using (IDbConnection conn = db.GetDataConnection())
            {
                try
                {
                    // return the OrderId
                    return conn.QuerySingle<int>(insertQuery,
                                new
                                {
                                    @CustomerId = item.CustomerId,
                                    @OrderDate = item.OrderDate
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
