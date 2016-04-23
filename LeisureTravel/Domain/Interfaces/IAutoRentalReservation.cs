using System;
using System.Collections.Generic;

namespace LeisureTravel.Domain.Interfaces
{
    public interface IAutoRentalReservation : IReservation
    {
        AutoInsurance AutoInsurance { get; set; }
        ICollection<Driver> Drivers { get; set; }
        DriversLicense DriversLicense { get; set; }
        DateTime DropOffDate { get; set; }
        string DropOffLocation { get; set; }
        DateTime PickUpDate { get; set; }
        string PickUpLocation { get; set; }
        decimal PricePerDay { get; set; }
        Category VehicleCategory { get; set; }
    }
}