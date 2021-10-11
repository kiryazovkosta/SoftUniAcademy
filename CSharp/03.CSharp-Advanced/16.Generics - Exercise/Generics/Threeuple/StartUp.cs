namespace Threeuple
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = data[0] + " " + data[1];
            string address = data[2];
            string town = string.Empty;
            for (int i = 3; i < data.Length; i++)
            {
                town += data[i] + " ";
            }
            town = town.Trim();
            var threeuple1 = new Threeuple<string, string, string>(name, address, town);


            data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            name = data[0];
            int liters = int.Parse(data[1]);
            bool isDrunk = data[2] == "drunk" ? true : false;
            var threeuple2 = new Threeuple<string, int, bool>(name, liters, isDrunk);


            data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            name = data[0];
            double balance = double.Parse(data[1]);
            string bank = data[2];
            var threeuple3 = new Threeuple<string, double, string>(name, balance, bank);


            Console.WriteLine(threeuple1.ToString());
            Console.WriteLine(threeuple2.ToString());
            Console.WriteLine(threeuple3.ToString());
        }
    }
}
