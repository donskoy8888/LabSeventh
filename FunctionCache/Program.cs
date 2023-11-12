using System;
using System.Collections.Generic;


class Program
{
    public static void Main()
    {
        FunctionCache<int, string> cache = new FunctionCache<int, string>();

        FunctionCache<int, string>.FuncDelegate myFunction = (key) =>
        {
            Console.WriteLine($"Executing function for key {key}");
            return $"Result for key {key}";
        };

        cache.ClearCache();

        string result1 = cache.GetOrAdd(1, myFunction, TimeSpan.FromMinutes(5));
        Console.WriteLine(result1);

        string result2 = cache.GetOrAdd(1, myFunction, TimeSpan.FromMinutes(5));
        Console.WriteLine(result2);

        cache.ClearCache();

        string result3 = cache.GetOrAdd(2, myFunction, TimeSpan.FromMinutes(5));
        Console.WriteLine(result3);
    }
}
