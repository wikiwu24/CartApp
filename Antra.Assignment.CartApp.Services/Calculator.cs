using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antra.Assignment.CartApp.Data.Repository;

namespace Antra.Assignment.CartApp.Services
{
    class Calculator
    {
        ProductRepository productRepository;
            public Calculator()
        {
            productRepository = new ProductRepository();
        }
        public decimal GetTotal(Dictionary<int, int> productList)
        {
            decimal result = 0;
            if (productList != null && productList.Count() > 0)
            {
                foreach (var item in productList)
                {
                    decimal price = productRepository.GetPriceById(item.Key);
                    result += price * item.Value;
                }
            }
            return result;
        }

        public decimal GetTotalWithDiscount(Dictionary<int, int> productList)
        {
            decimal result = 0;
            if (productList != null && productList.Count() > 0)
            {
                foreach (var item in productList)
                {
                    int id = item.Key;
                    int value = item.Value;
                    decimal price = productRepository.GetPriceById(item.Key);
                    switch (id)
                    {
                        case (int)Products.Apple:

                            if(value % 2 == 0)
                            {
                                result += price * (value / 2);
                            }
                            else
                            {
                                result += price * (value - 1) / 2 + price;
                            }
                            break;

                        case (int)Products.Orange:
                            if(value % 3 ==0)
                            {
                                result += price * 2 * (value / 3) ;
                            }else if (value % 3 == 1)
                            {
                                result += (price * 2 * (value - 1) / 3) + price;
                            }
                            else
                            {
                                result += (price * 2 * (value - 2) / 3) + price * 2;
                            }
                            break;
                    }
                }
            }
            return result;
        }
    }
}
