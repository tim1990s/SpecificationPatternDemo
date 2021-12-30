using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly IGenericRepository<Company> _companyRepository;
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public CompaniesController(IGenericRepository<Company> companyRepo, IGenericRepository<Employee> employeeRepo, IMapper mapper)
        {
            _mapper = mapper;
            _companyRepository = companyRepo;
            _employeeRepository = employeeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CompanyToReturnDto>>> GetCompanies([FromQuery] CompanySpecParams companyParams)
        {
            var spec = new CompanyWithEmployeeSpecification(companyParams);
            var countSpec = new CompaniesWithFiltersForCountSpecification(companyParams);

            var totalItems = await _companyRepository.CountAsync(countSpec);
            var companies = await _companyRepository.ListAsync(spec);

            var companiesToReturn = _mapper.Map<IReadOnlyList<CompanyToReturnDto>>(companies);

            return Ok(new Pagination<CompanyToReturnDto>(companyParams.PageIndex, companyParams.PageSize, totalItems, companiesToReturn));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyToReturnDto>> GetCompany(Guid id)
        {
            var spec = new CompanyWithEmployeeSpecification(id);
            var company = await _companyRepository.GetEntityWithSpect(spec);
            if (company == null) return NotFound(HttpStatusCode.NotFound);
            return _mapper.Map<CompanyToReturnDto>(company);
        }
    }
}
