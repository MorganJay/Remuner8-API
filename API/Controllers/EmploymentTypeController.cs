using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Authentication;
using API.Dtos;
using API.Models;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploymentTypeController : ControllerBase
    {
        private readonly IEmploymentTypeRepo _employmentTypeRepo;
        private readonly IMapper _mapper;

        public EmploymentTypeController(IEmploymentTypeRepo employmentTypeRepo, IMapper mapper)
        {
            _employmentTypeRepo = employmentTypeRepo;
            _mapper = mapper;
        }

        // GET: api/<EmploymentTypeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmploymentTypeReadDto>>> GetAll()
        {
            var employmentType = await _employmentTypeRepo.GetEmploymentTypeAsync();
            var mappedModel = _mapper.Map<IEnumerable<EmploymentTypeReadDto>>(employmentType);
            return Ok(mappedModel);
        }

        // GET api/<EmploymentTypeController>/5
        [HttpGet("{id}", Name = "GetEmploymentTypeByIdAsync")]
        public async Task<ActionResult<EmploymentTypeReadDto>> Get(int id)
        {
            var getEmploymentItem = await _employmentTypeRepo.GetEmploymentTypeByIdAsync(id);
            if (getEmploymentItem is not null)
            {
                return Ok(_mapper.Map<EmploymentTypeReadDto>(getEmploymentItem));
            }
            return NotFound();
        }

        // POST api/<EmploymentTypeController>
        [HttpPost]
        public async Task<ActionResult> Post(EmploymentTypeCreateDto employmentTypeCreateDto)
        {
            var mappedModel = _mapper.Map<EmploymentType>(employmentTypeCreateDto);
            await _employmentTypeRepo.CreateEmploymentTypeAsync(mappedModel);
            await _employmentTypeRepo.SaveAsync();
            return Ok();
        }

        // PUT api/<EmploymentTypeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, EmploymentTypeCreateDto employmentTypeCreateDto)
        {
            try
            {
                var employmentType = await _employmentTypeRepo.GetEmploymentTypeByIdAsync(id);
                if (employmentType is null)
                {
                    return NotFound();
                }
                var newEmploymentType = _mapper.Map(employmentTypeCreateDto, employmentType);
                _employmentTypeRepo.UpdateEmploymentTypeAsync(id, employmentType);
                await _employmentTypeRepo.SaveAsync();
                return Ok(newEmploymentType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE api/<EmploymentTypeController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _employmentTypeRepo.DeleteEmploymentType(id);
                _employmentTypeRepo.SaveAsync();
                return Ok(new Response { Status = "Success", Message = "Employment Type deleted successfully" });
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = ex.InnerException.Message });
            }
        }
    }
}