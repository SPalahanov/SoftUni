using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data
{
    public class DataConstraints
    {
        //TourPackage
        public const int TourPackageNameMinLength = 2;
        public const int TourPackageNameMaxLength = 40;

        public const int TourPackageDescriptionMaxLength = 200;

        //public const int TourPackagePrice = 200;

        //Guide
        public const int GuideFullNameMinLength = 4;
        public const int GuideFullNameMaxLength = 60;

        //Customer
        public const int CustomerFullNameMinLength = 4;
        public const int CustomerFullNameMaxLength = 60;

        public const int CustomerEmailMinLength = 6;
        public const int CustomerEmailMaxLength = 50;

        public const string CustomerPhoneNumberRegex = @"\+\d{12}$";

        public const int CustomerPhoneNumberMaxLength = 13;
    }
}
