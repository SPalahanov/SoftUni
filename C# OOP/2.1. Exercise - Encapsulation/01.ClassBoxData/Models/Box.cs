using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoxData.Models
{
    public class Box
    {
        private const string PropertyZeroOrNegativeExceptionMessage = "{0} cannot be zero or negative.";


        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PropertyZeroOrNegativeExceptionMessage, nameof(Length)));
                }

                length = value;
            }
        }

        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PropertyZeroOrNegativeExceptionMessage, nameof(Width)));
                }

                width = value;
            }
        }

        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PropertyZeroOrNegativeExceptionMessage, nameof(Height)));
                }

                height = value;
            }
        }

        public double SurfaceArea() => 2 * length * width + LateralSurfaceArea();

        public double LateralSurfaceArea() => 2 * Height * Length + 2 * Height * Width;

        public double Volume() => Length * Height * Width;
    }
}
