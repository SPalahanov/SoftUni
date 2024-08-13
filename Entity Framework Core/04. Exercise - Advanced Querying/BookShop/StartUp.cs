namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();

            //DbInitializer.ResetDatabase(db);

            // 02.
            //Console.WriteLine(GetBooksByAgeRestriction(db, "miNor"));

            // 03.
            //Console.WriteLine(GetGoldenBooks(db));

            // 04.
            //Console.WriteLine(GetBooksByPrice(db));

            // 05.
            //Console.WriteLine(GetBooksNotReleasedIn(db, 2000));

            // 06.
            //Console.WriteLine(GetBooksByCategory(db, "horror mystery drama"));

            // 07.
            //Console.WriteLine(GetBooksReleasedBefore(db, "12-04-1992"));

            // 08.
            //Console.WriteLine(GetAuthorNamesEndingIn(db, "e"));

            // 09.
            //Console.WriteLine(GetBookTitlesContaining(db, "sK"));

            // 10.
            //Console.WriteLine(GetBooksByAuthor(db, "R"));

            // 11.
            //Console.WriteLine(CountBooks(db, 12));

            // 12.
            //Console.WriteLine(CountCopiesByAuthor(db));

            // 13.
            //Console.WriteLine(GetTotalProfitByCategory(db));

            // 14.
            //Console.WriteLine(GetMostRecentBooks(db));

            // 15.
            //IncreasePrices(db);

            // 16.
            Console.WriteLine(RemoveBooks(db));
        }

        // 02.
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            if (!Enum.TryParse(command, true, out AgeRestriction ageRestriction))
            {
                return string.Empty;
            }
            
            var bookTitle = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();
            
            StringBuilder sb = new StringBuilder();

            foreach (var title in bookTitle) 
            {
                sb.AppendLine(title);
            }
            
            return sb.ToString().TrimEnd();
        }

        // 03.
        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .Select(b => new
                {
                    b.BookId,
                    b.Title
                })
                .OrderBy(b => b.BookId)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var books in goldenBooks)
            {
                sb.AppendLine(books.Title);
            }

            return sb.ToString().TrimEnd();
        }

        // 04.
        public static string GetBooksByPrice(BookShopContext context)
        {
            var mostExpensiveBooks = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in mostExpensiveBooks)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 05.
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var notReleasedBooks = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .Select(b => new
                {
                    b.BookId,
                    b.Title
                })
                .OrderBy(b => b.BookId)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var title in notReleasedBooks)
            {
                sb.AppendLine(title.Title);
            }

            return sb.ToString().TrimEnd();
        }

        // 06.
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            var titlesByCategory = context.BooksCategories
                .Where(bc => categories.Contains(bc.Category.Name.ToLower()))
                .Select(bc => bc.Book.Title)
                .OrderBy(t => t)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var title in titlesByCategory)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        // 07.
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dt = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            
            var releasedBeforeDate = context.Books
                .Where(b => b.ReleaseDate < dt)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate
                })
                .OrderByDescending(b => b.ReleaseDate)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in releasedBeforeDate)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }
            
            return sb.ToString().TrimEnd();
        }

        // 08.
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray()
                .OrderBy(n => n);
            
            return string.Join(Environment.NewLine, authors);
        }

        // 09.
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string loweredInput = input.ToLower();

            var bookTitles = context.Books
                .Where(b => b.Title.ToLower().Contains(loweredInput))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        // 10.
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.Author.FirstName, 
                    b.Author.LastName
                })
                .OrderBy(b => b.BookId)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.FirstName} {book.LastName})");
            }
            
            return sb.ToString().TrimEnd();
        }

        // 11.
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var bookCounter = context.Books
                .Count(b => b.Title.Length > lengthCheck);
            
            return bookCounter;
        }

        // 12.
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    BooksSum = a.Books
                    .Select(b => new
                    {
                        b.Copies
                    })
                    .Sum(b => b.Copies)
                })
                .OrderByDescending(b => b.BooksSum)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName} - {author.BooksSum}");
            }

            return sb.ToString().TrimEnd();
        }

        // 13.
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var booksCategories = context.Categories
                .Select(c => new
                {
                    CategoriesName = c.Name,
                    Profit = c.CategoryBooks.Select(cb => new
                    {
                        CategoriesName = cb.Category.Name,
                        Profit = cb.Book.Price * cb.Book.Copies,
                    })
                    .Sum(bc => bc.Profit)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.CategoriesName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksCategories)
            {
                sb.AppendLine($"{book.CategoriesName} ${book.Profit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 14.
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var booksCategories = context.Categories
                .Select(c => new
                {
                    CategoriesName = c.Name,
                    BooksTitle = c.CategoryBooks.Select(cb => new
                    {
                        Title = cb.Book.Title,
                        ReleasedDate = cb.Book.ReleaseDate
                    })
                    .OrderByDescending(cb => cb.ReleasedDate)
                    .ToArray()
                })
                .OrderBy(c => c.CategoriesName)
                .ToArray();


            StringBuilder sb = new StringBuilder();

            foreach (var book in booksCategories)
            {
                sb.AppendLine($"--{book.CategoriesName}");

                int count = 0;

                foreach (var title in book.BooksTitle)
                {
                    sb.AppendLine($"{title.Title} ({title.ReleasedDate.Value.Year})");

                    count++;

                    if (count == 3)
                    {
                        break;
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        // 15.
        public static void IncreasePrices(BookShopContext context)
        {
            var booksToChange = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var book in booksToChange)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        // 16.
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToDelete = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.RemoveRange(booksToDelete);
            context.SaveChanges();
            
            return booksToDelete.Count();
        }
    }
}


