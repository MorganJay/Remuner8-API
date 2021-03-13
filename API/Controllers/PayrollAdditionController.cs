using API.Authentication;
using API.Data_Models.Dtos;
using API.Models;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [ApiController]
    public class PayrollAdditionController : ControllerBase
    {
        private readonly IPayrollItemsRepository _payrollItemsRepository;
        private readonly IMapper _imapper;

        public PayrollAdditionController(IPayrollItemsRepository payrollItems, IMapper imapper)
        {
            _payrollItemsRepository = payrollItems;
            _imapper = imapper;
        }
        // GET: api/<PayrollAdditionController>
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<ActionResult <IEnumerable<PayrollAdditionItemReadDto>>> GetEntriesAsync()
        {
            return Ok(await _payrollItemsRepository.GetEntriesAsync());
        }

        // GET api/<PayrollAdditionController>/5
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult <PayrollAdditionItemReadDto>> ReadEntryAsync(int id)
        {
            try
            {
                var entry = await _payrollItemsRepository.GetEntryAsync(id);
                if (entry == null )
                {
                    return StatusCode(StatusCodes.Status204NoContent, new Response { Status = "Error", Message = "User Entry Does Not Exist" });
                }
                return Ok(entry);

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        // POST api/<PayrollAdditionController>
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<ActionResult> CreateEntryAsync(PayrollAdditionItemCreateDto payrollAdditionItemCreateDto)
        {
            var mappedmodel = _imapper.Map<PayrollAdditionItem>(payrollAdditionItemCreateDto);
            await _payrollItemsRepository.AddEntryAsync(mappedmodel);
            await _payrollItemsRepository.SavechangesAsync();
            return CreatedAtRoute(nameof(ReadEntryAsync), new {id = mappedmodel.Id}, mappedmodel);
        }

        //put api/<payrolladditioncontroller>/5
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult> UpdateEntry(int id, JsonPatchDocument<PayrollAdditionItemCreateDto> patchDoc)
        {
            try
            {
                var entrymodel = await _payrollItemsRepository.GetEntryAsync(id);
                if (entrymodel == null)
                {
                    return NotFound();
                }
                var entryToPatch = _imapper.Map<PayrollAdditionItemCreateDto>(entrymodel);
                patchDoc.ApplyTo(entryToPatch, ModelState);
                _imapper.Map(entryToPatch, entrymodel);
                if (await _payrollItemsRepository.SavechangesAsync())
                {
                    return Ok(_imapper.Map<PayrollAdditionItemCreateDto>(entrymodel));
                }
                return BadRequest();

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        // DELETE api/<PayrollAdditionController>/5
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _payrollItemsRepository.RemoveEntryAsync(id);
            await _payrollItemsRepository.SavechangesAsync();
            return Ok(new Response { Status = "Success", Message = "Entry Deleted Successfully" });
            
        }
    }
}

