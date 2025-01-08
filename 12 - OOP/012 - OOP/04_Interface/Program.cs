Shape shape = new Square(10);
PrintShape(shape);
shape = new Rectangle(10, 20);
PrintShape(shape);

// IShape circle = new Circle(10); Error

void PrintShape(IShape shape)
{
    switch (shape)
    {
        case Square:
            Console.WriteLine("\nSquare");
            Console.WriteLine(shape);
            break;
        case Rectangle:
            Console.WriteLine("\nRectangle");
            Console.WriteLine(shape);
            break;
        default:
            Console.WriteLine("unknown");
            break;
    }
}