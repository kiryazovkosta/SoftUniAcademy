namespace Tuple
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = data[0] + " " + data[1];
            string address = data[2];
            var tuple1 = new Tuple<string, string>(name, address);

            data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            name = data[0];
            int liters = int.Parse(data[1]);
            var tuple2 = new Tuple<string, int>(name, liters);

            data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int integer = int.Parse(data[0]);
            double @double = double.Parse(data[1]);
            var tuple3 = new Tuple<int, double>(integer, @double);

            Console.WriteLine(tuple1.ToString());
            Console.WriteLine(tuple2.ToString());
            Console.WriteLine(tuple3.ToString());
        }
    }
}