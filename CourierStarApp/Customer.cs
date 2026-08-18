using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{
	

	public class Customer
	{
		public string name { get; private set; }
		public string address { get; private set; }
		public string phoneNumber { get; private set; }
		public int CustomerId { get; private set; }

		public Customer(int customerId, string Name, string Address, string PhoneNumber)
		{
			name = Name;
			address = Address;
			phoneNumber = PhoneNumber;
			CustomerId = customerId;
		}

        public void setName(string name)
        {
            this.name = name;
        }
        public void setPhone(string Phone)
        {
            this.phoneNumber = Phone;
        }
        public void setAddress(string address)
        {
            this.address = address;
        }
    }

	public class ManageCustomer
	{

        enum CustomerMenu
        {
            AddCustomer = 1,
            EditAddress,
            editName,
            editPhone,
            SearchCustomer,
            exit
        }
        public ManageCustomer()
        {

        }
        public void AddCustomer()
        {


            int CustomerId = OrderManagement.Customers.Count > 0
            ? OrderManagement.Customers.Max(o => o.CustomerId) + 1
            : 1;
            Console.WriteLine("Enter Customer Name");
            string Cname = Console.ReadLine();
            Console.WriteLine("Enter Customer Adress");
            string Caddress = Console.ReadLine();
            Console.WriteLine("Enter Customer Phone Number");
            string Cphone = Console.ReadLine();

            Customer newCustomer = new Customer(CustomerId, Cname, Caddress, Cphone);
            OrderManagement.Customers.Add(newCustomer);
            Console.WriteLine("Added new Customer");


        }
        public void EditName()
        {
            Console.WriteLine("===========Editing the Name of a customer==========\n" +
                "Enter the Customer Id of the customer you want to edit");

            int SearchCustomer = int.Parse(Console.ReadLine());

            Customer foundCustomer = OrderManagement.Customers.FirstOrDefault(c => c.CustomerId == SearchCustomer);
            if (foundCustomer != null)
            {
                Console.WriteLine($"Found the Customer, Enter the new name for {foundCustomer.name}");
                string name = Console.ReadLine();
                foundCustomer.setName(name);
            }
            else
            {
                Console.WriteLine("Customer to edit not found, try another ID");
            }



        }



        public void EditAddress()
        {
            Console.WriteLine("===========Editing the Address of a customer==========\n" +
                "Enter the Customer Id of the customer you want to edit");

            int SearchCustomer = int.Parse(Console.ReadLine());

            Customer foundCustomer = OrderManagement.Customers.FirstOrDefault(c => c.CustomerId == SearchCustomer);
            if (foundCustomer != null)
            {
                Console.WriteLine($"Found the Customer, Enter the new Address for {foundCustomer.name}");
                string address = Console.ReadLine();
                foundCustomer.setAddress(address);

            }
            else
            {
                Console.WriteLine("Customer to edit not found, try another ID");
            }



        }

        public void EditPhone()
        {
            Console.WriteLine("===========Editing the Phone Number of a customer==========\n" +
                "Enter the Customer Id of the customer you want to edit");

            int SearchCustomer = int.Parse(Console.ReadLine());

            Customer foundCustomer = OrderManagement.Customers.FirstOrDefault(c => c.CustomerId == SearchCustomer);
            if (foundCustomer != null)
            {
                Console.WriteLine($"Found the Customer, Enter the new name for {foundCustomer.name}");
                string Phone = Console.ReadLine();
                foundCustomer.setPhone(Phone);
            }
            else
            {
                Console.WriteLine("Customer to edit not found, try another ID");
            }



        }
        public void SearchCustomer()
        {
            Console.WriteLine("===========Searching for a customer==========\n" +
                "Enter the Customer Id of the customer you want to serach");

            int SearchCustomer = int.Parse(Console.ReadLine());

            Customer foundCustomer = OrderManagement.Customers.FirstOrDefault(c => c.CustomerId == SearchCustomer);
            if (foundCustomer != null)
            {
                Console.WriteLine($"Found the Customer, Enter the new name for {foundCustomer.name}");
                PrintCustomerDetails(foundCustomer);
            }
            else
            {
                Console.WriteLine("Customer to edit not found, try another ID");
            }



        }

        public void PrintCustomerDetails(Customer Customer)
        {
            Console.WriteLine($"Customer Details: \n" +
                $"Name: {Customer.name}\n" +
                $"Address: {Customer.address}\n" +
                $"Phone Number: {Customer.phoneNumber} \n" +
                $"ID: {Customer.CustomerId}");
        }

        public void ManageCustomers()
        {
            bool running = true;

            while (running)
            {

                Console.WriteLine("=============Customer Management=============");

                Console.WriteLine($"1. Add new customer \n" +
                    $"2. Edit Customers Address \n" +
                    $"3. Edit Customers Name \n" +
                    $"4. Edit Customer Phone Number \n" +
                    $"5. Search Customer \n" + 
                    $"6. Exit \n" +
                    $"Enter 1- 6");


                int choice = int.Parse(Console.ReadLine());

                CustomerMenu menu = (CustomerMenu)choice;

                switch (menu)
                {
                    case CustomerMenu.AddCustomer:
                        Console.Clear();
                        AddCustomer();
                        break;
                    case CustomerMenu.EditAddress:
                        Console.Clear();
                        EditAddress();
                        break;
                    case CustomerMenu.editName:
                        Console.Clear();
                        EditName();
                        break;
                    case CustomerMenu.editPhone:
                        Console.Clear();
                        EditPhone();
                        break;
                    case CustomerMenu.SearchCustomer:
                        Console.Clear();
                        SearchCustomer();
                        break;
                    case CustomerMenu.exit:
                        running = false;
                        break;
                }

            }
        }
    }
}

	