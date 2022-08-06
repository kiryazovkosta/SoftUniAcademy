namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var output = new StringBuilder();

            var projects = new List<Project>();
            var projectsDtos = Deserialize<ImportProjectDto[]>(xmlString, "Projects");
            foreach (var pDto in projectsDtos)
            {
                if (!IsValid(pDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (!DateTime.TryParseExact(pDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime pOpenDate))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? pDueDate = null;
                if (DateTime.TryParseExact(pDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDate))
                {
                    pDueDate = dueDate;
                }

                var project = new Project() { Name = pDto.Name, OpenDate = pOpenDate, DueDate = pDueDate };
                foreach (var tDto in pDto.Tasks)
                {
                    if (!IsValid(tDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!DateTime.TryParseExact(tDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tOpenDate)
                        || !DateTime.TryParseExact(tDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tDueDate))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (tOpenDate < pOpenDate || (pDueDate.HasValue && pDueDate.Value < tDueDate))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    project.Tasks.Add(new Task { Name = tDto.Name, OpenDate = tOpenDate, DueDate = tDueDate, LabelType = (LabelType)tDto.LabelType, ExecutionType = (ExecutionType)tDto.ExecutionType });
                }

                projects.Add(project);
                output.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();
            return output.ToString().Trim();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var output = new StringBuilder();

            var employees = new List<Employee>();
            var employeesDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);
            foreach (var eDto in employeesDtos)
            {
                if (!IsValid(eDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee() { Username = eDto.Username, Email = eDto.Email, Phone = eDto.Phone };
                foreach (var taskId in eDto.Tasks.Distinct())
                {
                    Task task = context.Tasks.FirstOrDefault(t => t.Id == taskId);
                    if (task == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask { Employee = employee, Task = task });
                }

                employees.Add(employee);
                output.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();
            return output.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            T dtos = (T)xmlSerializer.Deserialize(reader);

            return dtos;
        }
    }
}