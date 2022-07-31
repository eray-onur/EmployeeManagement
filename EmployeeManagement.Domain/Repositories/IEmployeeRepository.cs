using EmployeeManagement.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(Guid id);
        Task<int> Create(Employee employee);
        Task<int> Update(Employee employee);
        Task<int> Delete(Guid id);
    }
}
