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
        public LicenseType licenseType;
        public string driverIDModifier;
        public bool licenseIsValid;

        //Constructor

        public Driver(string sName, string div, LicenseType licType) : base(sName, div)
        {
            this.licenseType = licType;
            this.licenseIsValid = true;

            if (licenseIsValid == true)
            {
                licenseIsValid = Convert.ToBoolean("Yes");
            }

            else
            {
                licenseIsValid = Convert.ToBoolean("No");
            }
        }

        public override void GenerateIDModifier()
        {
            driverIDModifier = "VD";
        }

        public override void PrintDetails()
        {
            Console.WriteLine("================================");
            Console.WriteLine($"Driver Staff Details: ");
            Console.WriteLine("================================");
            Console.WriteLine();
            Console.WriteLine($"Staff ID: {fullStaffID} \nName: {staffName} \nLicense Type: {licenseType} \nValid License: {licenseIsValid}");
        }

        public void ValidateLicense(LicenseType requiredLicense)
        {
            if (licenseType != requiredLicense)
            {
                licenseIsValid = false;

                throw new LicenseMismatchException(
                    $"Driver {staffName} has a {licenseType} license, but the vehicle requires a {requiredLicense} license.");
                
            }

            else
            {
                licenseIsValid = true;
            }
        }

        public void UpdateLicense(LicenseType newLicense)
        {
            licenseType = newLicense;
            licenseIsValid = true;
        }

    }

    public enum LicenseType
    {
        Motorcycle = 1,
        Light_Vehicle = 2,
        Heavy_Vehicle = 3
    }

}
