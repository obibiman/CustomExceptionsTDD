using System;
using System.Collections.Generic;
using LeisureTravel.Domain.Interfaces;

namespace LeisureTravel.Domain.Concrete
{
    public class LodgingReservation : ILodgingReservation
    {
        public Guid ReservationId { get; set; }
        public string ClientName { get; set; }
        public string Destination { get; set; }
        public string Origin { get; set; }
        public int NumberInParty { get; set; }
        public decimal PricePerPerson { get; set; }
        public decimal? FeesPerPerson { get; set; }
        public bool IsFrequentFlier { get; set; }
        public int NumberOfRooms { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public ICollection<HotelOccupant> Occupants { get; set; }
    }
}