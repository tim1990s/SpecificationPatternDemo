using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Company:BaseEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
