using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeToReturnDto>()
                .ForMember(d => d.Id, o => o.MapFrom(e => e.Id))
                .ForMember(d => d.Name, o => o.MapFrom(e => e.Name))
                .ForMember(d => d.Position, o => o.MapFrom(e => e.Position))
                .ForMember(d => d.Age, o => o.MapFrom(e => e.Age))
                .ForMember(d => d.CompanyName, o => o.MapFrom(e => e.Company.Name));

            CreateMap<Company, CompanyToReturnDto>();
        }
    }
}
