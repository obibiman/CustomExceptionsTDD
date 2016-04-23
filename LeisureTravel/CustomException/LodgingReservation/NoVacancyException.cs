using System;

namespace LeisureTravel.CustomException.LodgingReservation
{
    public class NoVacancyException : Exception
    {
        public NoVacancyException() : base()
        {

        }

        public NoVacancyException(string message) : base(message)
        {

        }

        public NoVacancyException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}