namespace SquareRoot
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine() ?? string.Empty;
            try
            {
                int number = int.Parse(input);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Goodbye");
            }
        }
    }
}