using LeisureTravel.Domain.Concrete;
using LeisureTravel.Domain.Interfaces;

namespace LeisureTravel.Interfaces
{
    public interface IAdventureAutoRental
    {
        decimal CalculateTotalAutoReservationCost(IAutoRentalReservation reservation);
        decimal CalculateTotalReservationFees(IAutoRentalReservation reservation);
    }
}