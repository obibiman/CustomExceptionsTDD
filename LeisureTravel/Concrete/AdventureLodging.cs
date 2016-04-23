using System;
using System.Globalization;
using LeisureTravel.Domain.Concrete;
using LeisureTravel.Domain.Interfaces;
using LeisureTravel.Interfaces;
using LeisureTravel.Validation;

namespace LeisureTravel.Concrete
{
    public class AdventureLodging : IAdventureLodging
    {
        private readonly LodgingReservationValidation _validation = new LodgingReservationValidation();

        public decimal CalculateTotalLodgingCost(ILodgingReservation reservation)
        {
            decimal? totalPrice = 0;
            decimal? totalFees = 0;
            _validation.ValidateLodgingReservation(reservation);
            _validation.ValidateLodgingCosts(reservation);
            _validation.ValidateLodgingDestination(reservation);
            _validation.ValidateLodgingVacancy(reservation);


            if (reservation.FeesPerPerson.HasValue)
            {
                var ageDiscountEligible = GetAgeDiscountEligibility(reservation);
                totalFees = reservation.FeesPerPerson.Value * reservation.Occupants.Count;
                var adjustedFees = reservation.FeesPerPerson.Value * ageDiscountEligible;
            }
            totalPrice = reservation.PricePerPerson * reservation.Occupants.Count + totalFees;
            return (decimal)totalPrice;
        }

        public decimal CalculateTotalLodgingFees(ILodgingReservation reservation)
        {
            decimal? totalFees = 0;
            _validation.ValidateLodgingReservation(reservation);
            _validation.ValidateLodgingCosts(reservation);
            _validation.ValidateLodgingDestination(reservation);
            _validation.ValidateLodgingVacancy(reservation);
            if (reservation.FeesPerPerson.HasValue)
            {
                var ageDiscountEligible = GetAgeDiscountEligibility(reservation);
                totalFees = reservation.FeesPerPerson.Value * reservation.Occupants.Count;
                var adjustedFees = reservation.FeesPerPerson.Value * ageDiscountEligible;
            }
            return (decimal)totalFees;
        }

        public int GetAgeDiscountEligibility(ILodgingReservation reservation)
        {
            int? numberOfPayingAge = 0;
            foreach (var hotelOccupant in reservation.Occupants)
            {
                TimeSpan span = (DateTime.Now - hotelOccupant.DateOfBirth);
                int ageInYears = (int) (span.Days/365.25);
                if (ageInYears > 5)
                    numberOfPayingAge = numberOfPayingAge + 1;
            }
            return numberOfPayingAge.Value;
        }
    }
}