using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{
    internal class VehicleRepository
    {
        // Add a vehicle
        void AddVehicle()
        {
            Console.WriteLine($"Select Vehicle Type:\n" +
                $"1. Motorcycle" +
                $"2. Van" +
                $"3. Truck" +
                $"Enter (1-3):");

            int VehicleTypeSelection = int.Parse( Console.ReadLine());
            string VehicleType;

            switch (VehicleTypeSelection)
            {
                case 1:
                    VehicleType = "Motorcycle";
                    break;
                case 2:
                    VehicleType = "Van";
                    break;
                case 3:
                    VehicleType = "Truck";
                    break;
            }


            Console.WriteLine("Enter VehicleId:");
            int VehicleId = int.Parse(Console.ReadLine());
        }
    }
}
