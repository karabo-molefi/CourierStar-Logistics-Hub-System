using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{



    public class OrderManagement
    {
        //Order Package and Customer Management
        enum OrderMenu
        {
            CreateNewOrder = 1,
            AssignNewPackage,
            editOrderCustomer,
            Search,
            AddPackage,
            exit
        }
        public OrderManagement()
        {

        }

        public static List<Order> Orders = new List<Order>();
        public static List<Package> Packages = new List<Package>();
        public static List<Customer> Customers = new List<Customer>();

        public void ManageOrders()
        {


            bool running = true;
            Console.Clear();

            while (running)
            {
                Console.WriteLine("====Order Manager====");

                Console.WriteLine($"1. Add a New Order\n" +
                    $"2. Assign different Package to order\n" +
                    $"3. edit Order Customer\n" +
                    $"4. Search For Order\n" +
                    $"5. Add New Package \n" +
                    $"6. Exit\n" +
                    $"Enter (1-5):");

                int option = int.Parse(Console.ReadLine());

                OrderMenu menu = (OrderMenu)option;

                switch (menu)
                {
                    case OrderMenu.CreateNewOrder:
                        Console.Clear();
                        AddOrder();
                        break;
                    case OrderMenu.AssignNewPackage:
                        Console.Clear();
                        AssignPackage();
                        break;
                    case OrderMenu.editOrderCustomer:
                        Console.Clear();
                        editCustomer();
                        break;
                    case OrderMenu.Search:
                        Console.Clear();
                        SearchOrder();
                        
                        break;
                    case OrderMenu.AddPackage:
                        Console.Clear();
                        AddPackage();
                        break;
                    case OrderMenu.exit:
                        Console.Clear();
                        running = false;
                        break;
                }
            }
        }

        public void AddPackage()
        {
            Console.WriteLine("======Creating New Package===========");
            int PackageId = Packages.Count > 0
            ? Packages.Max(o => o.packageId) + 1
            : 1;

            Console.WriteLine("Enter Length of package in meters");
            double length = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter width of package in meters");
            double width = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter height of package in meters");
            double height = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter weight of package in kg");
            double weight = double.Parse(Console.ReadLine());

            Package newPackage = new Package(PackageId, weight, length, width, height);
            Packages.Add(newPackage);

        }
        //Create New Order
        public void AddOrder()
        {
            Console.WriteLine("======Creating New Order===========");
            int OrderId = Orders.Count > 0
            ? Orders.Max(o => o.OrderId) + 1
            : 1;
            Customer foundCustomer = null;
            while (foundCustomer == null)
            {
                Console.WriteLine("Enter CustomerId for this Order");
                int CustomerId = int.Parse(Console.ReadLine());

                foundCustomer = Customers.FirstOrDefault(c => c.CustomerId == CustomerId);
                if (foundCustomer != null)
                {
                    Console.WriteLine($"This Order is for Customer: {foundCustomer.name}");
                }
                else
                {
                    Console.WriteLine($"Customer with ID {CustomerId} Not Found, Please Enter a different ID");

                }
            }

            Package foundPackage = null;
            while (foundPackage == null)
            {
                Console.WriteLine("Enter the Package Id for this Order");
                int PackageId = int.Parse(Console.ReadLine());

                foundPackage = Packages.FirstOrDefault(p => p.packageId == PackageId);
                if (foundPackage != null)
                {
                    Console.WriteLine($"This Order has been assigned the Package with ID: {foundPackage.packageId}");
                }
                else
                {
                    Console.WriteLine($"Package with ID {PackageId} Not Found, Please Enter a different ID");

                }
            }




            Vehicle AssignedVehicle = null;
            string Status = null;

            var AllVehicles = VehicleRepository.Motorcyles.Cast<Vehicle>().Concat(VehicleRepository.Trucks).Concat(VehicleRepository.Vans);
            AssignedVehicle = AllVehicles.FirstOrDefault(v => v.CanCarry(foundPackage));
            if (AssignedVehicle != null)
            {
                AssignedVehicle.LoadPackage(foundPackage);
                Status = "Assigned";
                Console.WriteLine($"Package has been assigned to a vehicle.");
            }
            else
            {
                Status = "Unassigned";
                Console.WriteLine("No suitable vehicle found., will be assigned at a later stage");
            }

            Order newOrder = new Order(OrderId, foundCustomer, foundPackage);
            if (AssignedVehicle != null)
            {
                newOrder.AssignVehicle(AssignedVehicle);
                newOrder.UpdateStatus(Status);
            }
            else
            {
                newOrder.UpdateStatus(Status);
            }

            Orders.Add(newOrder);

        }

        //Assign New Package to Order

        public void AssignPackage()
        {
            Console.WriteLine("Assigning Package to order \n" +
                "Please Enter the Order ID of the Order you are changing");

            int searchId = int.Parse(Console.ReadLine());

            Order foundOrder = Orders.FirstOrDefault(o => o.OrderId == searchId);

            if (foundOrder != null)
            {
                Console.WriteLine($"Order {foundOrder.OrderId} for {foundOrder.customer.name}");
                Console.WriteLine($"Please enter the PackageID you would like to assign to Order: {foundOrder.OrderId}");
                int PackageSearch = int.Parse(Console.ReadLine());

                Package foundPackage = Packages.FirstOrDefault(p => p.packageId == PackageSearch);
                if (foundPackage != null)
                {
                    foundOrder.UpdatePackage(foundPackage);
                }
                else
                {
                    Console.WriteLine("Package Not found");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Order not found.");
                return;
            }


        }
        //Edit Orders Reciepient
        public void editCustomer()
        {
            Console.WriteLine("Editing Which Customer an Order will go to");

            Console.WriteLine("Assigning Customer to order \n" +
                "Please Enter the Order ID of the Order you are changing");


            int SearchOrder = int.Parse(Console.ReadLine());
            Order foundOrder = null;

            while (foundOrder == null)
            {
                foundOrder = Orders.FirstOrDefault(o => o.OrderId == SearchOrder);
                if (foundOrder != null)
                {
                    Console.WriteLine($"Editing Customer for Order with ID: {foundOrder.OrderId}");
                }
                else
                {
                    Console.WriteLine("Order Not Found");
                }
            }

            Customer foundCustomer = null;
            Console.WriteLine("Please enter the Id of the New Customer");
            int SearchCustomer = int.Parse(Console.ReadLine());

            while (foundCustomer == null)
            {
                foundCustomer = Customers.FirstOrDefault(c => c.CustomerId == SearchCustomer);
                if (foundCustomer != null)
                {
                    foundOrder.EditCustomer(foundCustomer);
                    Console.WriteLine($"You have Assigned Order with ID:{foundOrder.OrderId} to customer: {foundCustomer.name} with ID:{foundCustomer.CustomerId}");

                }
                else
                {
                    Console.WriteLine("Customer Not found");
                }

            }






        }

        //Search Order
        public void SearchOrder()
        {
            Console.WriteLine("=========Searching for orders=========");
            Console.WriteLine("Please enter the Order ID you would like to search for");
            int SearchOrder = int.Parse(Console.ReadLine());

            Order foundOrder = Orders.FirstOrDefault(o => o.OrderId == SearchOrder);
            if (foundOrder != null)
            {
                foundOrder.PrintOrderDetails();

            }
            else
            {
                Console.WriteLine("Order Not found");
            }


        }

    }
    }
