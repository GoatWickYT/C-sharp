public class Rectangle(double sideA, double sideB) : Shape
{
    public double SideA { get; set; } = sideA;
    
    public double SideB { get; set; } = sideB;

    public override double Area() => SideA * SideB;

    public override double Perimeter() => 2 * (SideA + SideB);
}
