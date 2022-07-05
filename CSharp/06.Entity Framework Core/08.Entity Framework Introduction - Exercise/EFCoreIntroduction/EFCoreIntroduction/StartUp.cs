using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SoftUniContext();
            //// 03. Employees Full Information
            //var employees = GetEmployeesFullInformation(context);
            //Console.WriteLine(employees);

            //// 04. Employees with Salary Over 50 000
            //var employees = GetEmployeesWithSalaryOver50000(context);
            //Console.WriteLine(employees);

            //// 05. Employees from Research and Development
            //var employees = GetEmployeesFromResearchAndDevelopment(context);
            //Console.WriteLine(employees);

            //// 06. Adding a New Address and Updating Employee
            //var addressesText = AddNewAddressToEmployee(context);
            //Console.WriteLine(addressesText);

            //// 07.Employees and Projects
            //var employees = GetEmployeesInPeriod(context);
            //Console.WriteLine(employees);

            //// 08. Addresses by Town
            //var addresses = GetAddressesByTown(context);
            //Console.WriteLine(addresses);

            //// 09. Employee 147
            //var emplyeeWithProjects = GetEmployee147(context);
            //Console.WriteLine(emplyeeWithProjects);

            //// 10. Departments with More Than 5 Employees
            //var departments = GetDepartmentsWithMoreThan5Employees(context);
            //Console.WriteLine(departments);

            //// 11. Find Latest 10 Projects
            //var projects = GetLatestProjects(context);
            //Console.WriteLine(projects);

            //// 12. Increase Salaries
            //var employees = IncreaseSalaries(context);
            //Console.WriteLine(employees);

            //// 13. Find Employees by First Name Starting With Sa
            //var employees = GetEmployeesByFirstNameStartingWithSa(context);
            //Console.WriteLine(employees);

            //// 14. Delete Project by Id
            //var projects = DeleteProjectById(context);
            //Console.WriteLine(projects);

            // 15. Remove Town
            var removedMessage = RemoveTown(context);
            Console.WriteLine(removedMessage);
        }

        /// <summary>
        /// Now we can use SoftUniContext to extract data from our database. Your first task is to extract all employees 
        /// and return their first, last and middle name, their job title and salary, rounded to 2 symbols after the decimal separator, 
        /// all of those separated with a space. Order them by employee id.
        /// </summary>
        /// <param name="context">DbContext</param>
        /// <returns></returns>
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var output = new StringBuilder();
            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .ToList();
            foreach (var employee in employees)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return output.ToString();
        }

        /// <summary>
        /// Your task is to extract all employees with salary over 50000. Return their first names and salaries in format "{firstName} - {salary}".
        /// Salary must be rounded to 2 symbols, after the decimal separator. Sort them alphabetically by first name.
        /// </summary>
        /// <param name="context">DbContext</param>
        /// <returns></returns>
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var output = new StringBuilder();
            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();
            foreach (var employee in employees)
            {
                output.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return output.ToString();
        }

        /// <summary>
        /// Extract all employees from the Research and Development department. Order them by salary (in ascending order), 
        /// then by first name (in descending order). Return only their first name, last name, department name and salary 
        /// rounded to 2 symbols, after the decimal separator.
        /// </summary>
        /// <param name="context">DbContext</param>
        /// <returns></returns>
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var output = new StringBuilder();
            var employees = context.Employees
                .Include(e => e.Department)
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)

                .ToList();
            employees.ForEach(e => output.AppendLine($"{e.FirstName} {e.LastName} from {e.Name} - ${e.Salary:F2}"));
            return output.ToString();
        }

        /// <summary>
        /// Create a new address with the text "Vitoshka 15" and TownId 4. 
        /// Set that address to the employee with last the name "Nakov".
        /// Then order by descending all the employees by their Address' Id, 
        /// take 10 rows and from them, take the AddressText. Return the results each on a new line
        /// </summary>
        /// <param name="context">DbContext</param>
        /// <returns></returns>
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var output = new StringBuilder();

            var address = new Address() { AddressText = "Vitoshka 15", TownId = 4 };
            var employee = context.Employees.First(e => e.LastName == "Nakov");
            employee.Address = address;
            context.SaveChanges();

            var addresses = context.Employees.OrderByDescending(e => e.AddressId).Take(10).Select(e => e.Address.AddressText).ToList();
            addresses.ForEach(a => output.AppendLine(a));

            return output.ToString();
        }

        /// <summary>
        /// Find the first 10 employees who have projects started in the period 2001 - 2003 (inclusive). 
        /// Print each employee's first name, last name, manager's first name and last name. 
        /// Then return all of their projects in the format "--<ProjectName> - <StartDate> - <EndDate>", each on a new row. 
        /// If a project has no end date, print "not finished" instead.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var output = new StringBuilder();
            var employees = context.Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 &&
                                                    ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    AllProjects = e.EmployeesProjects.Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                        EndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished"
                    })
                })
                .ToList();

            foreach (var e in employees)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
                foreach (var p in e.AllProjects)
                {
                    output.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }

            return output.ToString();
        }

        /// <summary>
        /// Find all addresses, ordered by the number of employees who live there (descending), 
        /// then by town name (ascending) and finally by address text (ascending). Take only the first 10 addresses. 
        /// For each address return it in the format "<AddressText>, <TownName> - <EmployeeCount> employees"
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var output = new StringBuilder();
            var addresses = context.Addresses
                .Include(a => a.Town)
                .OrderByDescending(a => a.Employees.Count())
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    AddressText = a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count()
                })
                .ToList();

            addresses.ForEach(a => output.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeeCount} employees"));
            return output.ToString();
        }

        /// <summary>
        /// Get the employee with id 147. Return only his/her first name, last name, job title and projects (print only their names). 
        /// The projects should be ordered by name (ascending).
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetEmployee147(SoftUniContext context)
        {
            var output = new StringBuilder();
            var employee = context.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .First(e => e.EmployeeId == 147);
            output.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (var project in employee.EmployeesProjects.OrderBy(p => p.Project.Name))
            {
                output.AppendLine($"{project.Project.Name}");
            }

            return output.ToString();
        }

        /// <summary>
        /// Find all departments with more than 5 employees. 
        /// Order them by employee count (ascending), then by department name (alphabetically). 
        /// For each department, print the department name and the manager's first and last name on the first row. 
        /// Then print the first name, the last name and the job title of every employee on a new row.Order the employees by first name(ascending), then by last name(ascending).
        /// Format of the output: For each department print it in the format 
        /// "<DepartmentName> - <ManagerFirstName>  <ManagerLastName>" and for each employee print 
        /// it in the format "<EmployeeFirstName> <EmployeeLastName> - <JobTitle>".
        /// </summary>
        /// <param name="context">DbContext</param>
        /// <returns></returns>
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var output = new StringBuilder();

            var departments = context.Departments
                .Include(d => d.Employees)
                .Include(d => d.Manager)
                .Where(d => d.Employees.Count() > 5)
                .OrderBy(d => d.Employees.Count())
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    EmployeesList = d.Employees
                })
                .ToList();
            foreach (var d in departments)
            {
                output.AppendLine($"{d.DepartmentName} - {d.ManagerFirstName} {d.ManagerLastName}");
                foreach (var e in d.EmployeesList.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    output.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return output.ToString();
        }

        /// <summary>
        /// Write a program that returns information about the last 10 started projects. 
        /// Sort them by name lexicographically and return their name, description and start date, each on a new row.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetLatestProjects(SoftUniContext context)
        {
            var output = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new 
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .ToList();
            foreach (var project in projects)
            {
                output.AppendLine($"{project.Name}");
                output.AppendLine($"{project.Description}");
                output.AppendLine($"{project.StartDate.ToString("M/d/yyyy h:mm:ss tt")}");
            }

            return output.ToString();
        }

        /// <summary>
        /// Write a program that increases salaries of all employees 
        /// that are in the Engineering, Tool Design, Marketing, or Information Services department by 12%. 
        /// Then return first name, last name and salary (2 symbols after the decimal separator) 
        /// for those employees whose salary was increased. 
        /// Order them by first name (ascending), then by last name (ascending). 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                        e.Department.Name == "Tool Design" ||
                        e.Department.Name == "Marketing" ||
                        e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();
            employees.ForEach(e => e.Salary += e.Salary * 0.12M);
            context.Employees.UpdateRange(employees);
            context.SaveChanges();

            var output = new StringBuilder();
            employees.ForEach(e => output.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})"));
            return output.ToString().Trim();
        }

        /// <summary>
        /// Write a program that finds all employees whose first name starts with "Sa". 
        /// Return their first, last name, their job title and salary rounded to 2 symbols after the decimal separator in the format given in the example below. 
        /// Order them by the first name, then by last name (ascending).
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();

            var output = new StringBuilder();
            employees.ForEach(e => output.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})"));
            return output.ToString();
        }

        /// <summary>
        /// Let's delete the project with id 2. Then, take 10 projects and return their names, each on a new line. 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string DeleteProjectById(SoftUniContext context)
        {
            var output = new StringBuilder();

            var project = context.Projects.Find(2);
            var employeesProject = context.EmployeesProjects.Where(ep => ep.ProjectId == project.ProjectId).ToList();
            context.EmployeesProjects.RemoveRange(employeesProject);
            context.Projects.Remove(project);
            context.SaveChanges();

            context.Projects.Take(10).Select(p => new
            {
                p.Name
            })
            .ToList()
            .ForEach(pn => output.AppendLine(pn.Name));

            return output.ToString();
        }

        /// <summary>
        /// Write a program that deletes a town with name "Seattle". Also, delete all addresses that are in those towns. 
        /// Return the number of addresses that were deleted in format "{count} addresses in Seattle were deleted". 
        /// There will be employees living at those addresses, which will be a problem when trying to delete the addresses. 
        /// So, start by setting the AddressId of each employee for the given address to null. 
        /// After all of them are set to null, you may safely remove all the addresses from the context and finally remove the given town.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                .First(t => t.Name == "Seattle");

            var addresses = context.Addresses
                .Where(a => a.TownId == town.TownId);

            var addressesCount = addresses.Count();

            var employees = context.Employees
                .Where(e => addresses.Any(a => a.AddressId == e.AddressId))
                .ToList();

            employees.ForEach(e => e.Address = null);
            context.Addresses.RemoveRange(addresses);
            context.Remove(town);
            context.SaveChanges();

            return $"{addressesCount} addresses in Seattle were deleted";
        }
    }
}
