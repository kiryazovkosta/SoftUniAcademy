namespace Scheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var tasks = new Stack<int>(input.Split(", ").Select(int.Parse));
            input = Console.ReadLine();
            var threads = new Queue<int>(input.Split(" ").Select(int.Parse));
            input = Console.ReadLine();
            int taskToKill = int.Parse(input);

            int killerThread = 0;
            while (tasks.Count > 0 && threads.Count > 0)
            {
                int task = tasks.Peek();
                int thread = threads.Peek();

                if (taskToKill == task)
                {
                    killerThread = thread;
                    break;
                }


                if (thread >= task)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }

            }

            Console.WriteLine($"Thread with value {killerThread} killed task {taskToKill}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}