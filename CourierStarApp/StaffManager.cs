using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{
    internal class StaffManager
    {
        private List<Staff> staffMembers = new List<Staff>();


        //Create / Add Staff
        public void AddStaff()
        {
            Staff newMember = null;

            Console.WriteLine("========================");
            Console.WriteLine("Adding Staff Member...");
            Console.WriteLine("========================");
            Console.WriteLine();

            Console.WriteLine("Enter staff member's full name: ");
            string name = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Select a division by entering the corresponding number: ");
            Console.WriteLine("1. Driver \n2. Office \nChoice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid entry!");
                return;
            }

            if (choice != 1 && choice != 2)
            {
                Console.WriteLine("Invalid option! Please try again.");
                return;
            }


            if (choice == 1) //Driver
            {
                Console.WriteLine("Select the fitting driver's license by inputting the corresponding number: ");
                Console.WriteLine("1. Motorcycle");
                Console.WriteLine("2. Light Vehicle");
                Console.WriteLine("3. Heavy Vehicle");
                Console.WriteLine("Choice: ");

                if (!int.TryParse(Console.ReadLine(), out int licenseChoice))
                {
                    Console.WriteLine("Invalid selection! Please try again.");
                    return;
                }

                if (!Enum.IsDefined(typeof(LicenseType), licenseChoice))
                {
                    Console.WriteLine("Invalid selection! Please try again.");
                    return;
                }

                LicenseType license = (LicenseType)licenseChoice;

                newMember = new Driver(name, "Driver", license);
            }

            else if (choice == 2) //Office
            {
                Console.WriteLine("Select a workstation by inputting the corresponding number: ");

                foreach (WorkstationChoices workstation in Enum.GetValues(typeof(WorkstationChoices)))
                {
                    Console.WriteLine($"{(int)workstation}. {workstation}");
                }

                Console.WriteLine("Choice: ");

                if (!int.TryParse(Console.ReadLine(), out int workstationChoice))
                {
                    Console.WriteLine("Invalid entry.");
                    return;
                }

                if (!Enum.IsDefined(typeof(WorkstationChoices), workstationChoice))
                {
                    Console.WriteLine("Invalid entry.");
                    return;
                }

                WorkstationChoices workstations = (WorkstationChoices)workstationChoice;

                newMember = new OfficeStaff(name, "Office", workstations);
            }

            else
            {
                Console.WriteLine("Invalid entry. Please try again.");
            }


            staffMembers.Add(newMember);
            Console.WriteLine();
            Console.WriteLine("Staff member added successfully!");
            Console.WriteLine($"Staff ID: {newMember.fullStaffID}.");
        }

        //Remove Staff

        public void RemoveStaff()
        {
            Staff removeMember = null;

            Console.WriteLine("===========================");
            Console.WriteLine("Removing Staff Member...");
            Console.WriteLine("===========================");
            Console.WriteLine();

            if (staffMembers.Count == 0)
            {
                Console.WriteLine("There are no staff members.");
                return;
            }

            Console.WriteLine("Enter the Staff ID of the staff member to remove them: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid entry;");
                return;
            }

            foreach (Staff member in staffMembers)
            {
                if (member.staffID == id)
                {
                    removeMember = member;
                    break;
                }
            }

            if (removeMember == null)
            {
                Console.WriteLine("No staff member with that ID was found.");
            }

            Console.WriteLine();
            Console.WriteLine($"Removing {removeMember.staffName}...");

            staffMembers.Remove(removeMember);
            Console.WriteLine($"Staff member, {removeMember.staffName}, has been removed successfully!");
        }

        //Display / Read Staff

        public void DisplayStaff()
        {
            Console.WriteLine("===========================");
            Console.WriteLine("Staff Members");
            Console.WriteLine("===========================");
            Console.WriteLine();

            if (staffMembers.Count == 0)
            {
                Console.WriteLine("There are no staff members.");
                return;
            }

            foreach (Staff member in staffMembers)
            {
                member.PrintDetails();
                Console.WriteLine();
            }
        }

        //Update Staff

        public void UpdateStaff()
        {
            Staff staffUpdate = null;
            
            Console.WriteLine("=========================");
            Console.WriteLine("Updating Staff Member...");
            Console.WriteLine("=========================");
            Console.WriteLine();

            if (staffMembers.Count == 0)
            {
                Console.WriteLine("There are no staff members to update.");
                return;
            }

            Console.WriteLine("Enter the Staff ID of the staff member you would like to update: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid entry.");
                return;
            }

            foreach(Staff member in staffMembers)
            {
                if (member.staffID == id)
                {
                    staffUpdate = member;
                    break;
                }
            }

            if (staffUpdate == null)
            {
                Console.WriteLine("No staff member with this ID was found.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"Updating {staffUpdate.staffName}...");
            Console.WriteLine();

            Console.WriteLine("Enter the new full name of the staff member: ");
            string newName = Console.ReadLine();
            Console.WriteLine();

            if (!string.IsNullOrEmpty(newName))
            {
                staffUpdate.UpdateName(newName);
            }


            //Driver

            if (staffUpdate is Driver driver)
            {
                Console.WriteLine($"Current license: {driver.licenseType}");
                Console.WriteLine();

                Console.WriteLine("Select a new license by entering the corresponding number: ");
                Console.WriteLine("1. Motorcycle");
                Console.WriteLine("2. Light Vehicle");
                Console.WriteLine("3. Heavy Vehicle");
                Console.WriteLine("Choice: ");

                if (int.TryParse(Console.ReadLine(), out int licenseChoice) && Enum.IsDefined(typeof(LicenseType), licenseChoice))
                {
                    driver.UpdateLicense((LicenseType)licenseChoice);
                }

                else
                {
                    Console.WriteLine("Invalid entry.");
                }
            }

            //Office

            else if (staffUpdate is OfficeStaff officeStaff)
            {
                Console.WriteLine($"Current workstation: {officeStaff.workstation}");
                Console.WriteLine();

                Console.WriteLine("Select a new workstation by entering the corresponding number: ");

                foreach (WorkstationChoices workstation in Enum.GetValues(typeof(WorkstationChoices)))
                {
                    Console.WriteLine($"{(int)workstation}. {workstation}");
                }

                Console.WriteLine("Choice: ");

                if (int.TryParse(Console.ReadLine(), out int workstationChoice) && Enum.IsDefined(typeof(WorkstationChoices), workstationChoice))
                {
                    officeStaff.UpdateWorkstation((WorkstationChoices)workstationChoice);
                }

                else
                {
                    Console.WriteLine("Invalid entry.");
                }
            }

                Console.WriteLine();
            Console.WriteLine("Staff member updated successfully!");
        }
    }
}
