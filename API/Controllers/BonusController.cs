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
    public class BonusController : ControllerBase
    {
        private readonly IBonusRepository _bonusRepository;
        private readonly LinkGenerator _linkGenerator;

        public BonusController(IBonusRepository bonusRepository, LinkGenerator linkGenerator)
        {
            _bonusRepository = bonusRepository;
            _linkGenerator = linkGenerator;
        }

        // GET: api/<BonusController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BonusDto>>> ListOfBonuses()
        {
            try
            {
                var listOfBonus = await _bonusRepository.GetAllBonusAsync();
                return Ok(listOfBonus);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<BonusController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BonusDto>> GetBonusById(int id)
        {
            try
            {
                return Ok(await _bonusRepository.GetBonusById(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<BonusController>
        [HttpPost]
        public async Task<ActionResult<BonusDto>> Post([FromBody] BonusDto model)
        {
            try
            {
                var createdBonus = await _bonusRepository.AddBonusAsync(model);
                var location = _linkGenerator.GetPathByAction("GetBonusByID", "Bonus", new { id = model.JobDescriptionId });
                if (string.IsNullOrWhiteSpace(location))
                {
                    return BadRequest($" the uri  was not found");
                }
                return Created(location, createdBonus);
            }
            catch (Exception)
            {
                return BadRequest(new Response { Status = "Error", Message = "The Process was not successful" });
            }
        }

        // PUT api/<BonusController>/5
        [HttpPut("{id}")]
        public ActionResult<BonusDto> Put([FromBody] BonusDto model)
        {
            try
            {
                var updatedBonus = _bonusRepository.UpdateBonus(model);
                return Ok(updatedBonus);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status304NotModified);
            }
        }

        // DELETE api/<BonusController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                if (_bonusRepository.DeleteBonus(id))
                {
                    return Ok(new Response { Status = "Success", Message = "The process was successsful" });
                }
                return BadRequest(new Response { Status = "Error", Message = "The process was not  successsful" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}