using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Core.Interfaces;
using Telephony.IO.Interfaces;
using Telephony.Models.Interfaces;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        
        
        public void Run()
        {
            string[] numbers = reader.ReadLine()
                .Split(" ");

            string[] websites = reader.ReadLine()
                .Split(" ");

            ICallable phone;

            foreach (var phoneNumber in numbers)
            {
                if (phoneNumber.Length == 10)
                {
                    phone = new Smartphone();
                }
                else
                {
                    phone = new StationaryPhone();
                }

                try
                {
                    writer.WriteLine(phone.Call(phoneNumber));
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            foreach (var url in websites)
            {
                IBrowsable smartPhone = new Smartphone();

                try
                {
                    writer.WriteLine(smartPhone.Browse(url));
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
