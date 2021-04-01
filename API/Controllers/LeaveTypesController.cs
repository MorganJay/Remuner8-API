using System.Collections.Generic;
using System.Threading.Tasks;
using API.Authentication;
using API.Dtos;
using API.Models;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    //api/leaveType
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly ILeaveRepository _leaveType;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveRepository leaveType, IMapper mapper)
        {
            _leaveType = leaveType;
            _mapper = mapper;
        }

        //GET api/LeaveType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveTypeReadDto>>> GetAllLeaveType()
        {
            var leaveItems = await _leaveType.GetAllLeaveTypeAsync();
            var model = _mapper.Map<IEnumerable<LeaveTypeReadDto>>(leaveItems);
            return Ok(model);
        }

        //GET api/leavetype/{id}
        [HttpGet("{id}", Name = "GetLeaveTypeById")]
        public async Task<ActionResult<LeaveTypeReadDto>> GetLeaveTypeByIdAsync(int id)
        {
            var leaveItem = await _leaveType.GetLeaveById(id);
            if (leaveItem is not null)
            {
                return Ok(_mapper.Map<LeaveTypeReadDto>(leaveItem));
            }
            return NotFound();
        }

        //POST api/leavetype
        [HttpPost]
        public async Task<ActionResult<LeaveTypeReadDto>> CreateLeaveTypeAsync(LeaveTypeCreateDto leaveTypeCreateDto)
        {
            var leaveItems = _mapper.Map<LeaveType>(leaveTypeCreateDto);
            await _leaveType.CreateLeaveTypeAsync(leaveItems);
            await _leaveType.SaveChanges();

            var leaveReadDto = _mapper.Map<LeaveTypeReadDto>(leaveItems);

            return CreatedAtRoute(nameof(GetLeaveTypeByIdAsync), new { id = leaveReadDto.Id }, leaveReadDto);
        }

        //PUT api/leavetype{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLeaveTypeDto(int id, LeaveTypeCreateDto leaveTypeUpdate)
        {
            var leaveFromRepo = await _leaveType.GetLeaveById(id);
            if (leaveFromRepo is null)
            {
                return NotFound();
            }
            _mapper.Map(leaveTypeUpdate, leaveFromRepo);

            _leaveType.UpdateLeaveType(leaveFromRepo);
            await _leaveType.SaveChanges();

            return NoContent();
        }

        // DELETE api/leavetype/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLeaveType(int id)
        {
            var leaveTypeFromRepo = await _leaveType.GetLeaveById(id);
            if (leaveTypeFromRepo is null) return NotFound(new Response { Status = "Error", Message = $"The leave type with ID: {id} does not exist." });

            await _leaveType.DeleteLeaveTypeAsync(id);
            await _leaveType.SaveChanges();

            return NoContent();
        }
    }
}