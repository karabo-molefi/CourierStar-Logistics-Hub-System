using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{
    internal class Vehicle
    {
        protected int VehicleId;
        protected double CurrentLoad;
        protected double MaxCapacity;

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

        public void TriggerWarning()
        {
            // implement warning
        }

        public void PrintDetails()
        {
            Console.WriteLine($"VehicleId: {VehicleId}\n" +
                $"CurrentLoad: {CurrentLoad}\n" +
                $"MaxCapacity: {MaxCapacity}" +
                $"Vehicle Type: ");// add type of vehicle

        }




        
    }
}
