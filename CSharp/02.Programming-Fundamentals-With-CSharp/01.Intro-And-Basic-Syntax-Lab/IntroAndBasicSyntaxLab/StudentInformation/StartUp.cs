namespace StudentInformation
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine() 
                ?? throw new InvalidOperationException(nameof(age)));
            double grade = double.Parse(Console.ReadLine()
                ?? throw new InvalidOperationException(nameof(grade)));

            Console.WriteLine($"Name: {name}, Age: {age}, Grade: {grade:F2}");
        }
    }
}
