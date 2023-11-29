using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.Models.Interfaces
{
    public interface ISingletonContainer
    {
        public int GetPopulation(string name);
    }
}
