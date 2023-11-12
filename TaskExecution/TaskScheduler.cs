public class TaskScheduler<TTask, TPriority>
{
    private SortedDictionary<TPriority, Queue<TTask>> taskQueue = new SortedDictionary<TPriority, Queue<TTask>>();

    public void AddTask(TTask task, TPriority priority)
    {
        if (!taskQueue.ContainsKey(priority))
        {
            taskQueue[priority] = new Queue<TTask>();
        }

        taskQueue[priority].Enqueue(task);
    }

    public void ExecuteNext(TaskExecution<TTask> executeTask)
    {
        if (taskQueue.Count > 0)
        {
            var highestPriority = taskQueue.Keys.Max();
            var nextTask = taskQueue[highestPriority].Dequeue();

            executeTask(nextTask);

            if (taskQueue[highestPriority].Count == 0)
            {
                taskQueue.Remove(highestPriority);
            }
        }
        else
        {
            Console.WriteLine("No tasks to execute.");
        }
    }

    public IEnumerable<TTask> GetCurrentTasks()
    {
        return taskQueue.Values.SelectMany(queue => queue);
    }
}