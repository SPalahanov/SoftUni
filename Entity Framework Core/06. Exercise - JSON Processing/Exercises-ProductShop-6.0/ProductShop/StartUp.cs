using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            // 01.
            //string userText = File.ReadAllText("../../../Datasets/users.json");
            //Console.WriteLine(ImportUsers(context, userText));

            // 02.
            //string productText = File.ReadAllText("../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(context, productText));

            // 03.
            //string categoryText = File.ReadAllText("../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(context, categoryText));

            // 04.
            //string categoryProductText = File.ReadAllText("../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(context, categoryProductText));

            //------------------------------------------------------//

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
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();
            
            return $"Successfully imported {users.Count}";
        }

        // 02.
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        // 03.
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);

            categories.RemoveAll(c => c.Name == null);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        // 04.
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoriesProducts.AddRange(categoryProducts);

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //----------------------------------------------------------------------------//

        // 05.
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ExportProductDTO
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToList();

            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };
            
            return JsonConvert.SerializeObject(productsInRange, settings);
        }

        // 06.
        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId >= 1))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(p => new 
                        {
                            p.Name,
                            p.Price,
                            BuyerFirstName = p.Buyer.FirstName,
                            BuyerLastName = p.Buyer.LastName
                        })
                })
                .ToList();

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(soldProducts, settings);
        }

        // 07.
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoriesProducts.Count,
                    AveragePrice = c.CategoriesProducts
                        .Average(cp => cp.Product.Price)
                        .ToString("f2"),
                    TotalRevenue = c.CategoriesProducts
                        .Sum(cp => cp.Product.Price)
                        .ToString("f2")
                })
                .OrderByDescending(x => x.ProductsCount)
                .ToList();

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(categories, settings);
        }

        // 08.
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null && p.Price != null))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = u.ProductsSold
                        .Where(p => p.BuyerId != null && p.Price != null)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price

                        })
                        .ToArray()
                })
                .OrderByDescending(u => u.SoldProducts.Length)
                .ToArray();

            var output = new
            {
                UsersCount = users.Length,
                Users = users.Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.SoldProducts.Length,
                        Products = u.SoldProducts
                    }
                })
            };

            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(output, settings);
        }
    }
}