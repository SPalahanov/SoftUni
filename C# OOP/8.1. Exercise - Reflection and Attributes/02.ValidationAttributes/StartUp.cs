using System;
using System.ComponentModel.DataAnnotations;
using ValidationAttributes.Models;
using ValidationAttributes.Utils;
using Validator = ValidationAttributes.Utils.Validator;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person(null, -1);
            
            Console.WriteLine(Validator.IsValid(person));
        }
    }
}
