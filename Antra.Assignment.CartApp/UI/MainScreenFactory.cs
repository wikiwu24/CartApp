using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.Assignment.CartApp.UI
{
    class MainScreenFactory
    {
        public MainScreen GetObject(int choice)
        {
            switch (choice)
            {
                case (int)MainOptions.Register:
                    return new ManageCustomer();

                case (int)MainOptions.Shopping:
                    return new ManageCart();
               
            }
            return null;
        }

    }
}
