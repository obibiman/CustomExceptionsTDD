using LeisureTravel.CustomException;
using LeisureTravel.CustomException.AutoRentalReservation;
using LeisureTravel.CustomException.LodgingReservation;
using LeisureTravel.Domain;
using LeisureTravel.Domain.Concrete;
using LeisureTravel.Domain.Interfaces;

namespace LeisureTravel.Validation
{
    public class LodgingReservationValidation
    {
        public void ValidateLodgingDestination(ILodgingReservation reservation)
        {
            var destination = reservation.Destination;
            if (string.IsNullOrWhiteSpace(destination))
            {
                throw new InvalidDestinatinationException();
            }
        }

        public void ValidateLodgingCosts(ILodgingReservation reservation)
        {
            var pricePerPerson = reservation.PricePerPerson;
            if (pricePerPerson < 0)
            {
                throw new LodgingCostException();
            }
        }

        public void ValidateLodgingReservation(ILodgingReservation reservation)
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

        public void ValidateLodgingVacancy(ILodgingReservation reservation)
        {
            var numberInParty = reservation.Occupants.Count;
            var vacancy = new LodgingVacancy();
            if (!vacancy.HasVacancy(numberInParty))
            {
                throw new NoVacancyException();
            }
        }
    }
}