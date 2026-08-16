using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CourierStarApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //TEST CODE TO CHECK IF ALL CLASSES&METHODS WORK // feel free to remove 
            Customer cust = new Customer("John Doe", "123 Main St", "555-1234");

            // Create a package (weight in kg, dimensions in cm)
            Package pkg = new Package(1200, 50, 40, 30);

            // Create an order
            Order order = new Order(cust, pkg);

            // Create available vehicles
            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Truck(1, 0, 5000, 20000, 0),
                new Van(2, 0, 2000, 8000, 0),
                //new Car(3, 0, 1000, 4000, 0),
                new Motorcycle(4, 0, 200, 500, 0)
            };

            // Try to assign a vehicle
            order.AssignVehicle(vehicles);

            // Print results
            Console.WriteLine($"Order for {order.customer.name} is {order.Status}.");
            if (order.AssignedVehicle != null)
            {
                Console.WriteLine($"Assigned vehicle: {order.AssignedVehicle.GetType().Name}");
                order.AssignedVehicle.PrintDetails();
            }

            Console.ReadLine();
        }
    }
}
