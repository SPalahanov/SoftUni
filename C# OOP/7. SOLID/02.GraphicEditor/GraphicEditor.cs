using System;
using System.Collections.Generic;
using GraphicEditor.Models;
using GraphicEditor.Models.Interfaces;

namespace Graphic_Editor
{
    public class GraphicEditor
    {
        private List<IShape> shapes;

        public void DrawShape(IShape shape)
        {
            shapes.Add(shape);

            foreach (var shape1 in shapes)
            {
                Console.WriteLine(shape1);
            }
        }
    }
}
