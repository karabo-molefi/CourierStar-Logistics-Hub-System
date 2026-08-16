using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierStarApp;


namespace CourierStarApp
{
    internal abstract class Vehicle: IWarning, IPrintable
    {
        protected int VehicleId;
        protected double CurrentLoad;
        protected double CurrentVolume;
        protected double MaxWeight;
        protected double MaxVolume;

        // Constructor 
        public Vehicle (int VehicleId, double CurrentLoad, double MaxWeight,double MaxVolume,  double CurrentVolume)
        {
            this.VehicleId = VehicleId;
            this.CurrentLoad = CurrentLoad;
            this.MaxWeight = MaxWeight;
            this.CurrentVolume = CurrentVolume;
            this.MaxVolume = MaxVolume;
        } 

        // Methods

        public void LoadPackage(Package Package)
        {
            CurrentLoad += Package.weight;
            CurrentVolume += Package.volume;
            Console.WriteLine("Package Loaded Successfully");

        }

        public abstract bool CanCarry(Package Package);
        public virtual double CalculateRemainingCapacity()
        {

            return MaxWeight - CurrentLoad;
        }

        // warning for almost at capacity

         public double WarningThreshold
        {
            get { return 0.9 * MaxWeight; }
        }


        public void TriggerWarning()
        {
            // implement warning
            if (WarningThreshold <= CurrentLoad)
            {
                Console.WriteLine($"WARNING:\n" +
                    $"Vehicle ({VehicleId}) has reached the warning threshold of {WarningThreshold}kg.\n" +
                    $"Current Load: {CurrentLoad}kg.\n" +
                    $"Allowable Additional Load: {MaxWeight - CurrentLoad}kg.\n"+
                     $"Current Volume: {CurrentVolume}m3.\n" +
                    $"Allowable Additional Load: {MaxVolume - CurrentVolume}kg."
                    );
            }
        }

        public virtual void PrintDetails()
        {
        }




        
    }
}
