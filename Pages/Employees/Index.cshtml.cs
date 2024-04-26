using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagement.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeManagement.Data.EmployeeManagementContext _context;

        public IndexModel(EmployeeManagement.Data.EmployeeManagementContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Departments { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? EmployeeDepartment { get; set; }
        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> departmentQuery = from m in _context.Employee
                                            orderby m.Department
                                            select m.Department;

            var Employees = from m in _context.Employee
                            select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                Employees = Employees.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(EmployeeDepartment))
            {
                Employees = Employees.Where(x => x.Department == EmployeeDepartment);
            }

            Departments = new SelectList(await departmentQuery.Distinct().ToListAsync());
            Employee = await Employees.ToListAsync();

        }
    }
}
