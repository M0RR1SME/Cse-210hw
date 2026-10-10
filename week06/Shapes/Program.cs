
class Program
{
    static void Main(string[] args)
    {
            List<Shape> shapes = new List<Shape>
    {
        new Square("Red", 4.0),
        new Rectangle("Blue", 5.0, 3.0),
        new Circle("Green", 2.5)
    };
       
        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area:F2}");
        }
    }
}