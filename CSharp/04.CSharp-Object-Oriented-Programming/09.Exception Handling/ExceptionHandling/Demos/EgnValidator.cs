namespace Demos
{
    using System.Text;
    using System.Text.RegularExpressions;

    public class EgnValidator : IEgnValidator
    {
        public bool Validate(string egn)
        {
            if (egn == null || egn.Length != 10 || !Regex.IsMatch(egn, "[0-9]{10}"))
            {
                return false;
            }

            int year = int.Parse(egn.Substring(0, 2));
            int month = int.Parse(egn.Substring(2, 2));
            if (!IsEgnMonthValid(month))
            {
                return false;
            }

            int day = int.Parse(egn.Substring(4, 2));
            if (!IsEgnDayValid(day, year, month))
            {
                return false;
            }

            if (!IsEgnCheckSumValid(egn))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="birthDate"></param>
        /// <param name="city"></param>
        /// <param name="isMale"></param>
        /// <param name="count">Number of generated egn. Default value is 5.</param>
        /// <returns></returns>
        /// <exception cref="InvalidCityException"></exception>
        public string[] Generate(DateTime birthDate, string city, bool isMale, int count = 5)
        {
            if (birthDate.Year < 1800 || birthDate.Year  > 2099)
            {
                throw new ArgumentOutOfRangeException(nameof(birthDate));
            }

            if (string.IsNullOrWhiteSpace(city))
            {
                throw new InvalidCityException();
            }

            var egns = new List<string>();
            while (egns.Count <= count)
            {
                var egn = GenerateEgn(birthDate, city, isMale);
                if (!egns.Contains(egn))
                {
                    egns.Add(egn);
                }
            }

            return egns.ToArray();
        }

        private string GenerateEgn(DateTime birthDate, string city, bool isMale)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(birthDate.Year % 100);
            sb.Append(GetMonth(birthDate));
            sb.Append($"{birthDate.Day:D2}");
            sb.Append(GetCityCode(city, isMale));
            var current = sb.ToString();
            sb.Append(CalculatedChecksum(current).ToString());
            return sb.ToString();
        }

        private string GetCityCode(string city, bool isMale)
        {
            int min = 0;
            int max = 0;
            switch (city)
            {
                case "Благоевград": min = 000; max = 043; break;
                case "Бургас": min = 044; max = 093; break;
                case "Варна": min = 094; max = 139; break;
                case "Велико Търново":  min = 140; max = 169; break;
                case "Видин": min = 170; max = 183; break;
                case "Враца": min = 184; max = 217; break;
                case "Габрово": min = 218; max = 233; break;
                case "Кърджали": min = 234; max = 281; break;
                case "Кюстендил": min = 282; max = 301; break;
                case "Ловеч": min = 302; max = 319; break;
                case "Монтана": min = 320; max = 341; break;
                case "Пазарджик": min = 342; max = 377; break;
                case "Перник": min = 378; max = 395; break;
                case "Плевен": min = 396; max = 435; break;
                case "Пловдив": min = 436; max = 501; break;
                case "Разград": min = 502; max = 527; break;
                case "Русе": min = 528; max = 555; break;
                case "Силистра": min = 556; max = 575; break;
                case "Сливен": min = 576; max = 601; break;
                case "Смолян": min = 602; max = 623; break;
                case "София – град": min = 624; max = 721; break;
                case "София – окръг": min = 722; max = 751; break;
                case "Стара Загора":    min = 752; max = 789; break;
                case "Добрич":   min = 790; max = 821; break;
                case "Търговище": min = 822; max = 843; break;
                case "Хасково": min = 844; max = 871; break;
                case "Шумен": min = 872; max = 903; break;
                case "Ямбол": min = 904; max = 925; break;
                default: min = 926; max = 999; break;
            }

            var divider = isMale ? 2 : 1;

            Random random = new Random();
            int cityCode = random.Next(min, max);
            while (cityCode % divider != 0)
            {
                cityCode = random.Next(min, max);
            }

            return cityCode.ToString("D3");
        }

        private string GetMonth(DateTime birthDate)
        {
            int month = birthDate.Month;
            if (birthDate.Year >= 2000)
            {
                month += 40;
            }
            else if (birthDate.Year <= 1899)
            {
                month += 20;
            }

            return month.ToString("D2");
        }

        private int CalculatedChecksum(string egn)
        {
            int digitsSum = 0;
            for (int i = 0; i < egn.Length; i++)
            {
                int digit = int.Parse(egn[i].ToString());
                if (i == 0)
                {
                    digitsSum += digit * 2;
                }
                else if (i == 1)
                {
                    digitsSum += digit * 4;
                }
                else if (i == 2)
                {
                    digitsSum += digit * 8;
                }
                else if (i == 3)
                {
                    digitsSum += digit * 5;
                }
                else if (i == 4)
                {
                    digitsSum += digit * 10;
                }
                else if (i == 5)
                {
                    digitsSum += digit * 9;
                }
                else if (i == 6)
                {
                    digitsSum += digit * 7;
                }
                else if (i == 7)
                {
                    digitsSum += digit * 3;
                }
                else if (i == 8)
                {
                    digitsSum += digit * 6;
                }
            }

            int remainder = digitsSum % 11;
            return remainder < 10 ? remainder : 0;
        }

        private bool IsEgnCheckSumValid(string egn)
        {
            int calculatedChecksum = CalculatedChecksum(egn);
            int egnChecksum = int.Parse(egn.Substring(9, 1));
            return calculatedChecksum == egnChecksum;
        }

        private bool IsEgnDayValid(int day, int year, int month)
        {
            int fullYear = 0;
            int realMonth = 0;
            if (month >= 1 && month <= 12)
            {
                fullYear = year + 1900;
                realMonth = month;
            }
            else if (month >= 21 && month <= 32)
            {
                fullYear = year + 1800;
                realMonth = month - 20;
            }
            else if (month >= 41 && month <= 52)
            {
                fullYear = year + 2000;
                realMonth = month - 40;
            }

            int daysInMonth = DateTime.DaysInMonth(fullYear, realMonth);
            return day >= 1 && day <= daysInMonth;
        }

        private bool IsEgnMonthValid(int month)
        {
            if (month >= 1 && month <= 12)
            {
                return true;
            }
            else if (month >= 21 && month <= 32)
            {
                return true;
            }
            else if (month >= 41 && month <= 52)
            {
                return true;
            }

            return false;
        }

        private bool IsEgnYearValid(int year)
        {
            return year >= 0 && year <= 99;
        }
    }
}