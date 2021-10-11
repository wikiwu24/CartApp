using System;
using System.Collections.Generic;
using System.Text;
using Antra.Assignment.CartApp.Services;
using Antra.Assignment.CartApp.Data.Model;


namespace Antra.Assignment.CartApp.UI
{
    
    class ManageCustomer:MainScreen
    {
        CustomerService customerService;
        public ManageCustomer()
        {
            customerService = new CustomerService();
        }

        public void AddCustomer()
        {
            Customers c = new Customers();
            Console.WriteLine("Enter Your FullName = ");
            c.FullName = Console.ReadLine();
            int CustomerId = customerService.InsertCustmer(c);
            if (CustomerId > 0)
            {
                Console.WriteLine("Customer Added Successfully!");
                Console.WriteLine($"Your CustomerId = {CustomerId}");
            }
            else
            {
                Console.WriteLine("Error! Cannot Add Customer!");
            }
        }
        public override void Run()
        {
            AddCustomer();
        }
    }
}
