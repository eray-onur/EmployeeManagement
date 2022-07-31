using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Entities.Abstract
{
    public class DBEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
