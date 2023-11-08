using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raiding.Models.Interfaces;

namespace Raiding.Fabric.Interfaces
{
    public interface IHeroFactory
    {
        IBaseHero Create(string type, string name);
    }
}
