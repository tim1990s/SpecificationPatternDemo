using System.Collections.Generic;

namespace Core.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
