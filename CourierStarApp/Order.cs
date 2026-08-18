using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{
    public class Order
    {
        public Customer customer { get; set; }
        public Package package { get; set; }
        internal Vehicle AssignedVehicle { get; private set; }
        public string Status { get; private set; } = "Pending";

        public Order(Customer Customer, Package Package)
        {
            customer = Customer;
            package = Package;
        }

        internal void AssignVehicle(List<Vehicle> availableVehicles)
        {
            foreach (var vehicle in availableVehicles)
            {
                if (vehicle.CanCarry(package))
                {
                    AssignedVehicle = vehicle;
                    //vehicle.LoadPackage();
                    Status = "Assigned";
                    return;

                }
            }

            Status = "Unassigned";
            Console.WriteLine("No vehicles available at the moment");

        }

    }


}

