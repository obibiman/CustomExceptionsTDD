using System;
using LeisureTravel.CustomException;
using LeisureTravel.CustomException.AutoRentalReservation;
using LeisureTravel.Domain;
using LeisureTravel.Domain.Concrete;
using LeisureTravel.Domain.Interfaces;

namespace LeisureTravel.Validation
{
    public class FlightReservationValidation
    {
        public void ValidateFlightDestination(IFlightReservation reservation)
        {
            var destination = reservation.Destination;
            if (string.IsNullOrWhiteSpace(destination))
            {
                throw new InvalidDestinatinationException();
            }
        }

        public void ValidateFlightOriginAndDestination(IFlightReservation reservation)
        {
            var destination = reservation.Destination;
            var origin = reservation.Origin;
            if ((!string.IsNullOrWhiteSpace(destination) || !string.IsNullOrWhiteSpace(origin)) && (string.Compare(origin, destination, StringComparison.OrdinalIgnoreCase) == 0))
            {
                throw new InvalidFlightOriginAndDestinationException();
            }
        }

        public void ValidateFlightTicketCosts(IFlightReservation reservation)
        {
            var ticketCost = reservation.PricePerTicket;
            if (ticketCost < 0)
            {
                throw new TicketCostException();
            }
        }

        public void ValidateFlightReservation(IFlightReservation reservation)
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