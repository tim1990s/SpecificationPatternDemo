using Core.Entities;
using System;

namespace Core.Specifications
{
    public class EmployeeWithCompanySpecification : BaseSpecifcation<Employee>
    {
        public EmployeeWithCompanySpecification()
        {
            AddInclude(e => e.Company);
        }

        public EmployeeWithCompanySpecification(Guid id) : base(e => e.Id == id)
        {
            AddInclude(e => e.Company);
        }
    }
}
