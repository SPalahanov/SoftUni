namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Hero
    {
        public Hero(string name, int hp, int mp)
        {
            Name = name;
            HP = hp;
            MP = mp;
        }

        public string Name { get; set; }

        public int HP { get; set; }

        public int MP { get; set; }
    }
    
    
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] heroArguments = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string heroName = heroArguments[0];
                int hitPoints = int.Parse(heroArguments[1]);
                int manaPoints = int.Parse(heroArguments[2]);

                Hero hero = new Hero(heroName, hitPoints, manaPoints);

                heroes[heroName] = hero;
            }

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split(" - ");

                string heroName = arguments[1];

                if (arguments[0] == "CastSpell")
                {
                    int neededMP = int.Parse(arguments[2]);

                    string spellName = arguments[3];

                    if (heroes[heroName].MP >= neededMP)
                    {
                        heroes[heroName].MP -= neededMP;

                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName].MP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }

                if (arguments[0] == "TakeDamage")
                {
                    int damage = int.Parse(arguments[2]);
                    string attacker = arguments[3];

                    heroes[heroName].HP -= damage;

                    if (heroes[heroName].HP > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].HP} HP left!");
                    }
                    else
                    {
                        heroes.Remove(heroName);

                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                }

                if (arguments[0] == "Recharge")
                {
                    int amount = int.Parse(arguments[2]);

                    int maxMpValue = 200;

                    int recoveredAmount;
                    
                    if (heroes[heroName].MP + amount > maxMpValue)
                    {
                        recoveredAmount = maxMpValue - heroes[heroName].MP;

                        heroes[heroName].MP = maxMpValue;
                    }
                    else
                    {
                        recoveredAmount = amount;

                        heroes[heroName].MP += amount;
                    }

                    Console.WriteLine($"{heroName} recharged for {recoveredAmount} MP!");
                }

                if (arguments[0] == "Heal")
                {
                    int amount = int.Parse(arguments[2]);

                    int maxHpValue = 100;

                    int recoveredAmount;

                    if (heroes[heroName].HP + amount > maxHpValue)
                    {
                        recoveredAmount = maxHpValue - heroes[heroName].HP;

                        heroes[heroName].HP = maxHpValue;
                    }
                    else
                    {
                        recoveredAmount = amount;

                        heroes[heroName].HP += amount;
                    }

                    Console.WriteLine($"{heroName} healed for {recoveredAmount} HP!");
                }
            }

            foreach (var hero in heroes)
            {
                Console.WriteLine($"{hero.Key}");

                Console.WriteLine($"  HP: {hero.Value.HP}");

                Console.WriteLine($"  MP: {hero.Value.MP}");
            }
        }
    }
}