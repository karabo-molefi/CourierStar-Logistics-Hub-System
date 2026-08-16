using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{
    internal class Truck: Vehicle
    {
        private double MaxWeight = 4500;//kilograms
        private double MaxDimension = 30;//cubic meters
        string VehicleType = "Truck";


        // Constructor
        Truck(int VehicleId, double CurrentLoad, double MaxCapacity, double MaxWeight, double MaxDimension) : base(VehicleId, CurrentLoad, MaxCapacity)
        {
            this.MaxWeight = MaxWeight;
            this.MaxDimension = MaxDimension;
        }

        //Methods 
        public override double CalculateRemainingCapacity()
        {
            return MaxCapacity - CurrentLoad;
        }

        public override void PrintDetails()
        {
            Console.WriteLine($"VehicleId: {VehicleId}\n" +
               $"Vehicle Type: {VehicleType}\n" +
               $"CurrentLoad: {CurrentLoad}\n" +
               $"MaxCapacity: {MaxCapacity}");

        }
    }
}
