using System.Collections.Generic;
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
        public ActionResult<IEnumerable<LeaveTypeReadDto>> GetAllLeaveType()
        {
            var leaveItems = _leaveType.GetAllLeaveType();

            return Ok(_mapper.Map<LeaveTypeReadDto>(leaveItems));
        }

        //GET api/leavetype/{id}
        [HttpGet("{id}", Name ="GetLeaveTypeById")]
        public ActionResult<LeaveTypeReadDto> GetLeaveTypeById(int id)
        {
            var leaveItem = _leaveType.GetLeaveById(id);
            if (leaveItem != null)
            {
                return Ok(_mapper.Map<LeaveTypeReadDto>(leaveItem));
            }
            return NotFound();
        }

        //POST api/leavetype
        [HttpPost]
        public ActionResult<LeaveTypeReadDto> CreateLeaveType(LeaveTypeCreateDto leaveTypeCreateDto)
        {
            var leaveItems = _mapper.Map<LeaveType>(leaveTypeCreateDto);
            _leaveType.CreateLeaveType(leaveItems);
            _leaveType.SaveChanges();

            var leaveReadDto = _mapper.Map<LeaveTypeReadDto>(leaveItems);

            return CreatedAtRoute(nameof(GetLeaveTypeById), new { id = leaveReadDto.id }, leaveReadDto);
        }
        //PUT api/leavetype{id}
        [HttpPut]
        public ActionResult UpdateLeaveTypeDto(int id, LeaveTypeReadDto leaveTypeUpdate)
        {
            var leaveFromrepo = _leaveType.GetLeaveById(id);
            if (leaveFromrepo == null)
            {
                return NotFound();
            }
            _mapper.Map(leaveTypeUpdate, leaveFromrepo);

            _leaveType.UpdateLeaveType(leaveFromrepo);
            _leaveType.SaveChanges();

            return NoContent();
        }
    }
}