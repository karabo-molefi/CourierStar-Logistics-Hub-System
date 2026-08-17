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
        public Truck(int VehicleId, double CurrentLoad,double CurrentVolume, double MaxWeight, double MaxDimension) : base(VehicleId, CurrentLoad,MaxWeight,MaxDimension, CurrentVolume)
        {
            this.MaxWeight = MaxWeight;
            this.MaxDimension = MaxDimension;
        }

        //Abstract Method CanCarry- required for every vehicle type

        public override bool CanCarry(Package Package)
        {

            if (CurrentLoad + Package.weight >= MaxWeight)
            {
                return false;
            }
            else if (CurrentVolume + Package.volume >= MaxDimension)
            {
                return false;
            }
            else
            {
                return true;
            }


        }
        //Methods 
        public override double CalculateRemainingCapacity()
        {
            return MaxWeight - CurrentLoad;
        }

        public override void PrintDetails()
        {
            Console.WriteLine($"VehicleId: {VehicleId}\n" +
               $"Vehicle Type: {VehicleType}\n" +
               $"CurrentLoad: {CurrentLoad}\n" +
               $"MaxCapacity: {MaxWeight}");

        }
    }
}
