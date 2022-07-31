using EmployeeManagement.Domain.Entities.Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Entities
{
    public class Employee : DBEntity
    {
        public String Name { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
    }
}
