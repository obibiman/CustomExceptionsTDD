using System;

namespace LeisureTravel.Domain
{
    public class Driver
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DriversLicense DriversLicense { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsInsured { get; set; }
    }
}