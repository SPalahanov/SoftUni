using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Channels;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            // 09.
            //string suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context, suppliersXml));

            // 10.
            //string partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            //Console.WriteLine(ImportParts(context, partsXml));

            // 11.
            //string carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            //Console.WriteLine(ImportCars(context, carsXml));

            // 12.
            //string customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //Console.WriteLine(ImportCustomers(context, customersXml));

            // 13.
            //string salesXml = File.ReadAllText("../../../Datasets/sales.xml");
            //Console.WriteLine(ImportSales(context, salesXml));

            // ------------------------------------------------------------------------

            // 14.
            //Console.WriteLine(GetCarsWithDistance(context));

            // 15.
            //Console.WriteLine(GetCarsFromMakeBmw(context));

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
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierImportDto[]),
                new XmlRootAttribute("Suppliers"));

            SupplierImportDto[] importDtos;

            using (var reader = new StringReader(inputXml))
            {
                importDtos = (SupplierImportDto[])xmlSerializer.Deserialize(reader);
            }

            Supplier[] suppliers = importDtos
                .Select(dto => new Supplier()
                {
                    Name = dto.Name,
                    IsImporter = dto.IsImporter
                })
                .ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            
            return $"Successfully imported {suppliers.Length}";
        }

        // 10.
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PartImporterDto[]),
                new XmlRootAttribute("Parts"));

            PartImporterDto[] importDtos;

            using(var reader = new StringReader(inputXml)) 
            {
                importDtos = (PartImporterDto[])xmlSerializer.Deserialize(reader); 
            }

            var supplierIds = context.Suppliers
                .Select(s => s.Id)
                .ToArray();

            var partsWithValidSupplier = importDtos
                .Where(p => supplierIds.Contains(p.SupplierId))
                .ToArray();

            Part[] parts = partsWithValidSupplier
                .Select(dto => new Part()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    SupplierId = dto.SupplierId
                })
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        // 11.
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarImportDto[]),
                new XmlRootAttribute("Cars"));

            CarImportDto[] importDtos;

            using (var reader = new StringReader(inputXml))
            {
                importDtos = (CarImportDto[])xmlSerializer.Deserialize(reader);
            }

            List<Car> cars = new List<Car>();

            foreach (var dto in importDtos)
            {
                Car car = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TraveledDistance = dto.TraveledDistance
                };

                int[] carPartsIds = dto.PartIds
                    .Select(p => p.Id)
                    .Distinct()
                    .ToArray();

                var carParts = new List<PartCar>();

                foreach (var id in carPartsIds)
                {
                    carParts.Add(new PartCar()
                    {
                        Car = car,
                        PartId = id
                    });
                }

                car.PartsCars = carParts;

                cars.Add(car);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        // 12.
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerImportDto[]),
                new XmlRootAttribute("Customers"));

            CustomerImportDto[] importDtos;

            using (var reader = new StringReader(inputXml))
            {
                importDtos = (CustomerImportDto[])xmlSerializer.Deserialize(reader);
            }

            Customer[] customers = importDtos
                .Select(dto => new Customer()
                {
                    Name = dto.Name,
                    BirthDate = dto.BirthDate,
                    IsYoungDriver = dto.IsYoungDriver

                })
                .ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        // 13.
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaleImportDto[]),
                new  XmlRootAttribute("Sales"));

            SaleImportDto[] importDtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                importDtos = (SaleImportDto[])xmlSerializer.Deserialize(reader);
            }

            int[] carIds = context.Cars
                .Select(c => c.Id)
                .ToArray();

            var validSalesImport = importDtos
                .Where(dto => carIds.Contains(dto.CarId))
                .ToArray();

            Sale[] sales = validSalesImport
                .Select(vs => new Sale()
                {
                    CarId = vs.CarId,
                    CustomerId = vs.CustomerId,
                    Discount = vs.Discount
                })
                .ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        // -------------------------------------------------------------------------------

        // 14.
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var carsWithDistance = context.Cars
                .Select(c => new CarWithDistanceExportDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();
            
                       
            return SerializeToXml(carsWithDistance, "cars");
        }

        // 15.
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var bmwCars = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new CarsFromBmwExportDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToArray();

            return SerializeToXml(bmwCars, "cars", true);
        }

        // 16.
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new LocalSuplierExportDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            return SerializeToXml(suppliers, "suppliers");
        }

        // 17.
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(s => new CarsWithPartsListExportDto()
                {
                    Make = s.Make,
                    Model = s.Model,
                    TraveledDistance = s.TraveledDistance,
                    Parts = s.PartsCars
                        .OrderByDescending(p => p.Part.Price)
                        .Select(pc => new PartsForCarsDto()
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price
                        })
                        .ToArray()
                })
                .ToArray();

            return SerializeToXml(cars, "cars");
        }

        // 18.
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var temp = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SalesInfo = c.Sales
                        .Select(s => new
                        {
                            Prices = c.IsYoungDriver
                            ? s.Car.PartsCars.Sum(pc => Math.Round((double)pc.Part.Price * 0.95, 2))
                            : s.Car.PartsCars.Sum(pc => (double)pc.Part.Price)
                        })
                        .ToArray()
                })
                .ToArray();

            var customerSales = temp
                .OrderByDescending(x => x.SalesInfo.Sum(p => p.Prices))
                .Select(c => new CustomerExportDto
                {
                    FullName = c.FullName,
                    CarsBought = c.BoughtCars,
                    MoneySpent = c.SalesInfo.Sum(p => (decimal)p.Prices)
                })
                .ToArray();

            return SerializeToXml(customerSales, "customers");
        }

        // 19.
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new SaleWithDiscountExportDto()
                {
                    Car = new CarDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = Math.Round((double)(s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (s.Discount / 100))), 4)
                })
                .ToArray();

            return SerializeToXml(sales, "sales");
        }

        private static string SerializeToXml<T>(T dto, string xmlRootAttribute, bool omitDeclaration = false)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));
            StringBuilder sb = new StringBuilder();

            XmlWriterSettings settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = omitDeclaration,
                Encoding = new UTF8Encoding(false),
                Indent = true
            };

            using (StringWriter stringWriter = new StringWriter(sb, CultureInfo.InvariantCulture))
            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings)) 
            {
                XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
                xmlSerializerNamespaces.Add(string.Empty, string.Empty);

                try
                {
                    xmlSerializer.Serialize(xmlWriter, dto, xmlSerializerNamespaces);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return sb.ToString();
        }
    }
}