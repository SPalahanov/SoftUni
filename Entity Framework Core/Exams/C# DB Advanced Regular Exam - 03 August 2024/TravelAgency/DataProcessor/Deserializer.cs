using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Globalization;
using System.Runtime.Intrinsics.X86;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;
using TravelAgency.Utilities;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            ImportCustomerDto[] customerDtos = XmlHelper.Deserialize<ImportCustomerDto[]>(xmlString, "Customers");

            ICollection<Customer> customers = new List<Customer>();

            foreach (var customerDto in customerDtos)
            {
                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Customer customer = new Customer()
                {
                    FullName = customerDto.FullName,
                    Email = customerDto.Email,
                    PhoneNumber = customerDto.PhoneNumber,
                };

                if (customers.Any(c => c.FullName == customer.FullName || c.Email == customer.Email || c.PhoneNumber == customer.PhoneNumber))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }

                customers.Add(customer);
                sb.AppendLine(String
                    .Format(SuccessfullyImportedCustomer, customer.FullName));
            }
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportBookingDto[] bookingDtos = JsonConvert.DeserializeObject<ImportBookingDto[]>(jsonString);

            ICollection<Booking> bookings = new List<Booking>();

            foreach (var bookingDto in bookingDtos)
            {
                if (!IsValid(bookingDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isBookingDateValid = DateTime
                        .TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime bookingDate);

                if (IsValid(isBookingDateValid) == false)
                {
                    sb.AppendLine(String.Format(ErrorMessage));
                    continue;
                }

                if (bookingDate.Year < 2000)
                {
                    sb.AppendLine(String.Format(ErrorMessage));
                    continue;
                }

                var customer = context.Customers.FirstOrDefault(c => c.FullName == bookingDto.CustomerName);
                var tourPackage = context.TourPackages.FirstOrDefault(tp => tp.PackageName == bookingDto.TourPackageName);

                if (customer == null || tourPackage == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Booking booking = new Booking()
                {
                    BookingDate = bookingDate,
                    Customer = customer,
                    TourPackage = tourPackage,
                };

                bookings.Add(booking);
                sb.AppendLine(string.Format(SuccessfullyImportedBooking, tourPackage.PackageName, booking.BookingDate.ToString("yyyy-MM-dd")));
            }

            context.Bookings.AddRange(bookings);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
