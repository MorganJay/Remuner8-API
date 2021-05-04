using API.Authentication;
using API.Dtos;
using API.Models;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentsRepo;
        private readonly IMapper _mapper;

        public DepartmentsController(IDepartmentRepository department, IMapper mapper)
        {
            _departmentsRepo = department;
            _mapper = mapper;
        }

        private async Task<bool> DepartmentNameExists(string name)
        {
            return await _departmentsRepo.DepartmentExists(name);
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetDepartments()
        {
            try
            {
                var departmentsFromRepo = await _departmentsRepo.GetAllDepartmentsAsync();
                var departments = _mapper.Map<IEnumerable<DepartmentDto>>(departmentsFromRepo);
                return Ok(new { data = departments, total = departments.Count() });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartment(int id)
        {
            var department = await _departmentsRepo.GetDepartmentByIdAsync(id);

            if (department is not null) return Ok(_mapper.Map<DepartmentDto>(department));

            return NotFound(new Response { Success = false, Message = $"The department with ID: {id} does not exist." });
        }

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartmentDto>> PostDepartment(DepartmentCreateDto departmentCreateDto)
        {
            if (await DepartmentNameExists(departmentCreateDto.DepartmentName))
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Success = false, Message = "A department with that name already exists" });

            var department = _mapper.Map<Department>(departmentCreateDto);
            await _departmentsRepo.CreateDepartmentAsync(department);
            await _departmentsRepo.SaveChangesAsync();

            var departmentReadDto = _mapper.Map<DepartmentDto>(department);

            return CreatedAtAction("GetDepartment", new { id = departmentReadDto.DepartmentId }, departmentReadDto);
        }

        //  PUT: api/Departments/5
        //  To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutDepartment(int id, DepartmentDto departmentDto)
        {
            if (id != departmentDto.DepartmentId) return BadRequest();
            var departmentFromRepo = await _departmentsRepo.GetDepartmentByIdAsync(id);

            try
            {
                _mapper.Map(departmentDto, departmentFromRepo);
                // await _departmentsRepo.UpdateDepartment(id);
                await _departmentsRepo.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (departmentFromRepo is null) return NotFound();
                else return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }

            return NoContent();
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            var departmentFromRepo = await _departmentsRepo.GetDepartmentByIdAsync(id);
            if (departmentFromRepo is null) return NotFound(new Response { Success = false, Message = $"The department with ID: {id} does not exist." });

            await _departmentsRepo.DeleteDepartmentAsync(departmentFromRepo);
            await _departmentsRepo.SaveChangesAsync();

            return NoContent();
        }
    }
}