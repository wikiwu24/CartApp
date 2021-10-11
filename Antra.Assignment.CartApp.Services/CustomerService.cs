using System;
using System.Collections.Generic;
using System.Text;
using Antra.Assignment.CartApp.Data.Model;
using Antra.Assignment.CartApp.Data.Repository;

namespace Antra.Assignment.CartApp.Services
{
    public class CustomerService
    {
        IRepository<Customers> customerRepository;
        public CustomerService()
        {
            customerRepository = new CustomerRepository();
        }

        public IEnumerable<Customers> GetAll()
        {
            return customerRepository.GetAll();
        }

        public int InsertCustmer(Customers c)
        {
            return customerRepository.Insert(c);
        }
    }
}
