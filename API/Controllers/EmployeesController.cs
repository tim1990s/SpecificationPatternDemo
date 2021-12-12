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
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeesController(IGenericRepository<Employee> employeeRepo, IMapper mapper)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<EmployeeToReturnDto>>> GetEmployees()
        {
            var spec = new EmployeeWithCompanySpecification();

            var employees = await _employeeRepository.ListAsync(spec);

            var employeesToReturn = _mapper.Map<IReadOnlyList<EmployeeToReturnDto>>(employees);

            return Ok(employeesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeToReturnDto>> GetEmployees(Guid id)
        {
            var spec = new EmployeeWithCompanySpecification(id);

            var employee = await _employeeRepository.GetEntityWithSpect(spec);

            var employeeToReturn = _mapper.Map<EmployeeToReturnDto>(employee);

            return Ok(employeeToReturn);
        }
    }
}
