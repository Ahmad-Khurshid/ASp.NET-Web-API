using Microsoft.AspNetCore.Mvc;
using WebApI2.DataTransferObjects;
namespace WebApI2.DataTransferObjects
{
    public class EmployeeDto
    {
        public int? Employeeid { get; set; }
        public string? EmployeeName { get; set; }
        public int? DepartmentId { get; set; }
        public string? JobTitle { get; set; }
        public int? Salary { get; set; }
        public DateTime? HireDate { get; set; }
        public int? ManagerId { get; set; } 

     
    }
}
