using System;
using System.Collections.Generic;
using LeisureTravel.Concrete;
using LeisureTravel.CustomException;
using LeisureTravel.CustomException.AutoRentalReservation;
using LeisureTravel.Domain;
using LeisureTravel.Domain.Concrete;
using LeisureTravel.Domain.Interfaces;
using LeisureTravel.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeisureTravel.Tests
{
    [TestClass]
    public class AdventureTravelTest
    {
        [TestMethod]
        public void CalculateTotalReservationCost_Returns_TotalPrice_Test()
        {
            //arrange
            IAdventureTravel at = new AdventureTravel();
            IFlightReservation res = new FlightReservation();
            res.PricePerTicket = 300m;
            res.FeesPerTicket = 39m;
            res.ClientName = "Maurice Muoneke";
            res.Destination = "Paris, France";
            res.Origin = "Austin, Texas";
            res.IsFrequentFlier = false;
            res.NumberInParty = 1;
            res.ReservationId = Guid.NewGuid();
            res.DepartureDate = DateTime.Parse("12/28/2013");
            res.ReturnDate = DateTime.Parse("01/21/2014");
            res.Passengers = new List<Passenger> {new Passenger {FirstName = "Maurice", LastName = "Muoneke", Gender = Gender.Male, Nationality = "United States"} };

            //act
            var actual = 339m;
            var expected = at.CalculateTotalReservationCost(res);

            //assert
            Assert.AreEqual(expected, actual, "Expected and actual flight reservation costs plus fees");
        }

        [TestMethod]
        public void CalculateTotalReservationFees_Returns_TotalFees_Test()
        {
            //arrange
            IAdventureTravel at = new AdventureTravel();
            IFlightReservation res = new FlightReservation();
            res.PricePerTicket = 688.43m;
            res.FeesPerTicket = 108.23m;
            res.ClientName = "Maurice Muoneke";
            res.Destination = "Paris, France";
            res.IsFrequentFlier = false;
            res.NumberInParty = 5;
            res.ReservationId = Guid.NewGuid();
            res.DepartureDate = DateTime.Parse("06/12/2016");
            res.ReturnDate = DateTime.Parse("06/21/2016");
            res.Passengers = new List<Passenger>
            {
                new Passenger { FirstName = "Maurice", LastName = "Muoneke", Gender = Gender.Male, Nationality = "United States" , DateOfBirth = DateTime.Parse("01/31/1954")} ,
                new Passenger { FirstName = "Ada", LastName = "Muoneke", Gender = Gender.Female, Nationality = "United States",DateOfBirth = DateTime.Parse("03/07/1965") },
                new Passenger { FirstName = "Evonne", LastName = "Muoneke", Gender = Gender.Female, Nationality = "United States",DateOfBirth = DateTime.Parse("09/30/1987") },
                new Passenger { FirstName = "Bryan", LastName = "Muoneke", Gender = Gender.Male, Nationality = "United States" ,DateOfBirth = DateTime.Parse("12/03/1988")},
                new Passenger { FirstName = "Michelle", LastName = "Muoneke", Gender = Gender.Female, Nationality = "United States" ,DateOfBirth = DateTime.Parse("11/02/1995")}
            };

            //act
            var actual = 541.15m;
            var expected = at.CalculateTotalReservationFees(res);

            //assert
            Assert.AreEqual(expected, actual, "Expected and actual flight reservation fees");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFlightOriginAndDestinationException), "The origin and destination cannot be thesame.")]
        public void MakeReservation_ForSameOrigin_And_Destination_Thows_Exception_Test()
        {
            //arrange
            IAdventureTravel at = new AdventureTravel();
            IFlightReservation res = new FlightReservation();
            res.PricePerTicket = 300m;
            res.FeesPerTicket = 39m;
            res.ClientName = "Maurice Muoneke";
            res.Destination = "Austin, Texas";
            res.Origin = "Austin, Texas";
            res.IsFrequentFlier = false;
            res.NumberInParty = 1;
            res.ReservationId = Guid.NewGuid();
            res.DepartureDate = DateTime.Parse("12/28/2013");
            res.ReturnDate = DateTime.Parse("01/21/2014");
            res.Passengers = new List<Passenger> { new Passenger { FirstName = "Maurice", LastName = "Muoneke", Gender = Gender.Male, Nationality = "United States" } };

            //act
            var actual = 339m;
            decimal expected;
            //assert
            expected = at.CalculateTotalReservationCost(res);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDestinatinationException), "The destination is required.")]
        public void MakeReservation_InvalidDestination_Thows_Exception_Test()
        {
            //arrange
            IAdventureTravel at = new AdventureTravel();
            IFlightReservation res = new FlightReservation();
            res.PricePerTicket = 300m;
            res.FeesPerTicket = 39m;
            res.ClientName = "Maurice Muoneke";
            res.Destination = "";
            res.Origin = "Austin, Texas";
            res.IsFrequentFlier = false;
            res.NumberInParty = 1;
            res.ReservationId = Guid.NewGuid();
            res.DepartureDate = DateTime.Parse("12/28/2013");
            res.ReturnDate = DateTime.Parse("01/21/2014");
            res.Passengers = new List<Passenger> { new Passenger { FirstName = "Maurice", LastName = "Muoneke", Gender = Gender.Male, Nationality = "United States" } };

            //act
            var actual = 339m;
            decimal expected;
            //assert
            expected = at.CalculateTotalReservationCost(res);
        }

        [TestMethod]
        [ExpectedException(typeof(TicketCostException), "The ticket price must be positive.")]
        public void MakeReservation_InvalidTicketCost_Thows_Exception_Test()
        {
            //arrange
            IAdventureTravel at = new AdventureTravel();
            IFlightReservation res = new FlightReservation();
            res.PricePerTicket = -300m;
            res.FeesPerTicket = 39m;
            res.ClientName = "Maurice Muoneke";
            res.Destination = "Paris, France";
            res.Origin = "Austin, Texas";
            res.IsFrequentFlier = false;
            res.NumberInParty = 1;
            res.ReservationId = Guid.NewGuid();
            res.DepartureDate = DateTime.Parse("12/28/2013");
            res.ReturnDate = DateTime.Parse("01/21/2014");
            res.Passengers = new List<Passenger> { new Passenger { FirstName = "Maurice", LastName = "Muoneke", Gender = Gender.Male, Nationality = "United States" } };

            //act
            var actual = 339m;
            decimal expected;
            //assert
            expected = at.CalculateTotalReservationCost(res);
        }
    }
}
