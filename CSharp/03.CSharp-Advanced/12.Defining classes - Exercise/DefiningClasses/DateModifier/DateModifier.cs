namespace DefiningClasses
{
    using System;
    public class DateModifier
    {
        public static int CalculateDifferenceInDays(string first, string second)
        {
            string[] firstData = first.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            DateTime firstDateTime = new DateTime(int.Parse(firstData[0]), int.Parse(firstData[1]), int.Parse(firstData[2]));

            string[] secondData = second.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            DateTime secondDateTime = new DateTime(int.Parse(secondData[0]), int.Parse(secondData[1]), int.Parse(secondData[2]));

            return Math.Abs((secondDateTime - firstDateTime).Days);
        }
    }
}