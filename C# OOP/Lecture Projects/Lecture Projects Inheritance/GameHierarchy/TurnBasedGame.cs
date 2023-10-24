using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHierarchy
{
    public class TurnBasedGame : MultiplayerGame
    {
        public Player PlayerOnMove { get; set; }
    }
}
