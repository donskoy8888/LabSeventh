using System;
using System.Collections.Generic;
using System.Linq;

public delegate void TaskExecution<TTask>(TTask task);

class Program
{
    static void Main()
    {
        TaskScheduler<string, int> scheduler = new TaskScheduler<string, int>();
        List<string> completedTasks = new List<string>();

        while (true)
        {
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Execute Next Task");
            Console.WriteLine("3. View Completed Tasks");
            Console.WriteLine("4. Check Current Tasks");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Task: ");
                    string task = Console.ReadLine();

                    Console.Write("Enter Priority: ");
                    if (int.TryParse(Console.ReadLine(), out int priority))
                    {
                        scheduler.AddTask(task, priority);
                        Console.WriteLine("Task added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid priority. Please enter a valid integer.");
                    }
                    break;

                case "2":
                    scheduler.ExecuteNext(t =>
                    {
                        Console.WriteLine($"Executing task: {t}");
                        completedTasks.Add(t);
                    });
                    break;

                case "3":
                    Console.WriteLine("Completed Tasks:");
                    foreach (var completedTask in completedTasks)
                    {
                        Console.WriteLine(completedTask);
                    }
                    break;

                case "4":
                    var currentTasks = scheduler.GetCurrentTasks();
                    Console.WriteLine("Current Tasks:");
                    foreach (var currentTask in currentTasks)
                    {
                        Console.WriteLine(currentTask);
                    }
                    break;

                case "5":
                    Console.WriteLine("Exiting program.");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
