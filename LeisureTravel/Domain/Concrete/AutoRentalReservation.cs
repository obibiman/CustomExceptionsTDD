using System;
using System.Collections.Generic;
using LeisureTravel.Domain.Interfaces;

namespace LeisureTravel.Domain.Concrete
{
    public class AutoRentalReservation : IAutoRentalReservation
    {
        public Guid ReservationId { get; set; }
        public Category VehicleCategory { get; set; }
        public string ClientName { get; set; }
        public string Destination { get; set; }
        public string Origin { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public int NumberInParty { get; set; }
        public decimal PricePerDay { get; set; }
        public bool IsFrequentFlier { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public AutoInsurance AutoInsurance { get; set; }
        public DriversLicense DriversLicense { get; set; }
        public ICollection<Driver> Drivers { get; set; }
    }
}