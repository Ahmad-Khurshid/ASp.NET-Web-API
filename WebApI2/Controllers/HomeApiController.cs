using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApI2.Models;
using WebApI2.DataTransferObjects;
namespace WebApI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeApiController : ControllerBase
    {
        public EmployeeDataContext context;

        public HomeApiController(EmployeeDataContext context)
        {
            this.context = context;
        }
        [HttpGet("GetEmployeeById/{id}")]
        public async Task<ActionResult<Employee>> GetEmployyee(int id)
        {
            var data = await context.Employees.Where(x => x.Employeeid == id).FirstOrDefaultAsync();
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound("Not Found");
        }
        [HttpGet("GetEmployee")]
        public async Task<ActionResult<List<Employee>>> GetAllEmployyee(int PageNo, int PageSize)
        {
            var data = await context.Employees.ToListAsync();
            if (data != null)
            {
                if (PageSize > 0 & PageNo > 0)
                {
                    int itemsToSkipped = (PageNo - 1) * PageSize;
                    var result = data.Skip(itemsToSkipped).Take(PageSize);
                    return Ok(result);
                }
                if (PageSize == -1)
                {
                    return Ok(data);
                }
            }
            return NotFound("No Record Found");
        }
        [HttpPost("Create_New_Record")]
        public async Task<ActionResult<Employee>> CreateEmployee(EmployeeDto data)
        {
            var employee = new Employee()
            {
                Employeeid = data.Employeeid,
                EmployeeName = data.EmployeeName,
                DepartmentId = data.DepartmentId,
                HireDate = data.HireDate,
                JobTitle = data.JobTitle,
                ManagerId = data.ManagerId,
                Salary = data.Salary
            };
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
            return Ok(employee);
        }
        [HttpPut("update_employee/{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, EmployeeDto employee)
        {
            var existId = await context.Employees.AnyAsync(x => x.Employeeid == id);
            if (existId != true)
            {
                return BadRequest("No Record Found for id = " + id);
            }
            var updater = await context.Employees.FirstOrDefaultAsync(x => x.Employeeid == id);
            updater.Employeeid = employee.Employeeid;
            updater.EmployeeName = employee.EmployeeName;
            updater.HireDate = employee.HireDate;
            updater.JobTitle = employee.JobTitle;
            updater.ManagerId = employee.ManagerId;
            updater.Salary = employee.Salary;
            updater.DepartmentId = employee.DepartmentId;
            await context.SaveChangesAsync();
            return Ok(updater);
        }
        [HttpDelete("Delete_Employee/{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var emp = await context.Employees.FindAsync(id);
            if (emp != null)
            {
                context.Employees.Remove(emp);
                await context.SaveChangesAsync();
                return Ok("Record has been deleted successfully");
            } 
            return BadRequest("No Record Found To Delete!!");
        }

    }
}
