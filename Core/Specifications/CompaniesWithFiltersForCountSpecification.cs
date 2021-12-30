using Core.Entities;

namespace Core.Specifications
{
    public class CompaniesWithFiltersForCountSpecification : BaseSpecifcation<Company>
    {
        public CompaniesWithFiltersForCountSpecification(CompanySpecParams companySpecParams) : base(
            x => (string.IsNullOrEmpty(companySpecParams.Search) || x.Name.ToLower().Contains(companySpecParams.Search)))
        {
        }
    }
}
