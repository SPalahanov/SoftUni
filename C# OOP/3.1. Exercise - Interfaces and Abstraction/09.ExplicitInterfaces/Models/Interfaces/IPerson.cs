﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaces.Models.Interfaces
{
    public interface IPerson
    {
        string Name { get; }
        int Age { get; }

        public string GetName();
    }
}
