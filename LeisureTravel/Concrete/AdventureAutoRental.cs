using LeisureTravel.Domain.Concrete;
using LeisureTravel.Domain.Interfaces;
using LeisureTravel.Interfaces;
using LeisureTravel.Validation;

namespace LeisureTravel.Concrete
{
    public class AdventureAutoRental : IAdventureAutoRental
    {
        private readonly AutoRentalReservationValidation _validation = new AutoRentalReservationValidation();

        public decimal CalculateTotalAutoReservationCost(IAutoRentalReservation reservation)
        {
            decimal? totalPrice = 0;
            decimal? totalFees = 0;
            _validation.ValidateAutoRentalReservation(reservation);
            _validation.ValidateAutoRentalTotalCosts(reservation);
            _validation.ValidateAutoRentalOriginAndDestination(reservation);
            _validation.ValidateAutoRentalDestination(reservation);

            _validation.ValidateAutoRentalFees(reservation);
            _validation.ValidateAutoRentalUnlicensedDriver(reservation);

            _validation.ValidateAutoRentalUninsuredDriver(reservation);
            _validation.ValidateAutoRentalDriversLicenseExpiry(reservation);
            _validation.ValidateAutoRentalInsuranceExpiry(reservation);

            var rentalDuration = (reservation.DropOffDate - reservation.PickUpDate).Days > 0 ? (reservation.DropOffDate - reservation.PickUpDate).Days : 1;
            totalPrice = reservation.PricePerDay*rentalDuration;

            return (decimal)totalPrice;
        }

        public decimal CalculateTotalReservationFees(IAutoRentalReservation reservation)
        {
            decimal? totalFees = 0;
            _validation.ValidateAutoRentalReservation(reservation);
            _validation.ValidateAutoRentalTotalCosts(reservation);
            _validation.ValidateAutoRentalOriginAndDestination(reservation);
            _validation.ValidateAutoRentalDestination(reservation);

            _validation.ValidateAutoRentalFees(reservation);
            _validation.ValidateAutoRentalUnlicensedDriver(reservation);

            _validation.ValidateAutoRentalUninsuredDriver(reservation);
            _validation.ValidateAutoRentalDriversLicenseExpiry(reservation);
            _validation.ValidateAutoRentalInsuranceExpiry(reservation);

            totalFees = reservation.PricePerDay * (reservation.DropOffDate-reservation.PickUpDate).Days > 0 ? (reservation.DropOffDate - reservation.PickUpDate).Days : 1;
            return (decimal)totalFees;
        }
    }
}