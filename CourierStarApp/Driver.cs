using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{
    internal class Driver : Staff, IPrintable
    {


        public Driver(string sID, string sName, string div) : base (sID, sName, div)
        {

        }
    }
}
