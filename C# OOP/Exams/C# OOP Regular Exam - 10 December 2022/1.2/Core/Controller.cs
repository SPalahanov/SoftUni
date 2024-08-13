using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths;

        public Controller()
        {
            booths = new BoothRepository();
        }
        
        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(booths.Models.Count + 1, capacity);

            booths.AddModel(booth);
            
            return string.Format(OutputMessages.NewBoothAdded, booth.BoothId, booth.Capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != "Gingerbread" && delicacyTypeName != "Stolen")
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IBooth booth = booths.Models.First(b => b.BoothId == boothId);
            IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d =>d.Name == delicacyName);

            if (delicacy != null)
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == "Stolen")
            {
                delicacy = new Stolen(delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != "MulledWine" && cocktailTypeName != "Hibernation")
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            IBooth booth = booths.Models
                .First(b => b.BoothId == boothId);

            ICocktail cocktail = booth.CocktailMenu.Models
                .FirstOrDefault(c => c.Name == cocktailName && c.Size == size);

            if (cocktail != null)
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            if (cocktailTypeName == "MulledWine")
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else if (cocktailTypeName == "Hibernation")
            {
                cocktail = new Hibernation(cocktailName, size);
            }

            booth.CocktailMenu.AddModel(cocktail);
            
            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            IEnumerable<IBooth> orderedBooths = booths.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId);

            IBooth booth = orderedBooths.FirstOrDefault();

            //IBooth booth = booths.Models
            //    .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
            //    .OrderBy(b => b.Capacity)
            //    .ThenByDescending(b => b.BoothId)
            //    .FirstOrDefault();

            if (booth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            booth.ChangeStatus();
            
            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orderTokens = order.Split('/', StringSplitOptions.RemoveEmptyEntries);

            string itemTypeName = orderTokens[0];
            string itemName = orderTokens[1];
            int countOfItem = int.Parse(orderTokens[2]);

            if (itemTypeName != "MulledWine" && itemTypeName != "Hibernation" && itemTypeName != "Gingerbread" && itemTypeName != "Stolen")
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            IBooth booth = booths.Models.First(b => b.BoothId == boothId);

            if (itemTypeName == "MulledWine" || itemTypeName == "Hibernation")
            {
                string size = orderTokens[3];

                ICocktail cocktail = booth.CocktailMenu.Models
                    .FirstOrDefault(c => c.Name == itemName);

                if (cocktail == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, itemTypeName, itemName);
                }

                cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == itemName && c.Size == size);

                if (cocktail == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }

                booth.UpdateCurrentBill(cocktail.Price * countOfItem);
            }
            else if (itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
            {
                IDelicacy delicacy = booth.DelicacyMenu.Models.
                    FirstOrDefault(d => d.Name == itemName);

                if (delicacy == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, itemTypeName, itemName);
                }

                booth.UpdateCurrentBill(delicacy.Price * countOfItem);
            }

            return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfItem, itemName);
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Bill {booth.CurrentBill:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");

            booth.Charge();
            booth.ChangeStatus();

            return sb.ToString().TrimEnd();
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);

            return booth.ToString();
        }
    }
}
