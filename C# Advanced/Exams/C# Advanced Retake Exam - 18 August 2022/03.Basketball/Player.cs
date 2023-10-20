using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Basketball
{
    public class Player
    {
        //private string name;
        //private string position;
        //private double rating;
        //private int games;

        public Player(string name, string position, double rating, int games)
        {
            Name = name;
            Position = position;
            Rating = rating;
            Games = games;

        }

        public string Name { get; private set; }
        public string Position { get; private set; }
        public double Rating { get; private set; }
        public int Games { get; private set; }

        public bool Retired { get; set; } = false;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"-Player: {this.Name}");
            sb.AppendLine($"--Position: {this.Position}");
            sb.AppendLine($"--Rating: {this.Rating}");
            sb.AppendLine($"--Games played: {this.Games}");
            return sb.ToString().TrimEnd();
        }
    }
}
