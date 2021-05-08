using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;
using API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploymentTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmploymentTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/<EmploymentTypeController>
        [HttpGet]
        public async Task<IActionResult> GetAllEmploymentType()
        {
            var employmentType = await _unitOfWork.EmployementType.GetAll();
            var result = _mapper.Map<IList<EmploymentTypeReadDto>>(employmentType);
            return Ok(result);
        }

        // GET api/<EmploymentTypeController>/5
        [HttpGet("{id}", Name = "GetEmploymentTypeById")]
        public async Task<IActionResult> GetEmplomentTypeById(int id)
        {
            var getEmploymentItem = await _unitOfWork.EmployementType.Get(query => query.EmploymentTypeId == id);
            if (getEmploymentItem is not null)
            {
                return Ok(_mapper.Map<EmploymentTypeReadDto>(getEmploymentItem));
            }
            return NotFound();
        }

        // POST api/<EmploymentTypeController>
        [HttpPost]
        public async Task<IActionResult> CreateEmployemntType([FromBody] EmploymentTypeCreateDto employmentTypeCreateDto)
        {
            var employmentType = _mapper.Map<EmploymentType>(employmentTypeCreateDto);
            await _unitOfWork.EmployementType.Insert(employmentType);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetEmploymentTypeById", new { id = employmentType.EmploymentTypeId }, employmentType);
        }

        // PUT api/<EmploymentTypeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmploymentType(int id, [FromBody] EmploymentTypeReadDto employmentTypeReadDto)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var employmentType = await _unitOfWork.EmployementType.Get(m => m.EmploymentTypeId == id);
            if (employmentType == null)
            {
                return BadRequest();
            }
            _mapper.Map(employmentTypeReadDto, employmentType);
            _unitOfWork.EmployementType.Update(employmentType);
            await _unitOfWork.Save();

            return NoContent();
        }

        // DELETE api/<EmploymentTypeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmploymentType(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var employmentType = await _unitOfWork.EmployementType.Get(query => query.EmploymentTypeId == id);
            if (employmentType == null)
            {
                return BadRequest("Submitted Data Is Invalid");
            }
            await _unitOfWork.LeaveType.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}