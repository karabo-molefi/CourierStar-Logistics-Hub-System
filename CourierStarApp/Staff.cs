using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{
    internal class Staff : IPrintable
    {
        public string fullID, staffName, division;
        public int staffID { get; protected set; }

        //Constructor
        public Staff(int sID, string sName, string div)
        {
            this.staffID = sID;
            this.staffName = sName;
            this.division = div;

        }

        //Methods
        public virtual void GenerateIDModifier()
        {

        }

        public virtual void PrintDetails()
        {
            Console.WriteLine($"Staff Member Details: ");
            Console.WriteLine();
            Console.WriteLine($"Staff ID: {staffID} \nName: {staffName} \nDivision: {division}");
        }
    }
}
