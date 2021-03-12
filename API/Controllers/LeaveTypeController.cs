using System.Collections.Generic;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //api/leaveType
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly ILeaveRepository _leaveType;

        public LeaveTypeController(ILeaveRepository leaveType)
        {
            _leaveType = leaveType;
        }
        //GET api/LeaveType
        [HttpGet]
        public ActionResult <IEnumerable<LeaveType>> GetAllLeaveType()
        {
            var leaveItems = _leaveType.GetAllLeaveType();

            return Ok(leaveItems);
        }
       
    }
}