namespace Singleton
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Who are you?");

            string name = Console.ReadLine();

            LoggerUserSingleton loggedUser = LoggerUserSingleton.Instance;
            LoggerUserSingleton.Instance.Name = name;
            Console.WriteLine($"{LoggerUserSingleton.Instance.Name} is logged in!");
        }
    }

    class LoggerUserSingleton
    {
        private static LoggerUserSingleton instace;

        private LoggerUserSingleton()
        {
            Console.WriteLine("Logger user created!");
        }

        public string Name { get; set; }

        public static LoggerUserSingleton Instance
        {
            get
            {
                if (instace == null)
                {
                    instace = new LoggerUserSingleton();
                }

                return instace;
            }
        }
    }
}