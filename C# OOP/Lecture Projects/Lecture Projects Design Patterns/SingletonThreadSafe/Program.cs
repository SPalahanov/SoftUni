namespace SingletonThreadSafe
{
    public class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                new Thread( () =>
                {
                    LoggerUserSingleton.Instance.Name = i.ToString();
                }).Start();
            }
        }
    }

    public class LoggerUserSingleton
    {
        private static LoggerUserSingleton instace;
        private static object lockObject = new object();

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
                    lock (lockObject)
                    {
                        if (instace == null)
                        {
                            instace = new LoggerUserSingleton();
                        }
                    }
                }
                
                return instace;
            }
        }
    }
}