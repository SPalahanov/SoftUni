using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            // 01.
            //string usersXml = File.ReadAllText("../../../Datasets/users.xml");
            //Console.WriteLine(ImportUsers(context, usersXml));

            // 02.
            //string productsXml = File.ReadAllText("../../../Datasets/products.xml");
            //Console.WriteLine(ImportProducts(context, productsXml));

            // 03.
            //string categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            //Console.WriteLine(ImportCategories(context, categoriesXml));

            // 04.
            //string categoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(context, categoriesProductsXml));

            // ------------------------------------------------------------------------

            // 05.
            //Console.WriteLine(GetProductsInRange(context));

            // 06.
            //Console.WriteLine(GetSoldProducts(context));

            // 07.
            //Console.WriteLine(GetCategoriesByProductsCount(context));

            // 08.
            Console.WriteLine(GetUsersWithProducts(context));
        }

        // 01. 
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserImportDto[]),
                new XmlRootAttribute("Users"));

            UserImportDto[] userImportDtos;

            using (var reader = new StringReader(inputXml))
            {
                userImportDtos = (UserImportDto[])xmlSerializer.Deserialize(reader);
            }

            User[] users = userImportDtos
                .Select(dto => new User()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age
                })
                .ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        // 02.
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductImportDto[]),
                new XmlRootAttribute("Products"));

            ProductImportDto[] productImportDtos;

            using (var reader = new StringReader(inputXml))
            {
                productImportDtos = (ProductImportDto[])xmlSerializer.Deserialize(reader);
            }

            var userIds = context.Users.Select(u => u.Id).ToHashSet();

            Product[] products = productImportDtos
                .Where(dto => dto.SellerId != null && userIds.Contains(dto.SellerId) &&
                      (dto.BuyerId == null || userIds.Contains(dto.BuyerId)))
                .Select(dto => new Product()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    SellerId = dto.SellerId,
                    BuyerId = dto.BuyerId
                })
                .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        // 03.
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryImportDto[]),
                new XmlRootAttribute("Categories"));

            CategoryImportDto[] categoryImportDtos;

            using (var reader = new StringReader(inputXml))
            {
                categoryImportDtos = (CategoryImportDto[])xmlSerializer.Deserialize(reader);
            }

            var validCategories = categoryImportDtos
                .ToList();

            validCategories.RemoveAll(c => c.Name == null);

            Category[] categories = validCategories
                .Select(dto => new Category()
                {
                    Name = dto.Name
                })
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        // 04.
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryProductImportDto[]),
                new XmlRootAttribute("CategoryProducts"));

            CategoryProductImportDto[] categoryProductImportDtos;

            using (var reader = new StringReader(inputXml))
            {
                categoryProductImportDtos = (CategoryProductImportDto[])xmlSerializer.Deserialize(reader);
            }

            var categoryIds = context.Categories
                .Select(c => c.Id)
                .ToArray();

            var productIds = context.Products
                .Select(c => c.Id)
                .ToArray();

            var validCategoryProducts = categoryProductImportDtos
                .Where(c => categoryIds.Contains(c.CategoryId) &&
                            productIds.Contains(c.ProductId))
                .ToArray();

            CategoryProduct[] categoryProducts = validCategoryProducts
                .Select(dto => new CategoryProduct()
                {
                    CategoryId = dto.CategoryId,
                    ProductId = dto.ProductId
                })
                .ToArray();

            
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        // -------------------------------------------------------------------------------

        // 05.
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsWithRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductWithRangeExportDto() 
                { 
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();
            
            return SerializeToXml(productsWithRange, "Products");
        }

        // 06.
        public static string GetSoldProducts(ProductShopContext context)
        {
            var userWithProducts = context.Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new UserWithOneOrMoreProductExportDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Product = u.ProductsSold
                        .Select(p => new ProductsSoldDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            return SerializeToXml(userWithProducts, "Users");
        }

        // 07.
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new CategoryByProductsCountExportDto()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts
                        .Average(p => p.Product.Price),
                    TotalRevenue = c.CategoryProducts
                        .Sum(p => p.Product.Price)
                })
                .OrderByDescending(u => u.Count)
                .ThenBy(u => u.TotalRevenue)
                .ToArray();

            return SerializeToXml(categories, "Categories");
        }

        // 08.
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersAndproducts = context.Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new UserWithProductsExportDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    Product = u.ProductsSold
                        .Select(p => new ProductsSoldDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToArray()
                })
                
                .ToArray();

            return SerializeToXml(usersAndproducts, "Users");
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