using System;
using System.Collections.Generic;
using System.Text;

namespace Footballers.Common
{
    public static class GlobalConstants
    {
        public const int CoachNameMinLength = 2;
        public const int CoachNameMaxLength = 40;
        public const string CoachXmlType = "Coach";
        public const string CoachXmlEmlementName = "Name";
        public const string CoachXmlEmlementNationality = "Nationality";
        public const string CoachXmlArrayFootballers = "Footballers";


        public const int FootballerNameMinLength = 2;
        public const int FootballerNameMaxLength = 40;
        public const string FootballerDateFormat = @"dd/MM/yyyy";
        public const int FootballerPositionTypeMinValue = 0;
        public const int FootballerPositionTypeMaxValue = 3;
        public const int FootballerBestSkillTypeTypeMinValue = 0;
        public const int FootballerBestSkillTypeTypeMaxValue = 4;

        public const int TeamNameMinLength = 3;
        public const int TeamNameMaxLength = 40;
        public const int TeamNationalityMinLength = 3;
        public const int TeamNationalityMaxLength = 40;
    }
}
