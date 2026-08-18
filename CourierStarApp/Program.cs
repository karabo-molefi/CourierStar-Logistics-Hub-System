using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{
    internal class Program
    {
        enum MainMenu
        {
            ManageStaff=1,
            ManageVehicles,
            ManageOrders,
            MangeCustomers,
            ManageSystem,
            Exit

        }
        static void Main(string[] args)
        {   // instanciate menu classes
            VehicleRepository v = new VehicleRepository();
            OrderManagement o = new OrderManagement();
            ManageCustomer c = new ManageCustomer();

            // running loop
            while (true)
            {
                Console.WriteLine("====Courier Star MENU====\n" +
                    "1. Manage Staff\n" +
                    "2. Manage Vehicles\n" +
                    "3. Manage Orders\n" +
                    "4. Manage Customers\n" +
                    "5. Manage System\n" +
                    "6. Exit\n" +
                    "Enter (1-6): ");
                int choice = int.Parse(Console.ReadLine());

                MainMenu menu = (MainMenu)choice;

                switch (menu)
                {
                    case MainMenu.ManageStaff:
                        // 
                        break;
                    case MainMenu.ManageVehicles:
                        v.ManageVehicles();
                        break;
                    case MainMenu.ManageOrders:
                        o.ManageOrders();
                        break;
                    case MainMenu.MangeCustomers:
                        c.ManageCustomers();
                        break;
                    case MainMenu.ManageSystem:
                        //
                        break;
                    case MainMenu.Exit:
                        Console.WriteLine("Exiting program...");
                        Environment.Exit(0);
                        break;
                }
            }





        }
    }
}
