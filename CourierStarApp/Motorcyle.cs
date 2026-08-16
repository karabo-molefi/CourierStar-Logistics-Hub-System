using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{
    internal class Motorcyle: Vehicle
    {
        private double MaxWeight = 10; //kilograms
        private double MaxDimensions = 0.04;// cubic meters
        string VehicleType = "Motorcycle";

        // Constructor

        public Motorcyle(int VehicleId, double CurrentLoad, double MaxCapacity, double MaxWeight, double MaxDimensions) : base(VehicleId, CurrentLoad, MaxCapacity)
        {
            this.MaxWeight = MaxWeight;
            this.MaxDimensions = MaxDimensions;
        }

        // Methods
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
