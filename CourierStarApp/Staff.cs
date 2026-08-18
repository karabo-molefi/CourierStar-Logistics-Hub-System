using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{
    public abstract class Staff : IPrintable
    {
        public string division { get; set; }
        public string staffName { get; private set; }
        public int staffID { get; private set; }
        public string fullStaffID { get; protected set; }

        //Constructor
        protected Staff(string sName, string div)
        {
            Random random = new Random();
            this.staffID = random.Next(1000, 10000);

            this.staffName = sName;
            this.division = div;

        }

        //Methods
        public abstract void GenerateIDModifier();

        public virtual void PrintDetails()
        {
            Console.WriteLine("================================");
            Console.WriteLine($"Staff Member Details: ");
            Console.WriteLine("================================");
            Console.WriteLine();
            Console.WriteLine($"Staff ID: {fullStaffID} \nName: {staffName} \nDivision: {division}");
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrEmpty(newName))
            {
                Console.WriteLine("Insert data.");
                return;
            }

            staffName = newName;
        }
    }
}
