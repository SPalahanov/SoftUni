using Prototype.Models;

namespace Prototype
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SandwichMenu sandwichMenu= new SandwichMenu();

            //Initialize with default sandwiches
            sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
            sandwichMenu["PB&J"] = new Sandwich("White", "", "", "Peanut Butter, Jelly");
            sandwichMenu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");

            //Deli manager adds custom sandwiches
            sandwichMenu["LoadedBLT"] = new Sandwich("Wheat", "Turkey, Bacon", "American", "Lettuce, Tomato, Onion, Olives");
            sandwichMenu["ThreeMeatCombo"] = new Sandwich("Rye", "Turkey, Ham, Salami", "Provolone", "Lettuce, Onion");
            sandwichMenu["Vegetarian"] = new Sandwich("Wheat", "", "", "Lettuce, Onion, Tomato, Olives, Spinach");

            //Clone these sandwiches
            Sandwich sandwich1 = sandwichMenu["LoadedBLT"] as Sandwich;
            Sandwich sandwich2 = sandwichMenu["ThreeMeatCombo"] as Sandwich;
            Sandwich sandwich3 = sandwichMenu["Vegetarian"] as Sandwich;

            sandwich1.Price.Add(123);
        }
    }
}