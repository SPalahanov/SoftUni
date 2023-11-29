using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.Shapes
{
    public class Text : Shape
    {
        public Text(Position position, string text) : base(position)
        {
            text = text;
        }

        public int text { get; set; }

        public override void Draw()
        {
            base.Draw();

            SetCoursorPosition();

            Console.WriteLine(text);
        }
    }
}
