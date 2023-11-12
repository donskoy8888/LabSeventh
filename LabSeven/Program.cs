
class Program
{
    public static void Main()
    {
        int x = 10;
        int y = 20;

        Calculator<int> calculator = new Calculator<int>();

        int sum = calculator.Add(x, y);
        int difference = calculator.Subtract(x, y);
        int product = calculator.Multiply(x, y);
        int quotient = calculator.Divide(x, y);

        Console.WriteLine("Sum: {0}", sum);
        Console.WriteLine("Difference: {0}", difference);
        Console.WriteLine("Product: {0}", product);
        Console.WriteLine("Quotient: {0}", quotient);
    }
}

