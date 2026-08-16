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
            Exit

        }
        static void Main(string[] args)
        {   // instanciate menu classes
            VehicleRepository v = new VehicleRepository();

            // running loop
            while (true)
            {
                Console.WriteLine("====Courier Star MENU====\n" +
                    "1. Manage Staff\n" +
                    "2. Manage Vehicles\n" +
                    "3. Manage Orders\n" +
                    "4. Manage Customers\n" +
                    "5. Exit\n" +
                    "Enter (1-5): ");
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
                    case MainMenu.MangeCustomers:
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
