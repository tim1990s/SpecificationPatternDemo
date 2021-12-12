using Core.Entities;
using System;

namespace Core.Specifications
{
    public class CompanyWithCompanySpecification : BaseSpecifcation<Company>
    {
        public CompanyWithCompanySpecification()
        {
            AddInclude(c => c.Employees);
        }

        public CompanyWithCompanySpecification(Guid id) : base(c => c.Id == id)
        {
            AddInclude(e => e.Employees);
        }
    }
}
