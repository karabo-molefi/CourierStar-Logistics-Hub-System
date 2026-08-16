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
        Search
    }

    internal class VehicleRepository : IPrintable, ISearch
    {
        // menu for managing vehicles

        public void ManageVehicles()
        {
            Console.WriteLine("====Vehicle Manager====");

            Console.WriteLine($"1. Add a New vehicle\n" +
                $"2. Get Summary of vehicles\n" +
                $"3. Get Vehicle Details\n" +
                $"4. Search For Vehicle\n" +
                $"Enter (1-4):");

            int option = int.Parse(Console.ReadLine());

            VehicleMenu menu = (VehicleMenu)option;

            switch (menu)
            {
                case VehicleMenu.AddVehicle:
                    AddVehicle();
                    break;
                case VehicleMenu.PrintVehicleSummary:
                    PrintVehicleSummary();
                    break;
                case VehicleMenu.PrintVehicleDetails:
                    PrintDetails();
                    break;
                case VehicleMenu.Search:
                    Search();
                    break;
            }
        }

        // Collections for vehicle types
        List<Motorcyle> Motorcyles = new List<Motorcyle>();
        List<Van> Vans = new List<Van>();   
        List<Truck> Trucks = new List<Truck>();

        // Starter data


        // Add a vehicle

        private int CountMotorcycles;
        private int CountVans;
        private int CountTrucks;

        public VehicleRepository()
        {
            CountMotorcycles = Motorcyles.Count;
            CountVans = Vans.Count;
            CountTrucks = Trucks.Count;
            
        }

        void AddVehicle()
        {
            Console.WriteLine($"Select Vehicle Type:\n" +
                $"1. Motorcycle\n" +
                $"2. Van\n" +
                $"3. Truck\n" +
                $"Enter (1-3):");

            int VehicleTypeSelection = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter VehicleId:");
            int VehicleId = int.Parse(Console.ReadLine());


            // logic to add to different vehicle collections

            /*int VehicleId, double CurrentLoad, double MaxCapacity, double MaxWeight, double MaxDimensions*/

            switch (VehicleTypeSelection)
            {
                case 1:
                    Motorcyle motorcyle = new Motorcyle(VehicleId, 0, 10, 10, 0.04);
                    Motorcyles.Add(motorcyle);
                    break;
                case 2:
                    Van van = new Van(VehicleId, 0, 1000, 1000, 4.935, "Van");
                    Vans.Add(van);
                    break;
                case 3:
                    Truck truck = new Truck(VehicleId, 0, 4500, 4500, 50);
                    Trucks.Add(truck);
                    break;
            }

            // give feedback for sucessful addition

            Console.WriteLine("Vehicle Added Successfully.");
        }

        // Print summary of all vehiicles

        public void PrintVehicleSummary()
        {
            // total no of each vehicle
            Console.WriteLine("====Vehicle Repository Summary====");
            Console.WriteLine($"{CountMotorcycles} Motorcyles");
            Console.WriteLine($"{CountVans} Vans");
            Console.WriteLine($"{CountTrucks} Trucks");
            Console.WriteLine("--------");
            Console.WriteLine($"{CountMotorcycles + CountTrucks + CountVans} Total Vehicles");// total no of vehicles
            Console.WriteLine("--------");
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
            Console.WriteLine("====Vans====");
            foreach (var item in Vans)
            {
                item.PrintDetails();
            }
            Console.WriteLine("====Trucks====");
            foreach (var item in Trucks)
            {
                item.PrintDetails();
            }
        }

        // search 

        public void Search()
        {
            Console.Clear();
            Console.WriteLine("Enter Vehicle ID: ");
            int searchId = int.Parse(Console.ReadLine());
            Vehicle foundVehicle = (Motorcyles.FirstOrDefault(fm => fm.VehicleIdProperty == searchId) as Vehicle)
                ?? (Vans.FirstOrDefault(fv => fv.VehicleIdProperty == searchId) as Vehicle)
                ?? (Trucks.FirstOrDefault(ft => ft.VehicleIdProperty == searchId) as Vehicle);

            if (foundVehicle != null)
            {
                foundVehicle.PrintDetails();
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
        }


        // print vehicle details
        public void PrintDetails()

        {
            Console.WriteLine($"Select Vehicle Type (or enter 4 for  All Vehicles):\n" +
                $"1. Motorcycle" +
                $"2. Van" +
                $"3. Truck" +
                $"4. All Vehicles" +
                $"Enter (1-4):");

            int VehicleTypeSelection = int.Parse(Console.ReadLine());

            switch (VehicleTypeSelection) 
            {
                case 1:
                    Console.WriteLine("====Motorcyles====");
                    foreach (var item in Motorcyles)
                    {
                        item.PrintDetails();
                    }
                    break;
                case 2:
                    Console.WriteLine("====Vans====");
                    foreach (var item in Vans)
                    {
                        item.PrintDetails();
                    }
                    break;
                case 3:
                    Console.WriteLine("====Trucks====");
                    foreach (var item in Trucks)
                    {
                        item.PrintDetails();
                    }
                    break;
                case 4:
                    PrintAllVehicles();
                    break;
            }


        }


    }
}
