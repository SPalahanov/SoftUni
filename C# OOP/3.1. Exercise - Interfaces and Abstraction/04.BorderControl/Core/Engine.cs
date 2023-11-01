using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorderControl.Core.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<string> rebellions = new List<string>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];

                    ICitizen citizen = new Citizen(name, age, id);

                    rebellions.Add(citizen.Id);

                }
                else
                {
                    string model = tokens[0];
                    string id = tokens[1];

                    IRobot robot = new Robot(model, id);
                    
                    rebellions.Add(robot.Id);
                }
            }

            string lastIdDigits = Console.ReadLine();

            foreach (var rebellion in rebellions)
            {
                if (rebellion.EndsWith(lastIdDigits))
                {
                    Console.WriteLine(rebellion);
                }
            }
        }
    }
}
