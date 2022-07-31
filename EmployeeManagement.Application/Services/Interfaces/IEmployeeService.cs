using EmployeeManagement.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> RegisterEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<int> DeleteEmployee(Guid id);

        Task<Employee> GetEmployeeById(Guid id);
        Task<List<Employee>> GetEmployees();

    }
}
