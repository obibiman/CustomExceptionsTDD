using System;
using System.Collections.Generic;

namespace LeisureTravel.Domain.Interfaces
{
    public interface IFlightReservation : IReservation
    {
        decimal? FeesPerTicket { get; set; }
        ICollection<Passenger> Passengers { get; set; }
        decimal PricePerTicket { get; set; }
    }
}