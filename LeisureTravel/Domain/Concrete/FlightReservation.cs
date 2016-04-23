using System;
using System.Collections.Generic;
using LeisureTravel.Domain.Interfaces;

namespace LeisureTravel.Domain.Concrete
{
    public class FlightReservation : IFlightReservation
    {
        public Guid ReservationId { get; set; }
        public string ClientName { get; set; }
        public string Destination { get; set; }
        public string Origin { get; set; }
        public decimal? FeesPerTicket { get; set; }
        public int NumberInParty { get; set; }
        public decimal PricePerTicket { get; set; }
        public bool IsFrequentFlier { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public ICollection<Passenger> Passengers { get; set; }
    }
}