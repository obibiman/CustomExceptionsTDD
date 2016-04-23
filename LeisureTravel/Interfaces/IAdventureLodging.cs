using LeisureTravel.Domain.Concrete;
using LeisureTravel.Domain.Interfaces;

namespace LeisureTravel.Interfaces
{
    public interface IAdventureLodging
    {
        decimal CalculateTotalLodgingCost(ILodgingReservation reservation);
        decimal CalculateTotalLodgingFees(ILodgingReservation reservation);
    }
}