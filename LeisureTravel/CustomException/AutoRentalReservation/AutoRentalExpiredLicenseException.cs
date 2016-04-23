using System;

namespace LeisureTravel.CustomException.AutoRentalReservation
{
    public class AutoRentalExpiredLicenseException : Exception
    {
        public AutoRentalExpiredLicenseException() : base()
        {

        }

        public AutoRentalExpiredLicenseException(string message) : base(message)
        {

        }

        public AutoRentalExpiredLicenseException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}