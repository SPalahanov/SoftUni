﻿namespace Recharge.Models
{
    using System;
    using Recharge.Models.Interfaces;

    public class Employee : Worker, ISleeper
    {
        public Employee(string id) : base(id)
        {
        }

        public void Sleep()
        {
            // sleep...
        }
    }
}
