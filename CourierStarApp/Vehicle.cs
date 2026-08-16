using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{
    internal class Vehicle: IWarning, IPrintable
    {
        protected int VehicleId;
        protected double CurrentLoad;
        protected double MaxCapacity;

        public int VehicleIdProperty
        {
            get { return VehicleId; }
        }

        // Constructor 
        public Vehicle (int VehicleId, double CurrentLoad, double MaxCapacity)
        {
            this.VehicleId = VehicleId;
            this.CurrentLoad = CurrentLoad;
            this.MaxCapacity = MaxCapacity;
        } 

        // Methods

        public void LoadPackage(/*Package rp*/)
        {

        }

        public virtual double CalculateRemainingCapacity()
        {
            double RemainingCapacity = MaxCapacity - CurrentLoad;
            return RemainingCapacity;
        }

        // warning for almost at capacity

         public double WarningThreshold
        {
            get { return 0.9 * MaxCapacity; }
        }


        public void TriggerWarning()
        {
            // implement warning
            if (WarningThreshold <= CurrentLoad)
            {
                Console.WriteLine($"WARNING:\n" +
                    $"Vehicle ({VehicleId}) has reached the warning threshold of {WarningThreshold}kg.\n" +
                    $"Current Load: {CurrentLoad}kg.\n" +
                    $"Allowable Additional Load: {MaxCapacity - CurrentLoad}kg.");
            }
        }

        public virtual void PrintDetails()
        {
        }




        
    }
}
