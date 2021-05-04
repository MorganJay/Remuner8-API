using API.Authentication;
using API.Data_Models.Dtos;
using API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSheetsController : ControllerBase
    {
        private readonly ITimeSheetRepository timeSheetRepository;
        private readonly LinkGenerator linkGenerator;

        public TimeSheetsController(ITimeSheetRepository timeSheetRepository, LinkGenerator linkGenerator)
        {
            this.timeSheetRepository = timeSheetRepository;
            this.linkGenerator = linkGenerator;
        }

        // GET: api/<TimeSheetController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeSheetDto>>> GetListOfTimeSheet()
        {
            try
            {
                var listOfTimeSheet = await timeSheetRepository.GetAllTimeSheetAsync();
                return Ok(listOfTimeSheet);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = "An Error Occurred!" });
            }
        }

        // GET api/<TimeSheetController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSheetDto>> GetTimeSheetById(string id)
        {
            try
            {
                var getTimeSheetById = await timeSheetRepository.GetTimeSheetByIdAsync(id);
                if (getTimeSheetById == null)
                {
                    return BadRequest(new Response { Success = false, Message = $"The timesheet with id={id} cannot be found" });
                }
                return Ok(getTimeSheetById);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = "An Error Occurred!" });
            }
        }

        // POST api/<TimeSheetController>
        [HttpPost]
        public async Task<ActionResult<TimeSheetDto>> Post([FromBody] TimeSheetDto model)
        {
            try
            {
                var Location = linkGenerator.GetPathByAction("GetTimeSheetById", "TimeSheet", new { id = model.EmployeeId });
                if (string.IsNullOrWhiteSpace(Location))
                {
                    return BadRequest($"Could not find id path");
                }

                var newTimeSheet = await timeSheetRepository.AddTimeSheetAsync(model);
                return Created(Location, newTimeSheet);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = "An Error Occurred!" });
            }
        }

        // PUT api/<TimeSheetController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] TimeSheetDto model)
        {
            try
            {
                var updatedTimeSheet = await timeSheetRepository.UpdateTimeSheetAsync(model);
                if (updatedTimeSheet)
                {
                    return Ok(new Response { Success = true, Message = "The Update was Successful" });
                }
                return BadRequest(new Response { Success = false, Message = "The Update was not Successful" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = "An Error Occurred!" });
            }
        }

        // DELETE api/<TimeSheetController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var deletedTimeSheet = await timeSheetRepository.DeleteTimeSheetAsync(id);
                if (deletedTimeSheet)
                {
                    return Ok(new Response { Success = true, Message = "The Time sheet was deleted Successfully" });
                }
                return BadRequest(new Response { Success = false, Message = "The process was not Successful" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = "An Error Occurred!" });
            }
        }
    }
}