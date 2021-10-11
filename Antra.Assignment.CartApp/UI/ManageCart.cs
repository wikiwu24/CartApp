using System;
using System.Collections.Generic;
using System.Text;
using Antra.Assignment.CartApp.Services;
namespace Antra.Assignment.CartApp.UI
{
    public class ManageCart : MainScreen
    {
        CartService cartService;
        Dictionary<int, int> products;
        bool coupon;
        public ManageCart()
        {
            cartService = new CartService();
            products = new Dictionary<int, int>();
        }

        void AddProductsInCart()
        {
            Menu m = new Menu();
            int key = m.PrintMenu(typeof(ProductList));
            Console.WriteLine("Enter the Quantity = ");
            int value = Convert.ToInt32(Console.ReadLine());
            if (!products.ContainsKey(key))
            {
                products.Add(key, value);
            }
            else
            {
                int oldValue = products[key];
                products[key] = oldValue + value;
            }
            
        
        }

        decimal GetTotal(Dictionary<int, int> products)
        {
            Console.WriteLine("Enter true if you have coupon; ");
            Console.WriteLine("Enter false if you don't;");
            coupon = Convert.ToBoolean(Console.ReadLine());
            return cartService.GetTotal(products, coupon);
        }

        public override void Run()
        {
            Menu m = new Menu();
            int choice = 0;
            do
            {
                Console.Clear();
                choice = m.PrintMenu(typeof(Operations));
                switch (choice)
                {
                    case (int)Operations.Add:
                        AddProductsInCart();
                        break;
                    case (int)Operations.CheckOut:
                        decimal total = GetTotal(products);
                        if(total != 0)
                        {
                            Console.WriteLine($"Your Total is {total}");
                            Console.WriteLine("Enter 1 for Pay, Press 2 to previous menu");
                            int c = Convert.ToInt32(Console.ReadLine());
                            if(c == 1)
                            {
                                Console.WriteLine("Enter your Customer Id if you have = ");
                                int CustomerId = 0;
                                string input = Console.ReadLine();
                                if (!String.IsNullOrEmpty(input))
                                {
                                    CustomerId = Convert.ToInt32(input);
                                }
                                cartService.SaveOrder(CustomerId, products, coupon);
                                Console.WriteLine("Thanks For Shopping With Us!");

                            }
                        }
                        else
                        {
                            Console.WriteLine("Opps! No Products in the cart.Please add products!");
                        }
                        
                        break;
                    case (int)Operations.Exist:
                        Console.WriteLine("Thanks!");
                        break;
                }
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();



            } while (choice != (int)Operations.Exist);
        }
    }
}
