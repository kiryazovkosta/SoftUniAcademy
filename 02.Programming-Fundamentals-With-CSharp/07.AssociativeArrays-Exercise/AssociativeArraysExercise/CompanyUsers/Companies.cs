namespace CompanyUsers
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    internal class Companies
    {
        private static void Main(string[] args)
        {
            var companies = new Dictionary<string, List<string>>();

            var input = Console.ReadLine();
            while (input != "End")
            {
                var data = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                var company = data[0];
                var employee = data[1];

                if (companies.ContainsKey(company) == false)
                {
                    companies.Add(company, new List<string>());
                }

                if (companies[company].Contains(employee) == false)
                {
                    companies[company].Add(employee);
                }

                input = Console.ReadLine();
            }

            foreach (var company in companies.OrderBy(c => c.Key))
            {
                Console.WriteLine(company.Key);
                foreach (var employee in company.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}