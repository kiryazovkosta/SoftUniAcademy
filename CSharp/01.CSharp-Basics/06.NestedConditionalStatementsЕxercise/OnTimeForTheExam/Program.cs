namespace OnTimeForTheExam
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int myHour = int.Parse(Console.ReadLine());
            int myMinutes = int.Parse(Console.ReadLine());

            int examTotalMinutes = examHour * 60 + examMinutes;
            int myTotalMinutes = myHour * 60 + myMinutes;
            if (myTotalMinutes > examTotalMinutes)
            {
                Console.WriteLine("Late");
                int diff = myTotalMinutes - examTotalMinutes;
                if (diff >= 60)
                {
                    int diffHours = diff / 60;
                    int diffMinutes = diff % 60;
                    Console.WriteLine($"{diffHours}:{diffMinutes:D2} hours after the start");
                } 
                else
                {
                    Console.WriteLine($"{diff} minutes after the start");
                }

            }
            else if (myTotalMinutes < examTotalMinutes)
            {
                int diff = examTotalMinutes - myTotalMinutes;
                if (diff <= 30)
                {
                    Console.WriteLine("On time");
                    Console.WriteLine($"{diff} minutes before the start");
                }
                else
                {
                    Console.WriteLine("Early");
                    if (diff >= 60)
                    {
                        int diffHours = diff / 60;
                        int diffMinutes = diff % 60;
                        Console.WriteLine($"{diffHours}:{diffMinutes:D2} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{diff} minutes before the start");
                    }
                }
            }
            else
            {
                Console.WriteLine("On time");
            }
        }
    }
}
