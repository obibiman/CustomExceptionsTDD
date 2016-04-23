using LeisureTravel.Domain;
using LeisureTravel.Domain.Concrete;
using LeisureTravel.Domain.Interfaces;
using LeisureTravel.Interfaces;
using LeisureTravel.Validation;

namespace LeisureTravel.Concrete
{
    public class AdventureTravel : IAdventureTravel
    {
        private readonly FlightReservationValidation _validation = new FlightReservationValidation();

        public decimal CalculateTotalReservationCost(IFlightReservation reservation)
        {
            decimal? totalPrice = 0;
            decimal? totalFees = 0;
            _validation.ValidateFlightReservation(reservation);
            _validation.ValidateFlightTicketCosts(reservation);
            _validation.ValidateFlightOriginAndDestination(reservation);
            _validation.ValidateFlightDestination(reservation);

            if (reservation.FeesPerTicket.HasValue)
            {
                totalFees = reservation.FeesPerTicket.Value*reservation.Passengers.Count;
            }
            totalPrice = reservation.PricePerTicket*reservation.Passengers.Count + totalFees;
            return (decimal) totalPrice;
        }

        public decimal CalculateTotalReservationFees(IFlightReservation reservation)
        {
            decimal? totalFees = 0;
            if (reservation.FeesPerTicket.HasValue)
            {
                totalFees = reservation.FeesPerTicket.Value*reservation.Passengers.Count;
            }
            return (decimal) totalFees;
        }
    }
}
