using System;
using System.Collections.Generic;
using System.Text;
using Antra.Assignment.CartApp.Data.Repository;
using Antra.Assignment.CartApp.Data.Model;
using System.Linq;


namespace Antra.Assignment.CartApp.Services
{
    public class CartService
    {
        ProductRepository productRepository;
        OrderRepository orderRepository;
        OrderDetailRepository orderDetailRepository;
        CustomerRepository customerRepository;
        Calculator ca;
        public CartService()
        {
            
            ca = new Calculator();
        }

       
        public decimal GetTotal(Dictionary<int, int> productList, bool Coupon)
        {

            if (Coupon)
            {
                return ca.GetTotalWithDiscount(productList);
            }
            else
            {
                return ca.GetTotal(productList);
            }
        }

        public void SaveOrder(int CustomerId, Dictionary<int, int> productList, bool coupon)
        {
            productRepository = new ProductRepository();
            orderRepository = new OrderRepository();
            orderDetailRepository = new OrderDetailRepository();
            customerRepository = new CustomerRepository();
            Orders o = new Orders();
            if(CustomerId != 0){
                o.Customer = customerRepository.GetCustomerById(CustomerId);
                o.CustomerId = CustomerId;
            }
            o.OrderDate = DateTime.Now;
            int orderId = orderRepository.Insert(o);
 

            List<OrderDetails> odList = new List<OrderDetails>();
            foreach (var item in productList)
            {
                OrderDetails od = new OrderDetails();
                od.Order = o;
                od.Order.OrderId = orderId;
                od.Product = productRepository.GetProductById(item.Key);
                od.Quantity = item.Value;
                od.Discount = coupon;
                odList.Add(od);
                Console.WriteLine(od.Order.OrderId);
                
            }
            
            try
            {
                foreach (var item in odList)
                {
                    int orderdetail = orderDetailRepository.Insert(item);
                    if (orderId <= 0 || orderdetail <= 0)
                    {
                        Console.WriteLine("Oops! There is something wrong!");

                    }
                }                
                
                    Console.WriteLine("Your order has Completed!");
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops! There is something wrong!");
                Console.WriteLine(e.Message);
            }

        }


    }
}
