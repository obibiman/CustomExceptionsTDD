using System;

namespace LeisureTravel.CustomException
{
    public class DateRangeException : Exception
    {
        public DateRangeException() : base()
        {

        }

        public DateRangeException(string message) : base(message)
        {

        }

        public DateRangeException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}