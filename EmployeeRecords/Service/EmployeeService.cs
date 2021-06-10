using CodeLabX.EntityFramework.Extensions;
using EmployeeRecords.Interfaces;
using EmployeeRecords.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecords.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository _repository;

        public EmployeeService(IRepository repository) => _repository = repository;

        public async Task<IEnumerable<Employee>> GetEmployees() => await _repository.GetAsync<Employee>();
        public async Task<Employee> GetEmployeeById(long id)
        {
            var employees = await GetEmployees();
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            if (employee is not null)
            {
                await _repository.AddAsync(employee);
                await _repository.SaveChangesAsync();

                return employee;
            }

            return default;
        }

        public async Task<Employee> UpdateEmployee(long id, Employee employee)
        {
            var emp = await GetEmployeeById(id);
            var map = employee.ResolveEntity(emp); // if ever the employee parameter empty some of its properties set during request.
            if (emp is not null)
            {
                var result = await _repository.UpdateAsync(map);
                await _repository.SaveChangesAsync();

                return result;
            }

            return default;
        }

        public async Task<bool> DeleteEmployee(long id)
        {
            var result = _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();

            return result;
        }
    }
}
