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
        public ActionResult <IEnumerable<LeaveTypeReadDto>> GetAllLeaveType()
        {
            var leaveItems = _leaveType.GetAllLeaveType();
            if (leaveItems != null)
            {
                return Ok(_mapper.Map<LeaveTypeReadDto>(leaveItems));
            }
            return NotFound();
        }
       
    }
}