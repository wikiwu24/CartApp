using System;
using System.Collections.Generic;
using System.Text;
using Antra.Assignment.CartApp.Data.Repository;
using Antra.Assignment.CartApp.Data.Model;
namespace Antra.Assignment.CartApp
{
   

    public enum ProductList
    {
        Apple = 100,
        Orange
    }

    enum Operations
    {
        Add = 1,
        CheckOut,
        Exist
    }

    enum MainOptions
    {
        Register = 1,
        Shopping
    }
}
