using System;

namespace LeisureTravel.CustomException.AutoRentalReservation
{
    public class AutoRentalUninsuredDriverException : Exception
    {
        public AutoRentalUninsuredDriverException() : base()
        {

        }

        public AutoRentalUninsuredDriverException(string message) : base(message)
        {

        }

        public AutoRentalUninsuredDriverException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}