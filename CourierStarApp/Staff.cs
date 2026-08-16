using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{
    internal class Staff : IPrintable
    {
        public string staffID, staffName, division;

        //Constructor
        public Staff(string sID, string sName, string div)
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
            Console.WriteLine($"");
        }
    }
}
