namespace Medicines.DataProcessor
{
    using Castle.Core.Internal;
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ImportDtos;
    using Medicines.Utilities;
    using Microsoft.VisualBasic;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var patientDtos = JsonConvert.DeserializeObject<ImportPatientDto[]>(jsonString);

            List<Patient> patients = new List<Patient>();

            var medicineIds = context.Medicines
                .Select(m => m.Id)
                .ToArray();

            foreach (var patientDto in patientDtos)
            {
                if (IsValid(patientDto) == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Patient patient = new Patient()
                {
                    FullName = patientDto.FullName,
                    AgeGroup = (AgeGroup)patientDto.AgeGroup,
                    Gender = (Gender)patientDto.Gender
                };

                foreach (var id in patientDto.MedicinesId)
                {
                    if (patient.PatientsMedicines.Any(x => x.MedicineId == id))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    PatientMedicine patientMedicine = new PatientMedicine()
                    {
                        Patient = patient,
                        MedicineId = id
                    };

                    patient.PatientsMedicines.Add(patientMedicine);
                }

                patients.Add(patient);

                sb.AppendLine(String
                        .Format(SuccessfullyImportedPatient, patient.FullName, patient.PatientsMedicines.Count));
            }

            context.Patients.AddRange(patients);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            ImportPharmacyDto[] pharmacyDtos = XmlHelper
                .Deserialize<ImportPharmacyDto[]>(xmlString, "Pharmacies");

            List<Pharmacy> pharmacies = new List<Pharmacy>();

            foreach (var pharmacyDto in pharmacyDtos)
            {
                if (IsValid(pharmacyDto) == false)
                {
                    sb.AppendLine(String.Format(ErrorMessage));
                    continue;
                }

                Pharmacy pharmacy = new Pharmacy()
                {
                    Name = pharmacyDto.Name,
                    PhoneNumber = pharmacyDto.PhoneNumber,
                    IsNonStop = bool.Parse(pharmacyDto.IsNonStop),
                };

                foreach (var medicineDto in pharmacyDto.Medicines)
                {
                    if (IsValid(medicineDto) == false)
                    {
                        sb.AppendLine(String.Format(ErrorMessage));
                        continue;
                    }

                    bool isProductionDateValid = DateTime
                        .TryParseExact(medicineDto.ProductionDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime productionDate);

                    if (IsValid(isProductionDateValid) == false)
                    {
                        sb.AppendLine(String.Format(ErrorMessage));
                        continue;
                    }

                    bool isExpiryDateValid = DateTime
                        .TryParseExact(medicineDto.ExpiryDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expiryDate);

                    if (IsValid(isExpiryDateValid) == false)
                    {
                        sb.AppendLine(String.Format(ErrorMessage));
                        continue;
                    }

                    if (productionDate >= expiryDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (pharmacy.Medicines.Any(x => x.Name == medicineDto.Name && x.Producer == medicineDto.Producer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Medicine medicine = new Medicine()
                    {
                        Name = medicineDto.Name,
                        Price = (decimal)medicineDto.Price,
                        Category = (Category)medicineDto.Category,
                        ProductionDate = productionDate,
                        ExpiryDate = expiryDate,
                        Producer = medicineDto.Producer
                    };

                    pharmacy.Medicines.Add(medicine);
                }

                pharmacies.Add(pharmacy);

                sb.AppendLine(String
                    .Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
            }

            context.Pharmacies.AddRange(pharmacies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
