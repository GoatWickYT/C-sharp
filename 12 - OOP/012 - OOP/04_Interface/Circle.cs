public class Circle(double radius)
{
    public double Radius { get; set; } = radius;

    public double Area() => Math.Pow(Radius, 2)* Math.PI;

    public double Perimeter() => 2 * Math.PI * Radius;
}
