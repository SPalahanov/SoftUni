﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models.Interfaces
{
    public interface IRobot
    {
        string Model { get; }
        string Id { get; }
    }
}
