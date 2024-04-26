using EmployeeManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EmployeeManagementContext(
                serviceProvider.GetRequiredService<DbContextOptions<EmployeeManagementContext>>()))
            {
                if (context == null || context.Employee == null)
                {
                    throw new ArgumentNullException("Null EmployeeManagementContext");
                }

                // Look for any Employees.
                if (context.Employee.Any())
                {
                    return;   // DB has been seeded
                }

                context.Employee.AddRange(
                    new Employee
                    {
                       Name = "phil Foden",
                       Department = "IT",
                       Salary = 75000,
                       DateOfBirth = DateTime.Parse("2000-10-23"),
                       Email = "PhilFoden99@gmail.com"
                    },

                    new Employee
                    {
                        Name = "Jack Graylish",
                        Department = "Marketing",
                        Salary = 50000,
                        DateOfBirth = DateTime.Parse("1992-07-14"),
                        Email = "Graylish224@gmail.com"
                    },

                    new Employee
                    {
                        Name = "Neymar JR",
                        Department = "Sales",
                        Salary = 60000,
                        DateOfBirth = DateTime.Parse("1991-04-26"),
                        Email = "NeymarJR440@gmail.com"
                    },

                    new Employee
                    {
                        Name = "Ringo Star",
                        Department = "Accounting",
                        Salary = 45000,
                        DateOfBirth = DateTime.Parse("1982-11-14"),
                        Email = "star99@gmail.com"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}