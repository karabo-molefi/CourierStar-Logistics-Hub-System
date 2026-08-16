using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{
    internal class Motorcyle: Vehicle
    {
        private double MaxWeight =10; //kilograms
        private double MaxDimensions= 0.04;// cubic meters

        // Constructor

        Motorcyle(int VehicleId, double CurrentLoad, double MaxCapacity, double MaxWeight, double MaxDimensions) : base(VehicleId, CurrentLoad, MaxCapacity)
        {
            this.MaxWeight = MaxWeight;
            this.MaxDimensions = MaxDimensions;
        }

        // Methods
        public override double CalculateRemainingCapacity()
        {
            return MaxCapacity - CurrentLoad;
        }


    }
}
