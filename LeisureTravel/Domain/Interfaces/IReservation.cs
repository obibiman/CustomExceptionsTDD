using System;

namespace LeisureTravel.Domain.Interfaces
{
    public interface IReservation
    {
         Guid ReservationId { get; set; }
         string ClientName { get; set; }
        //
        DateTime DepartureDate { get; set; }
        DateTime? ReturnDate { get; set; }
        string Destination { get; set; }
        bool IsFrequentFlier { get; set; }
        int NumberInParty { get; set; }
        string Origin { get; set; }
    }
}
