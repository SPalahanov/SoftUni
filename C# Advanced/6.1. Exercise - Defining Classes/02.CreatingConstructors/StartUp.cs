﻿namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new("Pesho", 25);

            Console.WriteLine($"{person.Name}: {person.Age}");
            
        }
    }
}