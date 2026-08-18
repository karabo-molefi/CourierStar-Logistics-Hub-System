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
            StaffManager s = new StaffManager();
            VehicleRepository v = new VehicleRepository();

            // running loop
            while (true)
            {
                Console.WriteLine($"====Courier Star MENU====\n" +
                    $"\n" +
                    "1. Manage Staff\n" +
                    "2. Manage Vehicles\n" +
                    "3. Manage Orders\n" +
                    "4. Manage Customers\n" +
                    "5. Manage System\n" +
                    "6. Exit\n" +
                    "Enter (1-6): ");

                // error handling for incorrect choice 
                int choice = 0;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input. Please enter a number (1-6) only.\n");
                }

                MainMenu menu = (MainMenu)choice;

                switch (menu)
                {
                    case MainMenu.ManageStaff:
                        s.ManageStaff();
                        break;
                    case MainMenu.ManageVehicles:
                        v.ManageVehicles();
                        break;
                    case MainMenu.ManageOrders:
                        break;
                    case MainMenu.MangeCustomers:
                        //
                        break;
                    case MainMenu.ManageSystem:
                        //
                        break;
                    case MainMenu.Exit:
                        Console.WriteLine("Exiting program...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Input. Please enter a number (1-6) only.\n");
                        break;

                }
            }





        }
    }
}
