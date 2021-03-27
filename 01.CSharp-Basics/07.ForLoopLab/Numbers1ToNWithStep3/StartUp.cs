namespace Numbers1ToNWithStep3
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i+=3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
