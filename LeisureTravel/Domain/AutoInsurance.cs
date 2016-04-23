using System;

namespace LeisureTravel.Domain
{
    public class AutoInsurance
    {
        public string PolicyId { get; set; }
        public string Insurer { get; set; }
        public DateTime Expiration { get; set; }
    }
}