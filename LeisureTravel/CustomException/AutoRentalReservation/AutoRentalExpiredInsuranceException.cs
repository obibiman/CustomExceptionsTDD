using System;

namespace LeisureTravel.CustomException.AutoRentalReservation
{
    public class AutoRentalExpiredInsuranceException : Exception
    {
        public AutoRentalExpiredInsuranceException() : base()
        {

        }

        public AutoRentalExpiredInsuranceException(string message) : base(message)
        {

        }

        public AutoRentalExpiredInsuranceException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}