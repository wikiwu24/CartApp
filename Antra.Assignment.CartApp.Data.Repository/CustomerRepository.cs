using System;
using System.Collections.Generic;
using System.Text;
using Antra.Assignment.CartApp.Data.Model;
using System.Data;
using Dapper;

namespace Antra.Assignment.CartApp.Data.Repository
{
    public class CustomerRepository : IRepository<Customers>
    {
        CartDbContext db;
        public CustomerRepository()
        {
            db = new CartDbContext();
        }
        /*public int Delete(int id)
        {
            throw new NotImplementedException();
        }
*/
        public IEnumerable<Customers> GetAll()
        {
            using (IDbConnection conn = db.GetDataConnection())
            {
                try
                {

                    return conn.Query<Customers>("Select CustomerId, FullName From Customers");

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

        public int Insert(Customers item)
        {
            string insertQuery = @"INSERT INTO Customers
                        OUTPUT INSERTED.[CustomerId]
                        VALUES(@FullName);";
            using (IDbConnection conn = db.GetDataConnection())
            {
                try
                {
                    // return the OrderId
                    return conn.QuerySingle<int>(insertQuery,
                                new
                                {
                                    @FullName = item.FullName
                                });

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return 0;

        }

        /*public int Update(Customers item)
        {
            throw new NotImplementedException();
        }*/
        public Customers GetCustomerById(int id)
        {
            using (IDbConnection conn = db.GetDataConnection())
            {
                try
                {
                    IEnumerable<Customers> cList = conn.Query<Customers>("Select CustomerId, FullName From Customers Where CustomerId = @Id", new { @Id = id });
                    Customers c = null;
                    foreach (var item in cList)
                    {
                        c = item;
                    }
                    return c;
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
    }
}
