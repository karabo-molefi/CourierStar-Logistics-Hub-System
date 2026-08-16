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
        
        //Constructor
        Van(int VehicleId, double CurrentLoad, double MaxCapacity, double MaxWeight, double MaxVolume) : base(VehicleId, CurrentLoad, MaxCapacity)
        {
            this.MaxWeight = MaxWeight;
            this.MaxVolume = MaxVolume;
            MaxCapacity = MaxWeight;

        }

        //Method
        public override double CalculateRemainingCapacity()
        {
            return MaxCapacity - CurrentLoad;
        }


    }
}
