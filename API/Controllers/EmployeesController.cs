using API.Authentication;
using API.Dtos;
using API.Models;
using API.Repositories;
using API.Repository;
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
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _employeeMapper;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(IUnitOfWork unitOfWork, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeMapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeBiodataReadDto>>> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeRepository.GetAllEmployeesAsync();
                //var employees = await _unitOfWork.EmployeeBiodata.GetAll();

                return Ok(_employeeMapper.Map<IEnumerable<EmployeeBiodataReadDto>>(employees));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }

        // GET: api/Employees/{id}
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public async Task<ActionResult<EmployeeBiodataReadDto>> GetEmployeeById(string id)
        {
            try
            {
                var employeeModel = await _employeeRepository.GetEmployeeByIdAsync(id);
                if (employeeModel is not null) return Ok(_employeeMapper.Map<EmployeeBiodataReadDto>(employeeModel));

                return NotFound(new Response { Success = false, Message = $"The employee with ID: {id} was not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = $"{ex.Message} {ex.StackTrace}" });
            }
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<EmployeeBiodataReadDto>> CreateEmployeeAsync(EmployeeBiodataCreateDto employeeBiodataCreateDto)
        {
            try
            {
                var employeeModel = _employeeMapper.Map<EmployeeBiodata>(employeeBiodataCreateDto);
                await _employeeRepository.CreateEmployeeAsync(employeeModel);
                await _employeeRepository.SaveChangesAsync();

                var employeeReadDto = _employeeMapper.Map<EmployeeBiodataReadDto>(employeeModel);
                return CreatedAtRoute(nameof(GetEmployeeById), new { employeeReadDto.EmployeeId }, employeeReadDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = $"{ex.Message} {ex.StackTrace}" });
            }
        }

        // PATCH: api/Employees/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialUpdateEmployeeAsync(string id, JsonPatchDocument<EmployeeBiodataCreateDto> patchDocument)
        {
            try
            {
                var employeeModel = await _employeeRepository.GetEmployeeByIdAsync(id);
                if (employeeModel is null) return NotFound(new Response { Success = false, Message = $"The employee with ID {id} does not exist" });

                var employeeToPatch = _employeeMapper.Map<EmployeeBiodataCreateDto>(employeeModel);
                patchDocument.ApplyTo(employeeToPatch, ModelState);

                if (!TryValidateModel(employeeToPatch)) return ValidationProblem(ModelState);

                _employeeMapper.Map(employeeToPatch, employeeModel);

                if (!await _employeeRepository.SaveChangesAsync()) return BadRequest();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = $"{ex.Message} {ex.StackTrace}" });
            }
        }

        // PUT: api/Employees/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> FullUpdateEmployeeAsync(string id, EmployeeBiodataCreateDto employeeBiodataCreateDto)
        {
            var employeeModel = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employeeModel is null) return NotFound(new Response { Success = false, Message = $"The employee with ID {id} could not be found." });

            _employeeMapper.Map(employeeBiodataCreateDto, employeeModel);

            if (!await _employeeRepository.SaveChangesAsync()) return BadRequest();

            return NoContent();
        }

        // DELETE api/Employees/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(string id)
        {
            var employeeModel = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employeeModel is null) return NotFound(new Response { Success = false, Message = $"The employee with ID {id} could not be found." });

            await _employeeRepository.DeleteEmployeeAsync(employeeModel);

            await _employeeRepository.SaveChangesAsync();

            return StatusCode(StatusCodes.Status204NoContent, new Response { Success = true, Message = "Employee deleted successfully" });
        }
    }
}