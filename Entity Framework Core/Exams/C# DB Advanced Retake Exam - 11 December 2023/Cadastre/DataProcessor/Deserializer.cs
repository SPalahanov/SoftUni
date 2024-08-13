namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Cadastre.DataProcessor.ImportDtos;
    using Cadastre.Utilities;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Data.SqlTypes;
    using System.Globalization;
    using System.Net;
    using System.Runtime.Intrinsics.X86;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            StringBuilder sb = new StringBuilder();

            ImportDistrictDto[] districtDtos = XmlHelper.Deserialize<ImportDistrictDto[]>(xmlDocument, "Districts");

            ICollection<District> districts = new List<District>();

            foreach (var districtDto in districtDtos)
            {
                if (!IsValid(districtDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (dbContext.Districts.Any(d => d.Name == districtDto.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                District district = new District()
                {
                    Name = districtDto.Name,
                    PostalCode = districtDto.PostalCode,
                    Region = (Region)Enum.Parse(typeof(Region), districtDto.Region)
                };

                foreach (var propertyDto in districtDto.Properties)
                {
                    if (!IsValid(propertyDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime dateOfAcquisition = DateTime
                        .ParseExact(propertyDto.DateOfAcquisition, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

                    if (dbContext.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier) ||
                        district.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dbContext.Properties.Any(p => p.Address == propertyDto.Address) ||
                        district.Properties.Any(p => p.Address == propertyDto.Address))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Property property = new Property()
                    {
                        PropertyIdentifier = propertyDto.PropertyIdentifier,
                        Area = propertyDto.Area,
                        Details = propertyDto.Details,
                        Address = propertyDto.Address,
                        DateOfAcquisition = dateOfAcquisition
                    };

                    district.Properties.Add(property);
                }

                districts.Add(district);

                sb.AppendLine(String.Format(SuccessfullyImportedDistrict, district.Name, district.Properties.Count));
            }

            dbContext.Districts.AddRange(districts);
            dbContext.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            StringBuilder sb = new StringBuilder();

            ImportCitizenDto[] citizensDtos = JsonConvert.DeserializeObject<ImportCitizenDto[]>(jsonDocument);

            ICollection<Citizen> citizens = new List<Citizen>();

            foreach (var citizensDto in citizensDtos)
            {
                if (!IsValid(citizensDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime birthDate = DateTime
                        .ParseExact(citizensDto.BirthDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

                Citizen citizen = new Citizen()
                {
                    FirstName = citizensDto.FirstName,
                    LastName = citizensDto.LastName,
                    BirthDate = birthDate,
                    MaritalStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus), citizensDto.MaritalStatus)
                };

                foreach (var id in citizensDto.PropertiesId)
                {
                    PropertyCitizen propertyCitizen = new PropertyCitizen() 
                    {
                        Citizen = citizen,
                        PropertyId = id
                    };

                    citizen.PropertiesCitizens.Add(propertyCitizen);
                }

                citizens.Add(citizen);

                sb.AppendLine(String
                     .Format(SuccessfullyImportedCitizen, citizen.FirstName, citizen.LastName, citizen.PropertiesCitizens.Count));
            }

            dbContext.Citizens.AddRange(citizens);
            dbContext.SaveChanges();

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
