using System;

namespace TrainingLab
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            int usefulWidth = (int)((width * 100) / 120);
            int usefulHeight = (int)(((height * 100) - 100) / 70);

            int total = (usefulWidth * usefulHeight) - 3;
            Console.WriteLine($"{total}");
        }
    }
}
