public class Repository<T>
{
    private List<T> elements;

    public Repository()
    {
        elements = new List<T>();
    }

    public delegate bool Criteria<T>(T item);

    public List<T> Find(Criteria<T> criteria)
    {
        List<T> result = new List<T>();

        foreach (T item in elements)
        {
            if (criteria(item))
            {
                result.Add(item);
            }
        }

        return result;
    }

    public void Add(T item)
    {
        elements.Add(item);
    }

    public void Remove(T item)
    {
        elements.Remove(item);
    }
}