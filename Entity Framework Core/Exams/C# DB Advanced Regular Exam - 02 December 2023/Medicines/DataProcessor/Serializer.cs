namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ExportDtos;
    using Medicines.Utilities;
    using Newtonsoft.Json;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            DateTime givenDate;
            DateTime.TryParse(date, out givenDate);
            
            XmlHelper xmlHelper = new XmlHelper();

            const string xmlRoot = "Patients";

            ExportPatientDto[] patientsToExport = context.Patients
                .Where(p => p.PatientsMedicines.Any(m => m.Medicine.ProductionDate >= givenDate))
                .Select(p => new ExportPatientDto
                {
                    FullName = p.FullName,
                    AgeGroup = p.AgeGroup.ToString(),
                    Gender = p.Gender.ToString().ToLower(),
                    Medicines = p.PatientsMedicines
                        .Where(pm => pm.Medicine.ProductionDate >= givenDate)
                        .Select(pm => pm.Medicine)
                            .OrderByDescending(m => m.ExpiryDate)
                            .ThenBy(m => m.Price)
                            .Select(m => new ExportMedicineDto()
                            {
                                Name = m.Name,
                                Price = m.Price.ToString("f2"),
                                Producer = m.Producer,
                                ExpiryDate = m.ExpiryDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                                Category = m.Category.ToString().ToLower()
                            })
                            .ToArray()
                    
                })
                .OrderByDescending(p => p.Medicines.Count())
                .ThenBy(p => p.FullName)
                .ToArray();

            return xmlHelper.Serialize(patientsToExport, xmlRoot);
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicineToExport = context.Medicines
                .Where(m => m.Category == (Category)medicineCategory)
                .Where(m => m.Pharmacy.IsNonStop == true)
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .Select(m => new 
                {
                    Name = m.Name,
                    Price = m.Price.ToString("F2"),
                    Pharmacy = new
                    {
                        Name = m.Pharmacy.Name,
                        PhoneNumber = m.Pharmacy.PhoneNumber
                    }

                })
                .ToArray();

            return JsonConvert.SerializeObject(medicineToExport, Formatting.Indented);
        }
    }
}
