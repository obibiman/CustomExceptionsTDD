using System;

namespace LeisureTravel.CustomException.AutoRentalReservation
{
    public class AutoRentalCostException : Exception
    {
        public AutoRentalCostException() : base()
        {

        }

        public AutoRentalCostException(string message) : base(message)
        {

        }

        public AutoRentalCostException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}