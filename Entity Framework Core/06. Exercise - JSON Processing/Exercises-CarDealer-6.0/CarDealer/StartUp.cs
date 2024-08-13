using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading.Channels;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            // 09.
            //string suppliersString = File.ReadAllText("../../../Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(context, suppliersString));

            // 10.
            //string partsString = File.ReadAllText("../../../Datasets/parts.json");
            //Console.WriteLine(ImportParts(context, partsString));

            // 11.
            //string carsString = File.ReadAllText("../../../Datasets/cars.json");
            //Console.WriteLine(ImportCars(context, carsString));

            // 12.
            //string customersString = File.ReadAllText("../../../Datasets/customers.json");
            //Console.WriteLine(ImportCustomers(context, customersString));

            // 13.
            //string salesString = File.ReadAllText("../../../Datasets/sales.json");
            //Console.WriteLine(ImportSales(context, salesString));

            // --------------------------------------------------------------------------//

            // 14.
            //Console.WriteLine(GetOrderedCustomers(context));

            // 15.
            //Console.WriteLine(GetCarsFromMakeToyota(context));

            // 16.
            //Console.WriteLine(GetLocalSuppliers(context));

            // 17.
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            // 18.
            //Console.WriteLine(GetTotalSalesByCustomer(context));

            // 19.
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        // 09.
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        // 10.
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson);

            var validsupplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToArray();

            var partsWithValidSupplierIds = parts
                .Where(p => validsupplierIds.Contains(p.SupplierId))
                .ToArray();

            context.Parts.AddRange(partsWithValidSupplierIds);
            context.SaveChanges();

            return $"Successfully imported {partsWithValidSupplierIds.Length}.";
        }

        // 11.
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDTOs = JsonConvert.DeserializeObject<List<ImportCarDTO>>(inputJson);

            var cars = new HashSet<Car>();
            var partsCars = new HashSet<PartCar>();

            var validPartIds = context.Parts.Select(p => p.Id).ToHashSet();

            foreach (var carDto in carsDTOs)
            {
                var newCar = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance,
                };

                cars.Add(newCar);

                foreach (var partId in carDto.PartsId.Distinct())
                {
                    if (validPartIds.Contains(partId))
                    {
                        partsCars.Add(new PartCar()
                        {
                            Car = newCar,
                            PartId = partId
                        });
                    }
                }
            }

            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(partsCars);
            context.SaveChanges();


            return $"Successfully imported {cars.Count}.";
        }

        // 12.
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        // 13.
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        // --------------------------------------------------------------------//

        // 14.
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                
                .ToList();

            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(customers, settings);
        }

        // 15.
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var customers = context.Cars
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TraveledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToList();

            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(customers, settings);
        }

        // 16.
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var supplier = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new 
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(supplier, settings);
        }

        // 17.
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TraveledDistance = c.TraveledDistance
                    },
                    parts = c.PartsCars.Select(pc => new
                    {
                        Name = pc.Part.Name,
                        Price = $"{pc.Part.Price:F2}"
                    }).ToList(),

                }).ToList();

            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(cars, settings);
        }

        // 18.
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customer = context.Customers
                .Where(c => c.Sales.Count() > 0)
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SpentMoney = c.Sales.Sum(s => s.Car.PartsCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToArray();

            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(customer, settings);
        }

        // 19.
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = $"{s.Discount:F2}",
                    price = $"{s.Car.PartsCars.Sum(pc => pc.Part.Price):F2}",
                    priceWithDiscount = $"{s.Car.PartsCars.Sum(pc => pc.Part.Price) * (1 - (s.Discount / 100)):F2}"
                })
                .ToArray();

            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(sales, settings);
        }
    }
}