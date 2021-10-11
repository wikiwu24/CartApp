using System;
using System.Collections.Generic;
using System.Text;
using Antra.Assignment.CartApp.Data.Model;
using Dapper;
using System.Data;


namespace Antra.Assignment.CartApp.Data.Repository
{
    public class ProductRepository : IRepository<Products>
    {
        CartDbContext db;
        public ProductRepository()
        {
            db = new CartDbContext();
        }
        public IEnumerable<Products> GetAll()
        {
            using (IDbConnection conn = db.GetDataConnection())
            {
                try
                {
                    return conn.Query<Products>("Select ProductId, ProductName, QuantityPerUnit, UnitPrice, UnitsInStock From Products");
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

        public int Insert(Products item)
        {
            throw new NotImplementedException();
        }

        

        public Products GetProductById(int id)
        {
            using (IDbConnection conn = db.GetDataConnection())
            {
                try
                {
                    return conn.QueryFirstOrDefault<Products>("Select ProductId, ProductName, QuantityPerUnit, UnitPrice, UnitsInStock From Products Where ProductId = @Id", new { @Id = id });
                    
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
        public decimal GetPriceById(int id)
        {
            using (IDbConnection conn = db.GetDataConnection())
            {
                try
                {
                    Products p = GetProductById(id);
                    return p.UnitPrice;
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
            return 0;
        }



    }
}
