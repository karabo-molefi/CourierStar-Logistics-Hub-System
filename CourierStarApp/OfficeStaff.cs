using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CourierStarApp
{
    internal class OfficeStaff : Staff, IPrintable
    {
        public string officeIDModifier;
        public WorkstationChoices workstation;

        //Constructor
        public OfficeStaff(string sName, string div, WorkstationChoices workstation) : base(sName, div)
        {
            this.workstation = workstation;
            GenerateIDModifier();
            fullStaffID = $"{officeIDModifier}{staffID}";
        }

        public virtual void PrintDetails()
        {
            Console.WriteLine("================================");
            Console.WriteLine($"Office Staff Details: ");
            Console.WriteLine("================================");
            Console.WriteLine();
            Console.WriteLine($"Staff ID: {fullStaffID} \nName: {staffName} \nWork Area: {workstation}");
        }

        public void UpdateWorkstation(WorkstationChoices newWorkstation)
        {
            workstation = newWorkstation;
            GenerateIDModifier();
            fullStaffID = $"{officeIDModifier}{staffID}";
        }

        public override void GenerateIDModifier()
        {

            switch (workstation)
            {
                case WorkstationChoices.Reception:
                    officeIDModifier = "OWR";
                    break;

                case WorkstationChoices.Sales:
                    officeIDModifier = "OWS";
                    break;

                case WorkstationChoices.Maintenance:
                    officeIDModifier = "OWM";
                    break;

                case WorkstationChoices.Administration:
                    officeIDModifier = "OWA";
                    break;

                case WorkstationChoices.Customer_Service:
                    officeIDModifier = "OWC";
                    break;

                case WorkstationChoices.Logistics:
                    officeIDModifier = "OWL";
                    break;

                case WorkstationChoices.Data:
                    officeIDModifier = "OWD";
                    break;

                default:
                    Console.WriteLine("Invalid entry. Please enter a valid value.");
                    break;

            }

        }

    }

    public enum WorkstationChoices
    {
        Reception = 1,
        Sales = 2,
        Maintenance = 3,
        Administration = 4,
        Customer_Service = 5,
        Logistics = 6,
        Data = 7
    }
}
