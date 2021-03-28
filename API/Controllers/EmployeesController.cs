using API.Authentication;
using API.Dtos;
using API.Models;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper employeeMapper;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
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

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeBiodataReadDto>>> GetAllEmployees()
        {
            try
            {
                var employees = await employeeRepository.GetAllEmployeesAsync();

                return Ok(employeeMapper.Map<IEnumerable<EmployeeBiodataReadDto>>(employees));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }

        // GET: api/Employees/{id}
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public async Task<ActionResult<EmployeeBiodataReadDto>> GetEmployeeById(string id)
        {
            try
            {
                var employeeModel = await employeeRepository.GetEmployeeByIdAsync(id);
                if (employeeModel is not null) return Ok(employeeMapper.Map<EmployeeBiodataReadDto>(employeeModel));

                return NotFound(new Response { Status = "Error", Message = $"The employee with ID: {id} was not found" });
            }
            catch (Exception)
            {
                // throw;
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "An Error Occurred!" });
            }
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<EmployeeBiodataReadDto>> CreateEmployeeAsync(EmployeeBiodataCreateDto employeeBiodataCreateDto)
        {
            try
            {
                var employeeModel = employeeMapper.Map<EmployeeBiodata>(employeeBiodataCreateDto);
                await employeeRepository.CreateEmployeeAsync(employeeModel);
                await employeeRepository.SaveChangesAsync();

                var employeeReadDto = employeeMapper.Map<EmployeeBiodataReadDto>(employeeModel);
                return CreatedAtRoute(nameof(GetEmployeeById), new { employeeReadDto.EmployeeId }, employeeReadDto);
            }
            catch (Exception)
            {
                throw;
                // return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "An Error Occurred!" });
            }
        }

        // PATCH: api/Employees/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialUpdateEmployeeAsync(string id, JsonPatchDocument<EmployeeBiodataCreateDto> patchDocument)
        {
            try
            {
                var employeeModel = await employeeRepository.GetEmployeeByIdAsync(id);
                if (employeeModel is null) return NotFound(new Response { Status = "Error", Message = $"The employee with ID {id} does not exist" });

                var employeeToPatch = employeeMapper.Map<EmployeeBiodataCreateDto>(employeeModel);
                patchDocument.ApplyTo(employeeToPatch, ModelState);

                if (!TryValidateModel(employeeToPatch)) return ValidationProblem(ModelState);

                employeeMapper.Map(employeeToPatch, employeeModel);

                if (!await employeeRepository.SaveChangesAsync()) return BadRequest();

                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/Employees/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> FullUpdateEmployeeAsync(string id, EmployeeBiodataCreateDto employeeBiodataCreateDto)
        {
            var employeeModel = await employeeRepository.GetEmployeeByIdAsync(id);
            if (employeeModel is null) return NotFound(new Response { Status = "Error", Message = $"The employee with ID {id} could not be found." });

            employeeMapper.Map(employeeBiodataCreateDto, employeeModel);

            if (!await employeeRepository.SaveChangesAsync()) return BadRequest();

            return NoContent();
        }

        // DELETE api/Employees/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(string id)
        {
            var employeeModel = await employeeRepository.GetEmployeeByIdAsync(id);
            if (employeeModel is null) return NotFound(new Response { Status = "Error", Message = $"The employee with ID {id} could not be found." });

            await employeeRepository.DeleteEmployeeAsync(employeeModel);

            await employeeRepository.SaveChangesAsync();

            return StatusCode(StatusCodes.Status204NoContent, new Response { Status = "Success", Message = "Employee deleted successfully" });
        }
    }
}