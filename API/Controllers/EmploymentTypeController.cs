using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("{id}")]
        public async Task<ActionResult<EmploymentTypeReadDto>> Get(int id)
        {
            await _employmentTypeRepo.GetEmploymentTypeByIdAsync(id);
            return Ok();
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
            var employmentType = await _employmentTypeRepo.GetEmploymentTypeByIdAsync(id);
            if (employmentType is null)
            {
                return NotFound();
            }
            _mapper.Map(employmentTypeCreateDto, employmentType);
            await _employmentTypeRepo.UpdateEmploymentTypeAsync(id, employmentType);
            await _employmentTypeRepo.SaveAsync();
            return NoContent();
        }

        // DELETE api/<EmploymentTypeController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _employmentTypeRepo.DeleteEmploymentType(id);
            return Ok();
        }
    }
}