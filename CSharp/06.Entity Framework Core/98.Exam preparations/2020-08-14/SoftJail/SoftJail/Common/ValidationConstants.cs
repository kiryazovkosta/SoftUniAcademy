using System;
using System.Collections.Generic;
using System.Text;

namespace SoftJail.Common
{
    public static class ValidationConstants
    {
        public const int PrisonerFullNameMinLength = 3;
        public const int PrisonerFullNameMaxLength = 20;
        public const int PrisonerAgeMin = 18;
        public const int PrisonerAgeMax = 65;
        public const int PrisonerBailMinValue = 0;

        public const int OfficerFullNameMinLength = 3;
        public const int OfficerFullNameMaxLength = 30;
        public const int OfficerSalaryMinValue = 0;

        public const int CellNumberMin = 1;
        public const int CellNumberMax = 1000;

        public const int DepartmentNameMinLength = 3;
        public const int DepartmentNameMaxLength = 25;
    }
}
