using GraphicEditor.Models.Interfaces;

namespace GraphicEditor.Models
{
    public class Square : IShape
    {
        public string Draw()
        {
            return "I'm Square";
        }
    }
}
