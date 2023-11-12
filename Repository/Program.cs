using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Repository<int> intRepository = new Repository<int>();

        intRepository.Add(1);
        intRepository.Add(2);
        intRepository.Add(3);
        intRepository.Add(4);
        intRepository.Add(5);

        Repository<int>.Criteria<int> evenCriteria = x => x % 2 == 0;

        List<int> evenNumbers = intRepository.Find(evenCriteria);

        Console.WriteLine("Even Numbers:");
        foreach (int num in evenNumbers)
        {
            Console.WriteLine(num);
        }
    }
}