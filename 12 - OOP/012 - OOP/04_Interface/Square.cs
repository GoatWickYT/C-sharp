public class Square(double side) : Shape
{
    public double Side { get; set; } = side;

    public override double Area() => Math.Pow(Side, 2);

    public override double Perimeter() => 4 * Side;
}
