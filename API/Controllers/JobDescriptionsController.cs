using API.Authentication;
using API.Dtos;
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
    public class JobDescriptionsController : ControllerBase
    {
        private readonly IJobDescriptionRepository _jobDescriptionRepository;
        private readonly LinkGenerator _linkGenerator;

        public JobDescriptionsController(IJobDescriptionRepository jobDescriptionRepository, LinkGenerator linkGenerator)
        {
            _jobDescriptionRepository = jobDescriptionRepository;
            _linkGenerator = linkGenerator;
        }

        // GET: api/<JobDescriptionController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDescriptionDto>>> GetAllJobDescription()
        {
            try
            {
                var listOfJobdescription = await _jobDescriptionRepository.GetAllJobDescriptionAsync();
                return Ok(listOfJobdescription);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }

        // GET api/<JobDescriptionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobDescriptionDto>> GetJobDescriptionById(int id)
        {
            try
            {
                var getById = await _jobDescriptionRepository.GetJobDescriptionByIdAsync(id);
                if (getById is null) return NotFound(new Response { Success = false, Message = $"The job description with ID:{id} does not exist" });
                return Ok(getById);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }

        // POST api/<JobDescriptionController>
        [HttpPost]
        public async Task<ActionResult<JobDescriptionDto>> AddJobDescription([FromBody] JobDescriptionDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var addedJobDescription = await _jobDescriptionRepository.AddJobDescriptionAsync(model);
                    var location = _linkGenerator.GetPathByAction("GetJobDescriptionById", "JobDescription", new { id = model.JobDescriptionId });
                    if (string.IsNullOrWhiteSpace(location))
                    {
                        return BadRequest(new Response { Success = false, Message = "The uri is not available" });
                    }
                    return Created(location, addedJobDescription);
                }
                return BadRequest(new Response { Success = false, Message = "Invalid data" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, new Response { Success = false, Message = "Error occured" });
            }
        }

        // PUT api/<JobDescriptionController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<JobDescriptionDto>> UpdateJobDescription([FromBody] JobDescriptionDto model)
        {
            try
            {
                var updatedJobDescription = await _jobDescriptionRepository.UpdateJobDescription(model);
                return Ok(updatedJobDescription);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status304NotModified, new Response { Success = false, Message = "Error occured" });
            }
        }

        // DELETE api/<JobDescriptionController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteJobDescription(int id)
        {
            try
            {
                _jobDescriptionRepository.DeleteJobDescription(id);
                return Ok(new Response { Message = "The operation is successful", Success = true });
            }
            catch (Exception)
            {
                return BadRequest(new Response { Success = false, Message = "The operation is not successful" });
            }
        }
    }
}