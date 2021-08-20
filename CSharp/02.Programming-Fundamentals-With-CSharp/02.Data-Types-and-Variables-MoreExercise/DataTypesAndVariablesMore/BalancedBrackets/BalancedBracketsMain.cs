namespace BalancedBrackets
{
    using System;

    public class BalancedBracketsMain
    {
        public static void Main(string[] args)
        {
            int linesNumber = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(linesNumber)));

            int openCounter = 0;
            int closeCounter = 0;
            bool isBalanced = true;

            for (int i = 1; i <= linesNumber; i++)
            {
                string input = Console.ReadLine();
                if (input == "(")
                {
                    openCounter++;
                    if (openCounter - closeCounter > 1)
                    {
                        isBalanced = false;
                        break;
                    }
                }
                else if (input == ")")
                {
                    closeCounter++;

                    if (openCounter - closeCounter != 0)
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            Console.WriteLine(isBalanced && openCounter == closeCounter ? "BALANCED" : "UNBALANCED");
        }
    }
}
