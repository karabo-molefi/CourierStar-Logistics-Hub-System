using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{


	public class Customer
	{
		public string name { get; set; }
		public string address { get; set; }
		public string phoneNumber { get; set; }

		public Customer(string Name, string Address, string PhoneNumber)
		{
			name = Name;
			address = Address;
			phoneNumber = PhoneNumber;
		}
	}
}
