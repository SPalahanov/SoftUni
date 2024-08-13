using Cadastre.Data;
using Cadastre.DataProcessor.ExportDtos;
using Cadastre.Utilities;
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            DateTime date = DateTime
                        .ParseExact("01/01/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

            var properties = dbContext.Properties
                .Where(p => p.DateOfAcquisition >= date)
                .OrderByDescending(p => p.DateOfAcquisition)
                .ThenBy(p => p.PropertyIdentifier)
                .Select(p => new
                {
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    Address = p.Address,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                    Owners = p.PropertiesCitizens
                        .Select(c => new
                        {
                            LastName = c.Citizen.LastName,
                            MaritalStatus = c.Citizen.MaritalStatus.ToString()
                        })
                        .OrderBy(c => c.LastName)
                        .ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(properties, Formatting.Indented);
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            XmlHelper xmlHelper = new XmlHelper();

            const string xmlRoot = "Properties";

            ExportPropertyDto[] propertiesDtos = dbContext.Properties
                .Where(p => p.Area >= 100)
                .OrderByDescending(p => p.Area)
                .ThenBy(p => p.DateOfAcquisition)
                .Select(p => new ExportPropertyDto()
                {
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                    PostalCode = p.District.PostalCode
                })
                
                .ToArray();

            return xmlHelper.Serialize(propertiesDtos, xmlRoot);
        }
    }
}
