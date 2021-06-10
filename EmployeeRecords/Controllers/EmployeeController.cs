using EmployeeRecords.Interfaces;
using EmployeeRecords.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeRecords.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _employeeService.GetEmployees();
        }

        [HttpPost]
        public async Task<Employee> Post([FromBody] Employee employee)
        {
            return await _employeeService.AddEmployee(employee);
        }

        [HttpPut("{id}")]
        public async Task<Employee> Put(long id, [FromBody] Employee employee)
        {
            return await _employeeService.UpdateEmployee(id, employee);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(long id)
        {
            return await _employeeService.DeleteEmployee(id);
        }
    }
}
