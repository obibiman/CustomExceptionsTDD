using System;
using LeisureTravel.CustomException;
using LeisureTravel.CustomException.AutoRentalReservation;
using LeisureTravel.Domain;
using LeisureTravel.Domain.Concrete;
using LeisureTravel.Domain.Interfaces;

namespace LeisureTravel.Validation
{
    public class AutoRentalReservationValidation
    {
        public void ValidateAutoRentalDestination(IAutoRentalReservation reservation)
        {
            var destination = reservation.Destination;
            if (string.IsNullOrWhiteSpace(destination))
            {
                throw new InvalidDestinatinationException();
            }
        }

        public void ValidateAutoRentalOriginAndDestination(IAutoRentalReservation reservation)
        {
            var destination = reservation.Destination;
            var origin = reservation.Origin;
            if ((!string.IsNullOrWhiteSpace(destination) || !string.IsNullOrWhiteSpace(origin)) && (string.Compare(origin, destination, StringComparison.OrdinalIgnoreCase) == 0))
            {
                throw new InvalidAutoRentalOriginAndDestinationException();
            }
        }

        //

        public void ValidateAutoRentalFees(IAutoRentalReservation reservation)
        {
            var pricePerDay = reservation.PricePerDay;
            if (pricePerDay < 0)
            {
                throw new AutoRentalCostException();
            }
        }
  
        public void ValidateAutoRentalUnlicensedDriver(IAutoRentalReservation reservation)
        {
            foreach (var driver in reservation.Drivers)
            {
                if (driver.DriversLicense == null)
                {
                    throw new AutoRentalUnlicensedDriverException();
                }
            }
        }

        public void ValidateAutoRentalUninsuredDriver(IAutoRentalReservation reservation)
        {
            var autoInsurance = reservation.AutoInsurance;
            if (autoInsurance == null )
            {
                throw new AutoRentalUninsuredDriverException();
            }
        }

        public void ValidateAutoRentalDriversLicenseExpiry(IAutoRentalReservation reservation)
        {
            var drivers = reservation.Drivers;
            foreach (var driver in drivers)
            {
                if (driver.DriversLicense.Expiration < DateTime.Now)
                {
                    throw new AutoRentalExpiredLicenseException();
                }
            }
        }

        public void ValidateAutoRentalInsuranceExpiry(IAutoRentalReservation reservation)
        {
            var insurance = reservation.AutoInsurance;
            if (insurance.Expiration < DateTime.Now)
            {
                throw new AutoRentalExpiredInsuranceException();
            }
        }

        public void ValidateAutoRentalTotalCosts(IAutoRentalReservation reservation)
        {
            var pricePerDay = reservation.PricePerDay;
            if (pricePerDay < 0)
            {
                throw new AutoRentalCostException();
            }
        }

        public void ValidateAutoRentalReservation(IAutoRentalReservation reservation)
        {
            var departureDate = reservation.DepartureDate;
            var returnDate = reservation.ReturnDate;
            if (returnDate.HasValue)
            {
                if (departureDate > returnDate.Value)
                {
                    throw new DateRangeException();
                }
            }
        }
    }
}