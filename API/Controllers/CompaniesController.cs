using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly IGenericRepository<Company> _companyRepository;
        private readonly IMapper _mapper;

        public CompaniesController(IGenericRepository<Company> companyRepo, IMapper mapper)
        {
            _mapper = mapper;
            _companyRepository = companyRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CompanyToReturnDto>>> GetEmployees()
        {
            var spec = new CompanyWithCompanySpecification();

            var companies = await _companyRepository.ListAsync(spec);

            var companiesToReturn = _mapper.Map<IReadOnlyList<CompanyToReturnDto>>(companies);

            return Ok(companiesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeToReturnDto>> GetEmployees(Guid id)
        {
            var spec = new CompanyWithCompanySpecification(id);

            var company = await _companyRepository.GetEntityWithSpect(spec);

            var companyToReturn = _mapper.Map<CompanyToReturnDto>(company);

            return Ok(companyToReturn);
        }
    }
}
