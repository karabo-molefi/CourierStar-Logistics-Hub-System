using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{
    public class LicenseMismatchException : Exception
    {
        public LicenseMismatchException(string message)

            : base(message)
        {

        }

    }
}
