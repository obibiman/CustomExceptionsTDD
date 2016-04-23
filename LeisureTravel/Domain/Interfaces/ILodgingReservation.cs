using System;
using System.Collections.Generic;

namespace LeisureTravel.Domain.Interfaces
{
    public interface ILodgingReservation: IReservation
    {
        decimal? FeesPerPerson { get; set; }
        int NumberOfRooms { get; set; }
        ICollection<HotelOccupant> Occupants { get; set; }
        decimal PricePerPerson { get; set; }
    }
}