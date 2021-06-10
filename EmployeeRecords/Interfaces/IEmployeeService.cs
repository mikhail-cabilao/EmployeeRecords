using EmployeeRecords.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeRecords.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(long id);
        Task<bool> DeleteEmployee(long id);
        Task<Employee> UpdateEmployee(long id, Employee employee);
        Task<Employee> AddEmployee(Employee employee);
    }
}
