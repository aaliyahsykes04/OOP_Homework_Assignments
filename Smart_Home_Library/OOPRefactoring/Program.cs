using OOPRefactoring;

partial class Program
{
    static void Main(string[] args)
    {
        IShape circle = new Circle(5);
        IShape rectangle = new Rectangle(4, 6);
        Console.WriteLine($"Area of Circle: {circle.CalculateArea()}");
        Console.WriteLine($"Area of Rectangle: {rectangle.CalculateArea()}");
        ILogger logger = new FileLogger("log.txt");
        logger.Log("Shapes calculated successfully.");
    }
}