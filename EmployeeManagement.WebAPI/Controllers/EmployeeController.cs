using AutoMapper;

using EmployeeManagement.Application.Models.Requests;
using EmployeeManagement.Application.Services.Interfaces;
using EmployeeManagement.Domain.Entities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = _employeeService.GetEmployees();

            return Ok(employees);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var employee = _employeeService.GetEmployeeById(Id);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPersonnel(CreateEmployeeRequest request)
        {
            var registered = await _employeeService.RegisterEmployee(_mapper.Map<Employee>(request));
            return Ok(registered);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePersonnel(UpdateEmployeeRequest request)
        {
            var updated = await _employeeService.UpdateEmployee(_mapper.Map<Employee>(request));
            return Ok(updated);
        }

        public async Task<IActionResult> DeletePersonnel(Guid Id)
        {
            var updated = await _employeeService.DeleteEmployee(Id);
            return Ok(updated);
        }

    }
}
