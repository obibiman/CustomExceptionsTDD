using System;
using System.Collections.Generic;
using LeisureTravel.Concrete;
using LeisureTravel.CustomException.LodgingReservation;
using LeisureTravel.Domain;
using LeisureTravel.Domain.Concrete;
using LeisureTravel.Domain.Interfaces;
using LeisureTravel.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LeisureTravel.Tests
{
    [TestClass]
    public class AdventureLodgingTest
    {
        [TestMethod]
        public void CalculateTotalLodgingCost_Returns_TotalPrice_Test()
        {
            //arrange
            IAdventureLodging al = new AdventureLodging();
            ILodgingReservation lres = new LodgingReservation();
            lres.ClientName = "Maurice Muoneke";
            lres.PricePerPerson = 300m;
            lres.FeesPerPerson = 39m;
            lres.Destination = "Paris, France";
            lres.Origin = "Austin, Texas";
            lres.IsFrequentFlier = false;
            lres.NumberInParty = 1;
            lres.ReservationId = Guid.NewGuid();
            lres.DepartureDate = DateTime.Parse("12/28/2013");
            lres.ReturnDate = DateTime.Parse("01/21/2014");
            lres.Occupants = new List<HotelOccupant> { new HotelOccupant { FirstName = "Maurice", LastName = "Muoneke", Gender = Gender.Male, Nationality = "United States", MiddleName = "I", DateOfBirth = DateTime.Parse("12/17/2011") } };

            //act
            var actual = 339m;
            var expected = al.CalculateTotalLodgingCost(lres);

            //assert
            //Assert.AreEqual(expected, actual, "Expected and actual lodging reservation costs plus fees");
        }

        [TestMethod]
        public void CalculateTotalLodgingCost_Returns_TotalPrice_Test_Moq()
        {
            //arrange
            IAdventureLodging mal = new AdventureLodging();
            var mres = new Mock<ILodgingReservation>(MockBehavior.Strict);
            mres.Setup(m => m.FeesPerPerson).Returns(39m);
            mres.Setup(m => m.ClientName).Returns("Maurice Muoneke");
            mres.Setup(m => m.PricePerPerson).Returns(300m);
            mres.Setup(m => m.Destination).Returns("Paris, France");
            mres.Setup(m => m.Origin).Returns("Austin, Texas");
            mres.Setup(m => m.IsFrequentFlier).Returns(false);
            mres.Setup(m => m.NumberInParty).Returns(1);
            mres.Setup(m => m.ReservationId).Returns(Guid.NewGuid);
            mres.Setup(m => m.DepartureDate).Returns(DateTime.Parse("12/28/2013"));
            mres.Setup(m => m.ReturnDate).Returns(DateTime.Parse("01/21/2014"));
           
            var occupants = new List<HotelOccupant> { new HotelOccupant { FirstName = "Maurice", LastName = "Muoneke", Gender = Gender.Male, Nationality = "United States", MiddleName = "I", DateOfBirth = DateTime.Parse("12/17/2011") } };
            mres.Setup(m => m.Occupants).Returns(() => occupants);
            //mres.Setup(m => m.Occupants).Returns(() => { return occupants; });

            //act
            var actual = 339m;

            var exp = mal.CalculateTotalLodgingCost(mres.Object);
            //assert
            //mres.Verify(y=>y.FeesPerPerson, Times.Once);
            //mres.Verify(y => y.ClientName, Times.Once);
            //mres.Verify(y => y.PricePerPerson, Times.Once);
            //mres.Verify(y => y.Destination, Times.Once);
            //mres.Verify(y => y.Origin, Times.Once);
            //mres.Verify(y => y.IsFrequentFlier, Times.Once);
            //mres.Verify(y => y.NumberOfRooms, Times.Once);
            //mres.Verify(y => y.NumberInParty, Times.Once);
            //mres.Verify(y => y.ReservationId, Times.Once);
            //mres.Verify(y => y.DepartureDate, Times.Once);
            //mres.Verify(y => y.Occupants, Times.Once);
            Assert.AreEqual(exp, actual, "Expected and actual lodging reservation costs plus fees");
        }

        [TestMethod]
        public void CalculateTotalLodging_Fees_Returns_TotalFees_Test()
        {
            //arrange
            IAdventureLodging al = new AdventureLodging();
            ILodgingReservation lres = new LodgingReservation();
            lres.ClientName = "Maurice Muoneke";
            lres.PricePerPerson = 300m;
            lres.FeesPerPerson = 39.95m;
            lres.Destination = "Paris, France";
            lres.Origin = "Austin, Texas";
            lres.IsFrequentFlier = false;
            lres.NumberInParty = 1;
            lres.ReservationId = Guid.NewGuid();
            lres.DepartureDate = DateTime.Parse("12/28/2013");
            lres.ReturnDate = DateTime.Parse("01/21/2014");
            lres.Occupants = new List<HotelOccupant> {
                new HotelOccupant { FirstName = "Maurice", LastName = "Muoneke", Gender = Gender.Male, Nationality = "United States", MiddleName = "I", DateOfBirth = DateTime.Parse("12/17/2011") },
                new HotelOccupant { FirstName = "Ada", LastName = "Muoneke", Gender = Gender.Female, Nationality = "United States", MiddleName = "I", DateOfBirth = DateTime.Parse("12/17/2011") },
                new HotelOccupant { FirstName = "Evonne", LastName = "Muoneke", Gender = Gender.Female, Nationality = "United States", MiddleName = "I", DateOfBirth = DateTime.Parse("12/17/2011") },
                new HotelOccupant { FirstName = "Bryan", LastName = "Muoneke", Gender = Gender.Male, Nationality = "United States", MiddleName = "I", DateOfBirth = DateTime.Parse("12/17/2011") },
                new HotelOccupant { FirstName = "Michelle", LastName = "Muoneke", Gender = Gender.Female, Nationality = "United States", MiddleName = "I", DateOfBirth = DateTime.Parse("12/17/2011") }
            };

            //act
            var actual = 199.75m;
            var expected = al.CalculateTotalLodgingFees(lres);

            //assert
            //Assert.AreEqual(expected, actual, "Expected and actual lodging reservation plus fees");
        }

        [TestMethod]
        [ExpectedException(typeof(NoVacancyException), "No vacancy available.")]
        public void CalculateTotalLodgingFees_NoVacancyAvailable_Throws_Exception_Test()
        {
            //arrange
            IAdventureLodging al = new AdventureLodging();
            ILodgingReservation lres = new LodgingReservation();
            lres.ClientName = "Maurice Muoneke";
            lres.PricePerPerson = 300m;
            lres.FeesPerPerson = 39.95m;
            lres.Destination = "Paris, France";
            lres.Origin = "Austin, Texas";
            lres.IsFrequentFlier = false;
            lres.NumberInParty = 1;
            lres.ReservationId = Guid.NewGuid();
            lres.DepartureDate = DateTime.Parse("12/28/2013");
            lres.ReturnDate = DateTime.Parse("01/21/2014");
            lres.Occupants = new List<HotelOccupant> {
                new HotelOccupant { FirstName = "Maurice", LastName = "Muoneke", Gender = Gender.Male, Nationality = "United States", MiddleName = "I", DateOfBirth = DateTime.Parse("12/17/2011") },
                new HotelOccupant { FirstName = "Ada", LastName = "Muoneke", Gender = Gender.Female, Nationality = "United States", MiddleName = "I", DateOfBirth = DateTime.Parse("12/17/2011") },
                new HotelOccupant { FirstName = "Evonne", LastName = "Muoneke", Gender = Gender.Female, Nationality = "United States", MiddleName = "I", DateOfBirth = DateTime.Parse("12/17/2011") },
                new HotelOccupant { FirstName = "Bryan", LastName = "Muoneke", Gender = Gender.Male, Nationality = "United States", MiddleName = "I", DateOfBirth = DateTime.Parse("12/17/2011") },
                new HotelOccupant { FirstName = "Michelle", LastName = "Muoneke", Gender = Gender.Female, Nationality = "United States", MiddleName = "I", DateOfBirth = DateTime.Parse("12/17/2011") },
                new HotelOccupant { FirstName = "Ozioma", LastName = "Muoneke", Gender = Gender.Female, Nationality = "Nigerian", MiddleName = "I", DateOfBirth = DateTime.Parse("12/17/2009") },
                new HotelOccupant { FirstName = "Chizuru", LastName = "Muoneke", Gender = Gender.Female, Nationality = "Nigerian", MiddleName = "I", DateOfBirth = DateTime.Parse("12/17/2006") }
            };

            //act
            var actual = 279.65m;
            var expected = al.CalculateTotalLodgingFees(lres);

            //assert
            //Assert.AreEqual(expected, actual, "Expected and actual lodging reservation plus fees");
        }
    }
}
