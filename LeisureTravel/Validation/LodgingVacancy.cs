using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTravel.Validation
{
    public class LodgingVacancy
    {
        public bool HasVacancy(int numberInParty)
        {
            bool hasVacancy;
            int range = 5;
            int occupancy = (numberInParty - 1)/range;
            switch (occupancy)
            {
                case (0):
                    hasVacancy = true;
                    break;
                case (1):
                    hasVacancy = false;
                    break;
                case (2):
                    hasVacancy = false;
                    break;
                default:
                    hasVacancy = false;
                    break;
            }
            return hasVacancy;
        }
    }
}
