namespace OOP_SOLID_Principles.OCP_AreaOfShape
{       
    public abstract class Shape{       
        public abstract int ShapeArea();
    }

    public class Rectangle : Shape
    {
        private int Length;
        private int Width;

        public Rectangle(int length, int width)
        {
            Length = length;
            Width = width;
        }

        public override int ShapeArea()
        {
            return Width * Length;
        }
    }

    public class Circle : Shape
    {
        private double Radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override int ShapeArea()
        {
            return Convert.ToInt32(Math.PI * Math.Sqrt(Radius));
        }
    }

    public class GetShape{
        private Shape _shape;

        public GetShape(Shape shape)
        {
           _shape = shape;
        }

        public void CalculateArea(){
            Console.WriteLine(_shape.ShapeArea());
        }
    }
}
