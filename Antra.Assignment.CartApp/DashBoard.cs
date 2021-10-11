using System;
using System.Collections.Generic;
using System.Text;
using Antra.Assignment.CartApp.UI;

namespace Antra.Assignment.CartApp
{
    class DashBoard
    {
        public void ShowDashboard()
        {
            Menu m = new Menu();
            int choice = 0;
            do
            {
                Console.Clear();
                choice = m.PrintMenu(typeof(MainOptions));
                MainScreenFactory factory = new MainScreenFactory();
                MainScreen ms = factory.GetObject(choice);
                if (ms != null)
                {
                    ms.Run();
                }
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();

            } while (choice != (int)MainOptions.Shopping);



        }
    }
}
