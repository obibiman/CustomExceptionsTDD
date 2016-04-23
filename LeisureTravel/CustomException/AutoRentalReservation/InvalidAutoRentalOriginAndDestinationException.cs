using System;

namespace LeisureTravel.CustomException.AutoRentalReservation
{
    public class InvalidAutoRentalOriginAndDestinationException : Exception
    {
        public InvalidAutoRentalOriginAndDestinationException() : base()
        {

        }

        public InvalidAutoRentalOriginAndDestinationException(string message) : base(message)
        {

        }

        public InvalidAutoRentalOriginAndDestinationException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}