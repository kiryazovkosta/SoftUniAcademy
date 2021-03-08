namespace Projects
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int projectsCount = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double compliteHours = projectsCount * 3;
            Console.WriteLine($"The architect {name} will need {compliteHours} hours to complete {projectsCount} project/s.");
        }
    }
}
