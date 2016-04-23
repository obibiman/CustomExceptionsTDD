using System;
using System.Collections.Generic;
using LeisureTravel.Concrete;
using LeisureTravel.CustomException.AutoRentalReservation;
using LeisureTravel.Domain;
using LeisureTravel.Domain.Concrete;
using LeisureTravel.Domain.Interfaces;
using LeisureTravel.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeisureTravel.Tests
{
    [TestClass]
    public class AdventureAutoRentalTest
    {
        private IAdventureAutoRental al;
        private IAutoRentalReservation lres;

        /// <summary>
        ///     Gets or sets the test context which provides
        ///     information about and functionality for the
        ///     current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        ///     Initialize() is called once during test execution before
        ///     test methods in this test class are executed.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            //  TODO: Add test initialization code
            al = new AdventureAutoRental();
            lres = new AutoRentalReservation();
        }

        /// <summary>
        ///     Cleanup() is called once during test execution after
        ///     test methods in this class have executed unless
        ///     this test class' Initialize() method throws an exception.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            al = null;
            lres = null;
        }

        [TestMethod]
        public void CalculateTotalAutoRentalCost_Returns_TotalCost_Test()
        {
            //arrange
            //IAdventureAutoRental al = new AdventureAutoRental();
            //IAutoRentalReservation lres = new AutoRentalReservation();
            lres.ClientName = "Maurice Muoneke";
            lres.PricePerDay = 67.99m;
            lres.AutoInsurance = new AutoInsurance
            {
                PolicyId = Guid.NewGuid().ToString(),
                Expiration = DateTime.Parse("11/03/2017"),
                Insurer = "Maurice Muoneke"
            };
            lres.DriversLicense = new DriversLicense
            {
                LicenseId = Guid.NewGuid().ToString(),
                Expiration = DateTime.Parse("11/03/2017"),
                State = "Texas"
            };
            lres.Destination = "Paris, France";
            lres.Origin = "Austin, Texas";
            lres.PickUpDate = DateTime.Parse("06/14/2016");
            lres.DropOffDate = DateTime.Parse("06/20/2016");
            lres.PickUpLocation = "Austin, Texas";
            lres.DropOffLocation = "Tampa, Florida";
            lres.IsFrequentFlier = false;
            lres.NumberInParty = 1;
            lres.ReservationId = Guid.NewGuid();
            lres.DepartureDate = DateTime.Parse("06/14/2016");
            lres.ReturnDate = DateTime.Parse("06/20/2016");

            lres.Drivers = new List<Driver>
            {
                new Driver
                {
                    FirstName = "Kenneth",
                    LastName = "Du Bose",
                    IsInsured = true,
                    MiddleName = "K",
                    DateOfBirth = DateTime.Parse("12/12/1972"),
                    DriversLicense =
                        new DriversLicense
                        {
                            LicenseId = Guid.NewGuid().ToString(),
                            Expiration = DateTime.Parse("11/03/2017"),
                            State = "Texas"
                        }
                }
            };

            //act
            var actual = 407.94m;
            var expected = al.CalculateTotalAutoReservationCost(lres);

            //assert
            Assert.AreEqual(expected, actual, "Expected and actual auto reservation costs plus fees");
        }

        [TestMethod]
        [ExpectedException(typeof (AutoRentalExpiredLicenseException), "The drivers license has expired.")]
        public void CalculateTotalAutoRentalCost_WithExpiredDriversLicense_Throws_Exception_Test()
        {
            //arrange
            //IAdventureAutoRental al = new AdventureAutoRental();
            //IAutoRentalReservation lres = new AutoRentalReservation();
            lres.ClientName = "Maurice Muoneke";
            lres.PricePerDay = 67.99m;
            lres.AutoInsurance = new AutoInsurance
            {
                PolicyId = Guid.NewGuid().ToString(),
                Expiration = DateTime.Parse("11/03/2017"),
                Insurer = "Maurice Muoneke"
            };
            lres.DriversLicense = new DriversLicense
            {
                LicenseId = Guid.NewGuid().ToString(),
                Expiration = DateTime.Parse("11/03/2015"),
                State = "Texas"
            };
            lres.Destination = "Paris, France";
            lres.Origin = "Austin, Texas";
            lres.PickUpDate = DateTime.Parse("06/14/2016");
            lres.DropOffDate = DateTime.Parse("06/20/2016");
            lres.PickUpLocation = "Austin, Texas";
            lres.DropOffLocation = "Tampa, Florida";
            lres.IsFrequentFlier = false;
            lres.NumberInParty = 1;
            lres.ReservationId = Guid.NewGuid();
            lres.DepartureDate = DateTime.Parse("06/14/2016");
            lres.ReturnDate = DateTime.Parse("06/20/2016");

            lres.Drivers = new List<Driver>
            {
                new Driver
                {
                    FirstName = "Kenneth",
                    LastName = "Du Bose",
                    IsInsured = true,
                    MiddleName = "K",
                    DateOfBirth = DateTime.Parse("12/12/1972"),
                    DriversLicense =
                        new DriversLicense
                        {
                            LicenseId = Guid.NewGuid().ToString(),
                            Expiration = DateTime.Parse("11/03/2015"),
                            State = "Texas"
                        }
                }
            };

            //act
            //var actual = 407.94m;
            decimal expected;

            //assert
            expected = al.CalculateTotalAutoReservationCost(lres);
        }

        [TestMethod]
        [ExpectedException(typeof (AutoRentalExpiredInsuranceException), "The auto insurance has expired.")]
        public void CalculateTotalAutoRentalCost_WithExpiredAutoInsurance_Throws_Exception_Test()
        {
            //arrange
            //IAdventureAutoRental al = new AdventureAutoRental();
            //IAutoRentalReservation lres = new AutoRentalReservation();
            lres.ClientName = "Maurice Muoneke";
            lres.PricePerDay = 67.99m;
            //test for expired insurance policy
            lres.AutoInsurance = new AutoInsurance
            {
                PolicyId = Guid.NewGuid().ToString(),
                Expiration = DateTime.Parse("11/03/2011"),
                Insurer = "Maurice Muoneke"
            };
            lres.DriversLicense = new DriversLicense
            {
                LicenseId = Guid.NewGuid().ToString(),
                Expiration = DateTime.Parse("11/03/2016"),
                State = "Texas"
            };
            lres.Destination = "Paris, France";
            lres.Origin = "Austin, Texas";
            lres.PickUpDate = DateTime.Parse("06/14/2016");
            lres.DropOffDate = DateTime.Parse("06/20/2016");
            lres.PickUpLocation = "Austin, Texas";
            lres.DropOffLocation = "Tampa, Florida";
            lres.IsFrequentFlier = false;
            lres.NumberInParty = 1;
            lres.ReservationId = Guid.NewGuid();
            lres.DepartureDate = DateTime.Parse("06/14/2016");
            lres.ReturnDate = DateTime.Parse("06/20/2016");

            lres.Drivers = new List<Driver>
            {
                new Driver
                {
                    FirstName = "Kenneth",
                    LastName = "Du Bose",
                    IsInsured = true,
                    MiddleName = "K",
                    DateOfBirth = DateTime.Parse("12/12/1972"),
                    DriversLicense =
                        new DriversLicense
                        {
                            LicenseId = Guid.NewGuid().ToString(),
                            Expiration = DateTime.Parse("11/03/2016"),
                            State = "Texas"
                        }
                }
            };

            //act
            //var actual = 407.94m;
            decimal expected;

            //assert
            expected = al.CalculateTotalAutoReservationCost(lres);
        }

        [TestMethod]
        [ExpectedException(typeof (AutoRentalUnlicensedDriverException), "Unlicensed driver exception.")]
        public void CalculateTotalAutoRentalCost_WithUnlicensedDriver_Throws_Exception_Test()
        {
            //arrange
            //IAdventureAutoRental al = new AdventureAutoRental();
            //IAutoRentalReservation lres = new AutoRentalReservation();
            lres.ClientName = "Maurice Muoneke";
            lres.PricePerDay = 67.99m;
            lres.AutoInsurance = new AutoInsurance
            {
                PolicyId = Guid.NewGuid().ToString(),
                Expiration = DateTime.Parse("11/03/2017"),
                Insurer = "Maurice Muoneke"
            };
            lres.DriversLicense = new DriversLicense
            {
                LicenseId = Guid.NewGuid().ToString(),
                Expiration = DateTime.Parse("11/03/2016"),
                State = "Texas"
            };
            lres.Destination = "Paris, France";
            lres.Origin = "Austin, Texas";
            lres.PickUpDate = DateTime.Parse("06/14/2016");
            lres.DropOffDate = DateTime.Parse("06/20/2016");
            lres.PickUpLocation = "Austin, Texas";
            lres.DropOffLocation = "Tampa, Florida";
            lres.IsFrequentFlier = false;
            lres.NumberInParty = 1;
            lres.ReservationId = Guid.NewGuid();
            lres.DepartureDate = DateTime.Parse("06/14/2016");
            lres.ReturnDate = DateTime.Parse("06/20/2016");

            lres.Drivers = new List<Driver>
            {
                new Driver
                {
                    FirstName = "Kenneth",
                    LastName = "Du Bose",
                    IsInsured = true,
                    MiddleName = "K",
                    DateOfBirth = DateTime.Parse("12/12/1972"),
                    DriversLicense =
                        new DriversLicense
                        {
                            LicenseId = Guid.NewGuid().ToString(),
                            Expiration = DateTime.Parse("11/03/2016"),
                            State = "Texas"
                        }
                },
                new Driver
                {
                    FirstName = "Peter",
                    LastName = "Drumpf",
                    IsInsured = true,
                    MiddleName = "K",
                    DateOfBirth = DateTime.Parse("12/12/1972"),
                    DriversLicense =
                        new DriversLicense
                        {
                            LicenseId = Guid.NewGuid().ToString(),
                            Expiration = DateTime.Parse("12/23/2014"),
                            State = "Oklahoma"
                        }
                },
                new Driver
                {
                    FirstName = "Mary",
                    LastName = "Bowen",
                    IsInsured = false,
                    MiddleName = "K",
                    DateOfBirth = DateTime.Parse("12/12/1972"),
                    DriversLicense = null
                },
                new Driver
                {
                    FirstName = "Emily",
                    LastName = "Sandifer",
                    IsInsured = true,
                    MiddleName = "K",
                    DateOfBirth = DateTime.Parse("12/12/1972"),
                    DriversLicense =
                        new DriversLicense
                        {
                            LicenseId = Guid.NewGuid().ToString(),
                            Expiration = DateTime.Parse("12/23/2017"),
                            State = "Oklahoma"
                        }
                }
            };

            //act
            var actual = 407.94m;
            decimal expected;

            //assert
            expected = al.CalculateTotalAutoReservationCost(lres);
        }


        [TestMethod]
        [ExpectedException(typeof (AutoRentalUninsuredDriverException), "Uninsured driver exception.")]
        public void CalculateTotalAutoRentalCost_WithUnInsuredDriver_Throws_Exception_Test()
        {
            //arrange
            //IAdventureAutoRental al = new AdventureAutoRental();
            //IAutoRentalReservation lres = new AutoRentalReservation();
            lres.ClientName = "Maurice Muoneke";
            lres.PricePerDay = 67.99m;
            lres.AutoInsurance = null; //test for no insurance
            lres.DriversLicense = new DriversLicense
            {
                LicenseId = Guid.NewGuid().ToString(),
                Expiration = DateTime.Parse("11/03/2016"),
                State = "Texas"
            };
            lres.Destination = "Paris, France";
            lres.Origin = "Austin, Texas";
            lres.PickUpDate = DateTime.Parse("06/14/2016");
            lres.DropOffDate = DateTime.Parse("06/20/2016");
            lres.PickUpLocation = "Austin, Texas";
            lres.DropOffLocation = "Tampa, Florida";
            lres.IsFrequentFlier = false;
            lres.NumberInParty = 1;
            lres.ReservationId = Guid.NewGuid();
            lres.DepartureDate = DateTime.Parse("06/14/2016");
            lres.ReturnDate = DateTime.Parse("06/20/2016");

            lres.Drivers = new List<Driver>
            {
                new Driver
                {
                    FirstName = "Kenneth",
                    LastName = "Du Bose",
                    IsInsured = true,
                    MiddleName = "K",
                    DateOfBirth = DateTime.Parse("12/12/1972"),
                    DriversLicense =
                        new DriversLicense
                        {
                            LicenseId = Guid.NewGuid().ToString(),
                            Expiration = DateTime.Parse("11/03/2016"),
                            State = "Texas"
                        }
                },
                new Driver
                {
                    FirstName = "Peter",
                    LastName = "Drumpf",
                    IsInsured = true,
                    MiddleName = "K",
                    DateOfBirth = DateTime.Parse("12/12/1972"),
                    DriversLicense =
                        new DriversLicense
                        {
                            LicenseId = Guid.NewGuid().ToString(),
                            Expiration = DateTime.Parse("12/23/2016"),
                            State = "Oklahoma"
                        }
                },
                new Driver
                {
                    FirstName = "Mary",
                    LastName = "Bowen",
                    IsInsured = false,
                    MiddleName = "K",
                    DateOfBirth = DateTime.Parse("12/12/1972"),
                    DriversLicense =
                        new DriversLicense
                        {
                            LicenseId = Guid.NewGuid().ToString(),
                            Expiration = DateTime.Parse("12/23/2017"),
                            State = "Maryland"
                        }
                },
                new Driver
                {
                    FirstName = "Emily",
                    LastName = "Sandifer",
                    IsInsured = true,
                    MiddleName = "K",
                    DateOfBirth = DateTime.Parse("12/12/1972"),
                    DriversLicense =
                        new DriversLicense
                        {
                            LicenseId = Guid.NewGuid().ToString(),
                            Expiration = DateTime.Parse("12/23/2017"),
                            State = "Oklahoma"
                        }
                }
            };

            //act
            //var actual = 407.94m;
            //decimal expected;

            //assert
            var expected = al.CalculateTotalAutoReservationCost(lres);
        }
    }
}