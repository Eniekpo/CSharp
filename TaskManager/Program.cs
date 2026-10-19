class TaskManager {
    static List<string> tasks = new List<string>();
    static List<bool> taskStatus = new List<bool>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Task Manager");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Mark Task as Completed");
            Console.WriteLine("3. View Tasks");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();

switch (choice)
{
    case "1":
        AddTask();
        break;

    case "2":
        CompleteTask();
        break;

    case "3":
        ViewTasks();
        break;

    case "4":
            Environment.Exit(0);
        break;

    default:
        Console.WriteLine("Invalid Choice");
        break;
}
        }
    }

    static void AddTask()
{
    Console.WriteLine("Enter task description:");
    string task = Console.ReadLine();
    tasks.Add(task);
    taskStatus.Add(false);
    Console.WriteLine("Task Added Successfully");
}

static void CompleteTask()
{
    Console.WriteLine("Enter task number to mark as completed:");

    for (int i = 0; i < tasks.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {tasks[i]} - {(taskStatus[i] ? "Completed" : "Pending")}");
    }

    int choice = Convert.ToInt32(Console.ReadLine());
    taskStatus[choice - 1] = true;
    Console.WriteLine("Task Marked as Completed");
}

static void ViewTasks()
{
    for (int i = 0; i < tasks.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {tasks[i]} - {(taskStatus[i] ? "Completed" : "Pending")}");
    }
}
}