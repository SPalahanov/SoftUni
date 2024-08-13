namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Boardgames.Utilities;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var creatorDtos = XmlHelper
                .Deserialize<ImportCreatorDto[]>(xmlString, "Creators");

            List<Creator> creators = new List<Creator>();

            foreach (var creatorDto in creatorDtos)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(String.Format(ErrorMessage));
                    continue;
                }

                Creator creator = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName
                };

                foreach (var gameDto in creatorDto.Boardgames)
                {
                    if (IsValid(gameDto) == false)
                    {
                        sb.AppendLine(String.Format(ErrorMessage));
                        continue;
                    }

                    Boardgame game = new Boardgame()
                    {
                        Name = gameDto.Name,
                        Rating = gameDto.Rating,
                        YearPublished = gameDto.YearPublished,
                        CategoryType = (CategoryType)gameDto.CategoryType,
                        Mechanics = gameDto.Mechanics
                    };

                    creator.Boardgames.Add(game);
                }

                creators.Add(creator);

                sb.AppendLine(String
                    .Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count()));
            }

            context.Creators.AddRange(creators);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var sellersDtos = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString);

            List<Seller> sellers = new List<Seller>();

            var boardgameIds = context.Boardgames
                .Select(b => b.Id)
                .ToArray();

            foreach ( var sellersDto in sellersDtos)
            {
                if (IsValid(sellersDto) == false)
                {
                    sb.AppendLine(String.Format(ErrorMessage));
                    continue;
                }

                Seller seller = new Seller()
                {
                    Name = sellersDto.Name,
                    Address = sellersDto.Address,
                    Country = sellersDto.Country,
                    Website = sellersDto.Website
                };

                foreach (var id in sellersDto.BoardgamesId.Distinct())
                {
                    if (!boardgameIds.Contains(id))
                    {
                        sb.AppendLine(String.Format(ErrorMessage));
                        continue;
                    }

                    BoardgameSeller boardgameSeller = new BoardgameSeller()
                    {
                        Seller = seller,
                        BoardgameId = id
                    };

                    seller.BoardgamesSellers.Add(boardgameSeller);
                }

                sellers.Add(seller);

                sb.AppendLine(String
                        .Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count()));
            }

            context.Sellers.AddRange(sellers);
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
