using GraphicEditor.Models.Interfaces;

namespace GraphicEditor.Models
{
    public class Circle : IShape
    {
        public string Draw()
        {
            return "I'm Circle";
        }
    }
}
