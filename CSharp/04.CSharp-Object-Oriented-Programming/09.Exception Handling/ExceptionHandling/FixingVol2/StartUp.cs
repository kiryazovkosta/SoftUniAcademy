namespace FixingVol2
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int firstNumber, secondNumber;
            byte result;

            firstNumber = 30;
            secondNumber = 60;
            try
            {
                result = Convert.ToByte(firstNumber * secondNumber);
                Console.WriteLine($"{firstNumber} x {secondNumber} = {result}");
            }
            catch (OverflowException exception)
            {
                Console.WriteLine(exception.Message);
            }
            
            Console.ReadLine();
        }
    }
}