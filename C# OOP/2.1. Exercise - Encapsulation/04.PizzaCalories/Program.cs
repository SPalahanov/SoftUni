using PizzaCalories.Models;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaTokens = Console.ReadLine()
                    .Split(" ");

                string[] doughTokens = Console.ReadLine()
                    .Split(" ");

                string pizzaName = pizzaTokens[1];

                Dough dough = new Dough(doughTokens[1], doughTokens[2], double.Parse(doughTokens[3]));

                Models.Pizza pizza = new(pizzaName, dough);

                string toppingsInput;

                while ((toppingsInput = Console.ReadLine()) != "END")
                {
                    string[] toppingTokens = toppingsInput
                        .Split(" ");

                    Topping topping = new Topping(toppingTokens[1], double.Parse(toppingTokens[2]));

                    pizza.AddToping(topping);
                }

                Console.WriteLine(pizza.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                
            }
        }
    }
}