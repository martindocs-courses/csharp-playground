
namespace OOP_Polymorphism.Shape_Area_Calculator
{
    public interface Shape{

        public string CalculateArea();
    }

    public class Circle : Shape
    {
        private const double PI = 3.14;
        private int Radius { get; set; }

        public Circle(int radius)
        {
            Radius = radius;
        }

        public string CalculateArea() => $"Area of circle: {PI * (Radius * Radius)} m2";
    }

    public class Rectangle : Shape
    {
        private int Length { get; set; }
        private int Width { get; set; }

        public Rectangle(int length, int width)
        {
            Length = length;
            Width = width;
        }
        public string CalculateArea() => $"Area of rectangular: {Length * Width} m2";
    }
}
