namespace Trucks.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ExportDto;
    using Trucks.Utilities;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            const string xmlRoot = "Despatchers";

            ExportDespatcherDto[] despatchersDto = context.Despatchers
                .Where(d => d.Trucks.Any())
                .Select(d => new ExportDespatcherDto()
                {
                    Name = d.Name,
                    TrucksCount = d.Trucks.Count(),
                    Trucks = d.Trucks
                        .Select(t => new ExportTruckDto()
                        {
                            RegistrationNumber = t.RegistrationNumber,
                            MakeType = t.MakeType
                        })
                        .OrderBy(t => t.RegistrationNumber)
                        .ToArray()
                })
                .OrderByDescending(d => d.Trucks.Count())
                .ThenBy(d => d.Name)
                .ToArray();

            return xmlHelper.Serialize(despatchersDto, xmlRoot);
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients
                .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                .Select(c => new 
                { 
                    Name = c.Name,
                    Trucks = c.ClientsTrucks
                        .Where(ct => ct.Truck.TankCapacity >= capacity)
                        .OrderBy(t => t.Truck.MakeType)
                        .ThenByDescending(t => t.Truck.CargoCapacity)
                        .Select(t => new
                        {
                            TruckRegistrationNumber = t.Truck.RegistrationNumber,
                            VinNumber = t.Truck.VinNumber,
                            TankCapacity = t.Truck.TankCapacity,
                            CargoCapacity = t.Truck.CargoCapacity,
                            CategoryType= t.Truck.CategoryType.ToString(),
                            MakeType = t.Truck.MakeType.ToString(),

                        })
                        .ToArray()
                })
                .OrderByDescending(c => c.Trucks.Count())
                .ThenBy(c =>c.Name)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(clients, Formatting.Indented);
        }
    }
}
