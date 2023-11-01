using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorderControl.Models.Interfaces;

namespace BorderControl.Models
{
    public class Robot : IRobot
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }
        
        public string Model { get; }
        public string Id { get; }
    }
}
