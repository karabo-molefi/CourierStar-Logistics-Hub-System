using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{
    enum VehicleMenu
    {
        AddVehicle = 1,
        PrintVehicleSummary,
        PrintVehicleDetails,
        Search,
        ReturnToMainMenu,
        Exit
    }

    enum VehicleDetailsMenu
    {
        Motorcyles =1,
        Vans,
        Trucks,
        AllVehicles,
        ReturnToVehiclesMenu

    }

    enum AddVehicleMenu
    {
        Motorcyles = 1,
        Vans,
        Trucks,
        ReturnToVehiclesMenu
    }

    internal class VehicleRepository : IPrintable, ISearch
    {        // menu for managing vehicles

        public void ManageVehicles()
        {
            Console.Clear();

            while (true)
            {
                Console.WriteLine("====Vehicle Manager====\n");

                Console.WriteLine($"1. Add a New vehicle\n" +
                    $"2. Get Summary of vehicles\n" +
                    $"3. Get Vehicle Details\n" +
                    $"4. Search For Vehicle\n" +
                    $"5. Return to Main Menu\n" +
                    $"6. Exit\n" +
                    $"Enter (1-6):");

                // erorr handling
                int option = 0;
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input. Please enter a number (1-6) only.\n");
                }


                VehicleMenu menu = (VehicleMenu)option;

                switch (menu)
                {
                    case VehicleMenu.AddVehicle:
                        Console.Clear();
                        AddVehicle();
                        break;
                    case VehicleMenu.PrintVehicleSummary:
                        Console.Clear();
                        PrintVehicleSummary();
                        break;
                    case VehicleMenu.PrintVehicleDetails:
                        Console.Clear();
                        PrintDetails();
                        break;
                    case VehicleMenu.Search:
                        Console.Clear();
                        Search();
                        break;
                    case VehicleMenu.ReturnToMainMenu:
                        Console.Clear();
                        return;
                    case VehicleMenu.Exit:
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

        // Collections for vehicle types
        List<Motorcyle> Motorcyles = new List<Motorcyle>();
        List<Van> Vans = new List<Van>();   
        List<Truck> Trucks = new List<Truck>();

        // Starter data
        private void InitializeStarterVehicleData()
        {
            // Motorcycles
            Motorcyles.Add(new Motorcyle(1000, 0, 0, 10, 0.04, "Motorcycle"));
            Motorcyles.Add(new Motorcyle(1001, 0, 0, 10, 0.04, "Motorcycle"));
            Motorcyles.Add(new Motorcyle(1002, 0, 0, 10, 0.04, "Motorcycle"));

            // Vans
            Vans.Add(new Van(2000, 0, 0, 1000, 4.935, "Van"));
            Vans.Add(new Van(2001, 0, 0, 1000, 4.935, "Van"));
            Vans.Add(new Van(2002, 0, 0, 1000, 4.935, "Van"));

            // Trucks
            Trucks.Add(new Truck(3000, 0, 0, 4500, 30, "Truck"));
            Trucks.Add(new Truck(3001, 0, 0, 4500, 30, "Truck"));
            Trucks.Add(new Truck(3002, 0, 0, 4500, 30, "Truck"));
        }

        // Add a vehicle

        private int CountMotorcycles;
        private int CountVans;
        private int CountTrucks;

        public VehicleRepository()
        {
            InitializeStarterVehicleData();
            CountMotorcycles = Motorcyles.Count;
            CountVans = Vans.Count;
            CountTrucks = Trucks.Count;

        }

        void AddVehicle()
        {
            // get vehichle id
            int GetVehicleID()
            {
                int vehicleId = 0;
                bool valid = false;
                while (!valid)
                {
                    Console.WriteLine("Enter Vehicle ID: ");
                    try
                    {
                        vehicleId = int.Parse(Console.ReadLine());
                        valid = true;
                    }
                    catch (FormatException)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input. Vehicle ID should be a number.\n");
                        continue;
                    }
                }
                return vehicleId;
               
            }

            while (true)
            {
                Console.WriteLine("====Add New Vehicle====\n");
                Console.WriteLine($"Select Vehicle Type:" +
                $"\n1. Motorcycle\n" +
                $"2. Van\n" +
                $"3. Truck\n" +
                $"4. Return To Vehicles Menu\n" +
                $"Enter (1-4):");

                int VehicleTypeSelection =0;
                try
                {
                    VehicleTypeSelection = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a number (1-4).\n");
                    continue;
                }

                //get vehicle id

                // logic to add to different vehicle collections
                AddVehicleMenu menu = (AddVehicleMenu)VehicleTypeSelection;

                switch (menu)
                {
                    case AddVehicleMenu.Motorcyles:
                        int mVID = GetVehicleID();

                        Motorcyle motorcyle = new Motorcyle(mVID, 0, 10, 10, 0.04, "Motorcycle");
                        Motorcyles.Add(motorcyle);
                        motorcyle.PrintDetails();
                        Console.WriteLine("Added Succefully!");
                        break;
                    case AddVehicleMenu.Vans:
                        int vVID = GetVehicleID();

                        Van van = new Van(vVID, 0, 1000, 1000, 4.935, "Van");
                        Vans.Add(van);
                        van.PrintDetails();
                        Console.WriteLine("Added Succefully!");
                        break;
                    case AddVehicleMenu.Trucks:
                        int tVID = GetVehicleID();

                        Truck truck = new Truck(tVID, 0, 4500, 4500, 50, "Truck");
                        Trucks.Add(truck);
                        truck.PrintDetails();
                        Console.WriteLine("Added Succefully!");
                        break;
                    case AddVehicleMenu.ReturnToVehiclesMenu:
                        Console.Clear();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input. Please enter a number (1-4).\n");
                        continue;
                }

                // ask if they want to enter a new vehicle
                Console.WriteLine("\nWould you like to add another vehicle? (y/n)");
                string continueChoice = Console.ReadLine();

                switch (continueChoice)
                {
                    case "y":
                        Console.Clear();
                        continue;
                    case "yes":
                        Console.Clear();
                        continue;
                    case "no":
                        Console.Clear();
                        return;
                    case "n":
                        Console.Clear();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Input. Please Try Again.\n");
                        break;
                }

            }
           

            
        }

        // Print summary of all vehiicles

        public void PrintVehicleSummary()
        {
            // total no of each vehicle
            Console.WriteLine("====Vehicle Fleet Summary====\n");
            Console.WriteLine($"Motorcyles: {CountMotorcycles}");
            Console.WriteLine($"Vans: {CountVans}");
            Console.WriteLine($"Trucks: {CountTrucks}");
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Total: {CountMotorcycles + CountTrucks + CountVans}");// total no of vehicles
            // total no at bay
            // total no of vehicles at hub
            // no of each vehicle at hub
            // no of each vehicle making deliveries
        }


        // Print vehichle data

        public void PrintAllVehicles()
        {
            Console.WriteLine("====Motorcyles====");
            foreach (var item in Motorcyles)
            {
                item.PrintDetails();
            }
            Console.WriteLine("\n====Vans====");
            foreach (var item in Vans)
            {
                item.PrintDetails();
            }
            Console.WriteLine("\n====Trucks====");
            foreach (var item in Trucks)
            {
                item.PrintDetails();
            }
        }

        // search 

        public void Search()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("====Search For Vehicle====\n");
                Console.WriteLine("Enter Vehicle ID: ");
                int searchId = int.Parse(Console.ReadLine());
                Vehicle foundVehicle = (Motorcyles.FirstOrDefault(fm => fm.VehicleIdProperty == searchId) as Vehicle)
                    ?? (Vans.FirstOrDefault(fv => fv.VehicleIdProperty == searchId) as Vehicle)
                    ?? (Trucks.FirstOrDefault(ft => ft.VehicleIdProperty == searchId) as Vehicle);

                if (foundVehicle != null)
                {
                    Console.WriteLine("\nVehicle found:\n");

                    foundVehicle.PrintDetails();

                    Console.WriteLine("Would you like to search again? (y/n)");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "y":
                            Console.Clear();
                            continue;
                        case "yes":
                            Console.Clear();
                            continue;
                        case "no":
                            Console.Clear();
                            return;
                        case "n":
                            Console.Clear();
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid Input. Please Try Again.\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"\nError, vehicle not found. Invalid Vehicle ID ({searchId}).\n");
                    Console.WriteLine("Would you like to try again? (y/n)");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "y":
                            Console.Clear();
                            continue;
                        case "yes":
                            Console.Clear();
                            continue; 
                        case "no":
                            Console.Clear();
                            return;
                        case "n":
                            Console.Clear();
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid Input. Please Try Again.\n");
                            break;
                    }
                }
                
            
            }
        }


        // print vehicle details
        public void PrintDetails()

        {
            while (true)
            {
                Console.WriteLine("====Get Vehicle Details====\n");
                Console.WriteLine($"Select Vehicle Type (or enter 4 for  All Vehicles):\n" +
                $"1. Motorcycle\n" +
                $"2. Van\n" +
                $"3. Truck\n" +
                $"4. All Vehicles\n" +
                $"5. Return To Manage Vehicles\n" +
                $"Enter (1-5):");

                int VehicleTypeSelection = 0;

                try
                {
                    VehicleTypeSelection = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input. Please enter a number (1-5) only.\n");
                }

                VehicleDetailsMenu menu = (VehicleDetailsMenu)VehicleTypeSelection;

                switch (menu)
                {
                    case VehicleDetailsMenu.Motorcyles:
                        Console.Clear();
                        Console.WriteLine("====Motorcyles====\n");
                        foreach (var item in Motorcyles)
                        {
                            item.PrintDetails();
                        }
                        break;
                    case VehicleDetailsMenu.Vans:
                        Console.Clear();
                        Console.WriteLine("====Vans====\n");
                        foreach (var item in Vans)
                        {
                            item.PrintDetails();
                        }
                        break;
                    case VehicleDetailsMenu.Trucks:
                        Console.Clear();
                        Console.WriteLine("====Trucks====\n");
                        foreach (var item in Trucks)
                        {
                            item.PrintDetails();
                        }
                        break;
                    case VehicleDetailsMenu.AllVehicles:
                        Console.Clear();
                        PrintAllVehicles();
                        break;
                    case VehicleDetailsMenu.ReturnToVehiclesMenu:
                        Console.Clear();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Input. Please enter a number (1-5) only\n");
                        break;
                }

            }

        }


    }
}
