using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;
using API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //api/leaveTypes
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeaveTypesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLeaveType()
        {
            var leaveItems = await _unitOfWork.LeaveType.GetAll();
            var results = _mapper.Map<IList<LeaveTypeReadDto>>(leaveItems);
            return Ok(results);
        }

        [HttpGet("{id}", Name = "GetLeaveTypeById")]
        public async Task<IActionResult> GetLeaveTypeById(int id)
        {
            var leave = await _unitOfWork.LeaveType.Get(query => query.Id == id);
            if (leave != null)
            {
                return Ok(_mapper.Map<LeaveTypeReadDto>(leave));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeaveType([FromBody] LeaveTypeCreateDto leaveTypeCreateDto)
        {
            var leave = _mapper.Map<LeaveType>(leaveTypeCreateDto);
            await _unitOfWork.LeaveType.Insert(leave);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetLeaveTypeById", new { id = leave.Id }, leave);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeaveType(int id, [FromBody] LeaveTypeReadDto leave)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var leaveType = await _unitOfWork.LeaveType.Get(m => m.Id == id);
            if (leaveType == null)
            {
                return BadRequest();
            }
            _mapper.Map(leave, leaveType);
            _unitOfWork.LeaveType.Update(leaveType);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeave(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var leave = await _unitOfWork.LeaveType.Get(query => query.Id == id);
            if (leave == null)
            {
                return BadRequest("Submitted Data Is Invalid");
            }
            await _unitOfWork.LeaveType.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}