using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.Data
{
    public class DataConstraints
    {
        // Coach
        public const int CoachNameMinLength = 2;
        public const int CoachNameMaxLength = 40;

        //Footballer
        public const int FootballerNameMinLength = 2;
        public const int FootballerNameMaxLength = 40;

        //Team
        public const int TeamNameMinLength = 3;
        public const int TeamNameMaxLength = 40;

        public const string TeamNameRegex = @"^[a-zA-Z\d.\-\s]+$";

        public const int TeamNationalityMinLength = 2;
        public const int TeamNationalityMaxLength = 40;
    }

}
