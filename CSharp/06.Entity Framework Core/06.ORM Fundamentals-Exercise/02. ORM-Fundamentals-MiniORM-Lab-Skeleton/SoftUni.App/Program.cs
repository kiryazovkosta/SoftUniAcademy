// See https://aka.ms/new-console-template for more information
using MiniORM;
using SoftUni.App.Data.Models;

List<Employee> employeies = new List<Employee>()
{ 
    new Employee() { Id = 1, Name = "Anderson" },
    new Employee() { Id = 2, Name = "Petersen" },
    new Employee() { Id = 3, Name = "Miguel" },
    new Employee() { Id = 4, Name = "Козницов" },
};

ChangeTracker<Employee> changeTracker = new ChangeTracker<Employee>(employeies);
Console.WriteLine(string.Join(", ", changeTracker.All));
