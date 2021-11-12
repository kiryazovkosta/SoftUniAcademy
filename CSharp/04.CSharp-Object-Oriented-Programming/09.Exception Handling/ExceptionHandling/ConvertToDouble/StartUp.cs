namespace ConvertToDouble
{
    using System;
    public  class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string input = Console.ReadLine();
                double value = Convert.ToDouble(input);
                Console.WriteLine(value);

                double d = double.MaxValue * double.MaxValue;
                Console.WriteLine(d);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
        }
    }
}
