namespace Salary
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int facebookPrice = 150;
            int instagramPrice = 100;
            int redditPrice = 100;

            int tabsSize = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            for (int i = 0; i < tabsSize; i++)
            {
                string name = Console.ReadLine();
                switch (name)
                {
                    case "Facebook":
                        salary -= facebookPrice;
                        break;

                    case "Instagram":
                        salary -= instagramPrice;
                        break;

                    case "Reddit":
                        salary -= redditPrice;
                        break;

                    default:
                        break;
                }

                if (salary <= 0)
                {
                    break;
                }
            }

            if (salary > 0)
            {
                Console.WriteLine(salary);
            }
            else
            {
                Console.WriteLine("You have lost your salary.");
            }
        }
    }
}
