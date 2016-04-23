using LeisureTravel.Domain;
using LeisureTravel.Domain.Concrete;
using LeisureTravel.Domain.Interfaces;

namespace LeisureTravel.Interfaces
{
    public interface IAdventureTravel
    {
        decimal CalculateTotalReservationCost(IFlightReservation reservation);
        decimal CalculateTotalReservationFees(IFlightReservation reservation);
    }
}