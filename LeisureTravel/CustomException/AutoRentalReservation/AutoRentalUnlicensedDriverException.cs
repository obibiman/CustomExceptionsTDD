using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTravel.CustomException.AutoRentalReservation
{
    public class AutoRentalUnlicensedDriverException : Exception
    {
        public AutoRentalUnlicensedDriverException() : base()
        {

        }

        public AutoRentalUnlicensedDriverException(string message) : base(message)
        {

        }

        public AutoRentalUnlicensedDriverException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
