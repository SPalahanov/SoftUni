namespace _04._Snowwhite
{
    internal class Program
    {
        class Dwarf
        {
            public Dwarf(string name, string hatColor, int physics)
            {
                Name = name;
                HatColor = hatColor;
                Physics = physics;
            }

            public string Name { get; set; }

            public string HatColor { get; set; }

            public int Physics { get; set; }

        }

        static void Main(string[] args)
        {
            List<Dwarf> dwarfs = new List<Dwarf>();

            string input;

            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string[] arguments = input.Split(" <:> ");

                string name = arguments[0];
                string hatColor = arguments[1];
                int physics = int.Parse(arguments[2]);

                Dwarf dwarf = new Dwarf(name, hatColor, physics);

                dwarfs.Add(dwarf);
            }
            
            dwarfs = dwarfs
                .OrderByDescending(x => x.Physics)
                .ThenByDescending(d => dwarfs.Count(d2 => d2.HatColor == d.HatColor))
                .ToList();

            List<Dwarf> storedDwarfs = new List<Dwarf>();

            foreach (var dwarf in dwarfs)
            {
                bool exists = storedDwarfs.Exists(d => d.Name == dwarf.Name && d.HatColor == dwarf.HatColor);
                if (exists)
                {
                    Dwarf existingDwarf = storedDwarfs.Find(d => d.Name == dwarf.Name && d.HatColor == dwarf.HatColor);

                    if (existingDwarf.Physics < dwarf.Physics)
                    {
                        storedDwarfs.Remove(existingDwarf);
                        storedDwarfs.Add(dwarf);
                    }
                }
                else
                {
                    storedDwarfs.Add(dwarf);
                }
            }

            foreach (var kvp in storedDwarfs)
            {
                Console.WriteLine($"({kvp.HatColor}) {kvp.Name} <-> {kvp.Physics} ");
            }
        }
    }
}