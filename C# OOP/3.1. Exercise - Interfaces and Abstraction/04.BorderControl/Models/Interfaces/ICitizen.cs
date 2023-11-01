using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models.Interfaces
{
    public interface ICitizen
    {
        string Name { get; }
        int Age { get; }
        string Id { get; }
    }
}
