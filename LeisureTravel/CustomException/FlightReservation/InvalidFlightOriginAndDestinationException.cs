using System;

namespace LeisureTravel.CustomException.AutoRentalReservation
{
    public class InvalidFlightOriginAndDestinationException : Exception
    {
        public InvalidFlightOriginAndDestinationException() : base()
        {

        }

        public InvalidFlightOriginAndDestinationException(string message) : base(message)
        {

        }

        public InvalidFlightOriginAndDestinationException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}