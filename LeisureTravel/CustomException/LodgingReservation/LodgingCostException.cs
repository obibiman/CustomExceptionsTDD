using System;

namespace LeisureTravel.CustomException.LodgingReservation
{
    public class LodgingCostException : Exception
    {
        public LodgingCostException() : base()
        {

        }

        public LodgingCostException(string message) : base(message)
        {

        }

        public LodgingCostException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}