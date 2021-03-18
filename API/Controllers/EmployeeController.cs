using API.Authentication;
using API.Dtos;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper employeeMapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            employeeMapper = mapper;
        }

        // GET: api/Employee/count
        [Route("count")]
        [HttpGet]
        public async Task<ActionResult<int>> GetEmplyeeCount()
        {
            try
            {
                var employeecount = await employeeRepository.EmployeeCountAsync();
                return Ok(employeecount);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "An Error Occurred!" });
            }
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeBiodataReadDto>>> GetAllEmployees()
        {
            try
            {
                var employees = await employeeRepository.GetAllEmployeesAsync();

                return Ok(employeeMapper.Map<IEnumerable<EmployeeBiodataReadDto>>(employees));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}