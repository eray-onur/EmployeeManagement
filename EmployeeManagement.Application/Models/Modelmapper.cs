using AutoMapper;

using EmployeeManagement.Application.Models.Requests;
using EmployeeManagement.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Models
{
    public class Modelmapper : Profile
    {
        public Modelmapper()
        {
            CreateMap<Employee, CreateEmployeeRequest>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeRequest>().ReverseMap();
        }
    }
}
