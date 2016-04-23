using System;

namespace LeisureTravel.Domain
{
    public class DriversLicense
    {
        public string LicenseId { get; set; }
        public string State { get; set; }
        public DateTime Expiration { get; set; }
    }
}