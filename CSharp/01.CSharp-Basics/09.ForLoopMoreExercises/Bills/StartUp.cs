using System;

namespace Bills
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int month = int.Parse(Console.ReadLine());
            double totalE = 0;
            double totalW = 0;
            double totalI = 0;
            double totalO = 0;
            double total = 0;
            for (int i = 0; i < month; i++)
            {
                double eBill = double.Parse(Console.ReadLine());
                totalE += eBill;
                double wBill = 20;
                totalW += wBill;
                double iBill = 15;
                totalI += iBill;
                double oBill = (eBill + wBill + iBill) + ((eBill + wBill + iBill) * 0.2);
                totalO += oBill;
                total += eBill + wBill + iBill + oBill;
            }

            Console.WriteLine($"Electricity: {totalE:F2} lv");
            Console.WriteLine($"Water: {totalW:F2} lv");
            Console.WriteLine($"Internet: {totalI:F2} lv");
            Console.WriteLine($"Other: {totalO:F2} lv");
            Console.WriteLine($"Average: {total / month:F2} lv");
        }
    }
}
