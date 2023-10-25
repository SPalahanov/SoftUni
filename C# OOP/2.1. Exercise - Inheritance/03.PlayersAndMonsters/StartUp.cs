namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero("Slavi", 25);
            Wizard wiz1 = new Wizard("Pesho", 45);
            BladeKnight bn1 = new BladeKnight("Ivan", 15);

            Console.WriteLine(hero.ToString());
            Console.WriteLine(wiz1.ToString());
            Console.WriteLine(bn1.ToString());
        }
    }
}