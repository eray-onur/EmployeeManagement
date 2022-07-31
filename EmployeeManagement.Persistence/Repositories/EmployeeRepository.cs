using Dapper;

using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Repositories;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Persistence.Dapper.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbDapperContext _context;

        public EmployeeRepository(DbDapperContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetById(Guid id)
        {
            using(var connection = _context.CreateConnection())
            {
                var employee = await connection.QueryFirstAsync<Employee>($"select * from Employees where Id = @Id and IsDeleted = false;", new { id });

                return employee;
            }
        }

        public async Task<List<Employee>> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var employees = await connection.QueryAsync<Employee>($"select * from Employees where IsDeleted = false;");

                return employees.ToList();
            }
        }

        public async Task<int> Create(Employee employee)
        {
            using (var connection = _context.CreateConnection())
            {
                var insertionQuery = "INSERT INTO Employees (Id, Name, Address, Country) VALUES (@Id, @Name, @MiddleName, @LastName)";

                var parameters = new DynamicParameters();
                parameters.Add("Id", Guid.NewGuid(), DbType.Guid);
                parameters.Add("Name", employee.Name, DbType.String);
                parameters.Add("MiddleName", employee.MiddleName, DbType.String);
                parameters.Add("LastName", employee.LastName, DbType.String);


                return await connection.ExecuteAsync(insertionQuery, parameters);

            }
        }

        public async Task<int> Update(Employee employee)
        {
            using (var connection = _context.CreateConnection())
            {
                var updateQuery = "UPDATE Employees (Name, MiddleName, LastName) SET Name = @Name, MiddleName = @MiddleName, LastName = @LastName WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", employee.Id, DbType.Guid);
                parameters.Add("Name", employee.Name, DbType.String);
                parameters.Add("MiddleName", employee.MiddleName, DbType.String);
                parameters.Add("LastName", employee.LastName, DbType.String);


                return await connection.ExecuteAsync(updateQuery, parameters);

            }
        }

        public async Task<int> Delete(Guid id)
        {
            using (var connection = _context.CreateConnection())
            {
                var updateQuery = "UPDATE Employees SET IsDeleted = true WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Guid);


                return await connection.ExecuteAsync(updateQuery, parameters);

            }
        }
    }
}
