using System;

namespace LeisureTravel.CustomException.AutoRentalReservation
{
    public class TicketCostException : Exception
    {
        public TicketCostException() : base()
        {

        }

        public TicketCostException(string message) : base(message)
        {

        }

        public TicketCostException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}