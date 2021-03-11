namespace TimePlusFifteenMinutes
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int minutes = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            var totalMinutes = (hours * 60) + minutes + 15;
            var dayMinutes = 24 * 60;
            if (totalMinutes > dayMinutes )
            {
                totalMinutes = totalMinutes - dayMinutes;
            }

            int newHour = totalMinutes / 60;
            int newMinutes = totalMinutes % 60;

            if (newHour == 24)
            {
                newHour = 0;
            }

            if (newMinutes < 10)
            {
                Console.WriteLine($"{newHour}:0{newMinutes}");
            }
            else
            {
                Console.WriteLine($"{newHour}:{newMinutes}");
            }
        }
    }
}
