namespace LowerOrUpper
{
    using System;
    public class LowerOrUpperMain
    {
        public static void Main(string[] args)
        {
            char c = Convert.ToChar(Console.ReadLine());
            if (Char.IsLower(c))
            {
                Console.WriteLine("lower-case");
            }
            else
            {
                Console.WriteLine("upper-case");
            }
        }
    }
}
