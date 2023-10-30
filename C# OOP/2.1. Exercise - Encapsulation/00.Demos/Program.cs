using System.Collections.Specialized;

namespace Demos
{
    public class Program
    {
        static void Main(string[] args)
        {
            Hall hall = new Hall();

            hall.AddRange(new List<string> {"Johnkata", "George"});

            hall.Remove("Johnkata");


        }
    }


    internal class Hall : Stadium
    {
        public void AddRange(List<string> seats)
        {
            foreach (var seat in seats)
            {
                Add(seat);
            }
        }
    }
}