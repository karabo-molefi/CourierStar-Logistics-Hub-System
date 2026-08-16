using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{
    internal class OfficeStaff : Staff, IPrintable
    {
        public string officeIDModifier;
        public string workstation;

        //Constructor
        public OfficeStaff(string sID, string sName, string div, string workstation) : base (sID, sName, div)
        {
            this.workstation = workstation;
        }

        enum WorkstationChoices
        {
            Reception,
            Sales,
            Maintenance,
            Administration,
            Customer_Service,
            Logistics,
            Data
        }

        public override void GenerateIDModifier()
        {
           
        }
    }
}
