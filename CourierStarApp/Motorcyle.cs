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

        public Motorcyle(int VehicleId, double CurrentLoad, double CurrentVolume, double MaxWeight, double MaxDimensions) : base(VehicleId, CurrentLoad,MaxWeight,MaxDimensions,CurrentVolume)
        {
            this.MaxWeight = MaxWeight;
            this.MaxDimensions = MaxDimensions;
        }

     
        //Abstract Method CanCarry- required for every vehicle type

        public override bool CanCarry(Package Package)
        {

            if (CurrentLoad + Package.weight >= MaxWeight)
            {
                return false;
            }
            else if (CurrentVolume + Package.volume >= MaxDimensions)
            {
                return false;
            }
            else
            {
                return true;
            }


        }

        // Methods
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
