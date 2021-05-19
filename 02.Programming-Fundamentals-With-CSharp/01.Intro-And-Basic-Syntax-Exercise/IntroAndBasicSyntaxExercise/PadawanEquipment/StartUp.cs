namespace PadawanEquipment
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double amount = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double robesPrice = studentsCount * robePrice;
            double lightsabersPrice = (studentsCount + Math.Ceiling(studentsCount * 0.1)) * lightsaberPrice;
            double beltsPrice = (studentsCount - (studentsCount / 6)) * beltPrice;
            double totalPrice = robesPrice + lightsabersPrice + beltsPrice;

            if (amount >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalPrice- amount :F2}lv more.");
            }
        }
    }
}
