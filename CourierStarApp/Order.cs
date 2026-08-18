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
        public Package package { get; private set; }
        internal int OrderId { get; private set; }
        internal Vehicle AssignedVehicle { get; private set; }
        public string Status { get; private set; } = "Pending";

        public Order(int orderID,Customer Customer, Package Package)
        {
            customer = Customer;
            package = Package;
            OrderId = orderID;

        }

        public void EditCustomer(Customer Customer)
        {
            this.customer = Customer;
        }
        internal void AssignVehicle(Vehicle Vehicle)
        {
            this.AssignedVehicle = Vehicle;
        }
        public void UpdateStatus(string Status)
        {
            this.Status = Status;
        }
        public void UpdatePackage(Package Package)
        {
            this.package = Package;
        }

        public void PrintOrderDetails()
        {
            Console.WriteLine("==============Order Details=========");
            Console.WriteLine($"Order ID:{OrderId} \n" +
                $"Customers Name: {customer.name}, CustomerID:{customer.CustomerId} \n" +
                $"Package ID: {package.packageId}\n" +
                $"Order Destination: {customer.address} \n" +
                $"Vehicle Status: {Status}");
        }
        //internal void AssignVehicle(List<Vehicle> availableVehicles)
        //{
        //    foreach (var vehicle in availableVehicles)
        //    {
        //        if (vehicle.CanCarry(package))
        //        {
        //            AssignedVehicle = vehicle;
        //            //vehicle.LoadPackage();
        //            Status = "Assigned";
        //            return;

        //        }
        //    }

        //    Status = "Unassigned";
        //    Console.WriteLine("No vehicles available at the moment");

        //}

    }


}

