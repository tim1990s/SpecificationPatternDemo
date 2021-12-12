using System;
using System.Collections.Generic;

namespace API.Dtos
{
    public class CompanyToReturnDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public ICollection<EmployeeToReturnDto> Employees { get; set; }

    }
}
