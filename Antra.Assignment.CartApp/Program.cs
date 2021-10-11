using Antra.Assignment.CartApp.UI;
using System;
using Antra.Assignment.CartApp.Services;
using System.Collections.Generic;
using Antra.Assignment.CartApp.Data.Repository;
using Antra.Assignment.CartApp.Data.Model;

namespace Antra.Assignment.CartApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DashBoard db = new DashBoard();
            db.ShowDashboard();
            //Console.WriteLine( "Hi");
            /*CartService c = new CartService();
            Dictionary<int, int> p = new Dictionary<int, int>();
            p.Add(100, 10);
            p.Add(101, 10);
            c.SaveOrder(1, p);*/
            /*ProductRepository c = new ProductRepository();
            //decimal c2 = c.GetPriceById(101);
            Products c2 = c.GetProductById(101);
            //Console.WriteLine(c2);
            Console.WriteLine(c2.ProductId+ "\t" + c2.ProductName);*/

            /*Console.WriteLine("a = ");
            string input = Console.ReadLine();
            Console.WriteLine(input);
            Console.WriteLine(String.IsNullOrEmpty(input));*/
        }
    }
}
