using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //api/leaveType
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly ILeaveRepository _leaveType;
        private readonly IMapper _mapper;

        public LeaveTypeController(ILeaveRepository leaveType, IMapper mapper)
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
        [HttpGet("{id}", Name ="GetLeaveTypeById")]
        public async Task<ActionResult<LeaveTypeReadDto>> GetLeaveTypeByIdAsync(int id)
        {
            var leaveItem = await _leaveType.GetLeaveById(id);
            if (leaveItem != null)
            {
                return Ok(_mapper.Map<LeaveTypeReadDto>(leaveItem));
            }
            return NotFound();
        }

        //POST api/leavetype
        [HttpPost]
        public async Task<ActionResult<LeaveTypeReadDto>> CreateLeaveTypeAsync(LeaveTypeCreateDto leaveTypeCreateDto)
        {
            var leaveItems =  _mapper.Map<LeaveType>(leaveTypeCreateDto);
           await  _leaveType.CreateLeaveTypeAsync(leaveItems);
           await  _leaveType.SaveChanges();

            var leaveReadDto = _mapper.Map<LeaveTypeReadDto>(leaveItems);

            return CreatedAtRoute(nameof(GetLeaveTypeByIdAsync), new { id = leaveReadDto.id }, leaveReadDto);
        }
        //PUT api/leavetype{id}
        [HttpPut]
        public async Task <ActionResult> UpdateLeaveTypeDto(int id, LeaveTypeCreateDto leaveTypeUpdate)
        {
            var leaveFromrepo = await _leaveType.GetLeaveById(id);
            if (leaveFromrepo is null)
            {
                return NotFound();
            }
            _mapper.Map(leaveTypeUpdate, leaveFromrepo);

            _leaveType.UpdateLeaveType(leaveFromrepo);
           await  _leaveType.SaveChanges();

            return NoContent();
        }
    }
}