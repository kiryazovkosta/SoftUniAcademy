namespace PrintPartOfASCIITable
{
    using System;
    public class PrintPartOfASCIITableMain
    {
        public static void Main(string[] args)
        {
            int startIndex = int.Parse(Console.ReadLine());
            int endIndex = int.Parse(Console.ReadLine());
            for (int index = startIndex; index <= endIndex; index++)
            {
                char symbol = (char)index;
                Console.Write($"{symbol} ");
            }
        }
    }
}
