// ------------------------------------------------------------------------------------------------
//  <copyright file="Bonuses.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace BonusScoringSystem
{
    #region Using

    using System;

    #endregion

    public class Bonuses
    {
        private static void Main(string[] args)
        {
            double maxBonus = 0;
            double maxAttendances = 0;

            int students = int.Parse(Console.ReadLine());
            int lectures = int.Parse(Console.ReadLine());
            int initBonus = int.Parse(Console.ReadLine());
            for (int i = 1; i <= students; i++)
            {
                double attendances = double.Parse(Console.ReadLine());
                double bonus = (attendances / lectures * (5 + initBonus));
                if (bonus >= maxBonus)
                {
                    maxBonus = bonus;
                    maxAttendances = attendances;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {(int)maxAttendances} lectures.");
        }
    }
}