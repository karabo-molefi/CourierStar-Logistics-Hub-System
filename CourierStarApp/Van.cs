using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{
    internal class Van: Vehicle
    {
        double MaxWeight = 1000;//kilograms
        double MaxVolume = 4.935; //cubic meters
        string VehicleType = "Van";
        
        //Constructor
        public Van(int VehicleId, double CurrentLoad, double MaxCapacity, double MaxWeight, double MaxVolume, string VehicleType) : base(VehicleId, CurrentLoad, MaxCapacity)
        {
            this.MaxWeight = MaxWeight;
            this.MaxVolume = MaxVolume;
            this.VehicleType = VehicleType;
            MaxCapacity = MaxWeight;

        }

        //Method
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
