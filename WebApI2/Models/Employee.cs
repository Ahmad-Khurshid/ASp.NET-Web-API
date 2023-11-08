using System;
using System.Collections.Generic;

namespace WebApI2.Models
{
    public partial class Employee
    {
        public int? Employeeid { get; set; }
        public string? EmployeeName { get; set; }
        public int? DepartmentId { get; set; }
        public string? JobTitle { get; set; }
        public int? Salary { get; set; }
        public DateTime? HireDate { get; set; }
        public int? ManagerId { get; set; } 

        public virtual Department? Department { get; set; }
    }
}
