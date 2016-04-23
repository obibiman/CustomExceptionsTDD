using System;

namespace LeisureTravel.CustomException
{
    public class InvalidDestinatinationException : Exception
    {
        public InvalidDestinatinationException() : base()
        {

        }

        public InvalidDestinatinationException(string message) : base(message)
        {

        }

        public InvalidDestinatinationException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}