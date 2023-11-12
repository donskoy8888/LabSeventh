public class Calculator<T>
{
    public delegate T AddDelegate(T x, T y);
    public delegate T SubtractDelegate(T x, T y);
    public delegate T MultiplyDelegate(T x, T y);
    public delegate T DivideDelegate(T x, T y);

    private AddDelegate Addition;
    private SubtractDelegate Subtraction;
    private MultiplyDelegate Multiplycation;
    private DivideDelegate Division;

    public Calculator()
    {
        Addition = (x, y) => (dynamic)x + y;
        Subtraction = (x, y) => (dynamic)x - y;
        Multiplycation = (x, y) => (dynamic)x * y;
        Division = (x, y) => (dynamic)x / y;
    }

    public T Add(T x, T y)
    {
        return Addition(x, y);
    }

    public T Subtract(T x, T y)
    {
        return Subtraction(x, y);
    }

    public T Multiply(T x, T y)
    {
        return Multiplycation(x, y);
    }

    public T Divide(T x, T y)
    {
        return Division(x, y);
    }
}