using EmployeeManagement.Application.Services.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> RegisterEmployee(Employee employee)
        {
            await _employeeRepository.Create(employee);

            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            await _employeeRepository.Update(employee);
            return employee;
        }

        public async Task<int> DeleteEmployee(Guid id)
        {
            return await _employeeRepository.Delete(id);
        }

        public async Task<Employee> GetEmployeeById(Guid id)
        {
            return await _employeeRepository.GetById(id);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _employeeRepository.GetAll();
        }
    }
}
