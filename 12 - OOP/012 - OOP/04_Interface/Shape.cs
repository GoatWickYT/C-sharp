public abstract class Shape : IShape
{
    public abstract double Area();

    public abstract double Perimeter();

    public override string ToString()
    {
        return $"Area: {Area()}\nPerimeter: {Perimeter()}";
    }
}
