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

        // GET: api/<PayrollAddition>
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<ActionResult<IEnumerable<PayrollAdditionItemReadDto>>> GetEntriesAsync()
        {
            try
            {
                var items = await _payrollItemsRepository.GetEntriesAsync();
                var model = _imapper.Map<IEnumerable<PayrollAdditionItemReadDto>>(items);
                return Ok(model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = "An Error Occurred!" });
            }
        }

        // GET api/<PayrollAddition>/5
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult<PayrollAdditionItemReadDto>> ReadEntryAsync(int id)
        {
            try
            {
                var entry = await _payrollItemsRepository.GetEntryAsync(id);
                if (entry == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, new Response { Success = false, Message = "User Entry Does Not Exist" });
                }
                return Ok(entry);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = "An Error Occurred!" });
            }
        }

        // POST api/<PayrollAddition>
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<ActionResult> CreateEntryAsync(PayrollAdditionItemCreateDto payrollAdditionItemCreateDto)
        {
            try
            {
                var mappedmodel = _imapper.Map<PayrollAdditionItem>(payrollAdditionItemCreateDto);
                await _payrollItemsRepository.AddEntryAsync(mappedmodel);
                await _payrollItemsRepository.SavechangesAsync();
                var createdReadModel = _imapper.Map<PayrollAdditionItemReadDto>(mappedmodel);
                return CreatedAtRoute(nameof(ReadEntryAsync), new { id = createdReadModel.Id }, createdReadModel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = "An Error Occurred!" });
            }
        }

        //patch api/<PayrollAddition>/5
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult> UpdateEntry(int id, JsonPatchDocument<PayrollAdditionItemCreateDto> patchDoc)
        {
            try
            {
                var entrymodel = await _payrollItemsRepository.GetEntryAsync(id);
                if (entrymodel is null) return NotFound();

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
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = "An Error Occurred!" });
            }
            throw new ArgumentNullException();
        }

        // DELETE api/<PayrollAddition>/5
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _payrollItemsRepository.RemoveEntryAsync(id);
                await _payrollItemsRepository.SavechangesAsync();
                return Ok(new Response { Success = true, Message = "Entry Deleted Successfully" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = "An Error Occurred!" });
            }
        }
    }
}