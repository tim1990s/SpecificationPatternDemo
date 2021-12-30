using Core.Entities;
using System;

namespace Core.Specifications
{
    public class CompanyWithEmployeeSpecification : BaseSpecifcation<Company>
    {
        public CompanyWithEmployeeSpecification(CompanySpecParams companySpecParams) : base(x =>
        (string.IsNullOrEmpty(companySpecParams.Search) || x.Name.ToLower().Contains(companySpecParams.Search)))
        {
            AddInclude(c => c.Employees);
            ApplyPaging(companySpecParams.PageSize * (companySpecParams.PageIndex - 1), companySpecParams.PageSize);

            if (!string.IsNullOrEmpty(companySpecParams.Sort))
            {
                switch (companySpecParams.Sort)
                {
                    case "nameAsc":
                        AddOrderBy(c => c.Name);
                        break;
                    case "nameDesc":
                        AddOrderByDescending(c => c.Name);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public CompanyWithEmployeeSpecification(Guid id) : base(c => c.Id == id)
        {
            AddInclude(e => e.Employees);
        }
    }
}
