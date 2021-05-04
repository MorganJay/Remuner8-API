using API.Authentication;
using API.Dtos;
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
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollDeductionController : ControllerBase
    {
        private readonly IPayrollDeductionRepository _payrollDeductionRepository;
        private readonly IMapper _imapper;

        public PayrollDeductionController(IPayrollDeductionRepository payrollDeductionRepository, IMapper imapper)
        {
            _payrollDeductionRepository = payrollDeductionRepository;
            _imapper = imapper;
        }

        // GET: api/<PayrollDeductionController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PayrollDeductionItemReadDto>>> GetAsync()
        {
            try
            {
                var entry = await _payrollDeductionRepository.GetAllItemsAsync();
                var model = _imapper.Map<IEnumerable<PayrollDeductionItemReadDto>>(entry);
                return Ok(model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = "An Error Occurred!" });
            }
        }

        // GET api/<PayrollDeductionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PayrollDeductionItemReadDto>> GetItemAsync(int id)
        {
            try
            {
                var item = await _payrollDeductionRepository.GetItemAsync(id);
                if (item != null)
                {
                    var model = _imapper.Map<PayrollDeductionItemReadDto>(item);
                    return model;
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = "An Error Occurred!" });
            }
        }

        // POST api/<PayrollDeductionController>
        [HttpPost]
        public async Task<ActionResult> AddAsync(PayrollDeductionItemCreateDto payrollDeductionItemCreateDto)
        {
            try
            {
                var model = _imapper.Map<PayrollDeductionItem>(payrollDeductionItemCreateDto);
                var item = await _payrollDeductionRepository.GetItemAsync(model.Id);
                if (item == null)
                {
                    await _payrollDeductionRepository.AddItemsAsync(model);
                    await _payrollDeductionRepository.SaveChangesAsync();
                    var createdReadModel = _imapper.Map<PayrollDeductionItemReadDto>(model);
                    return CreatedAtRoute(nameof(GetItemAsync), new { createdReadModel.Id }, createdReadModel);
                }
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Success = false, Message = "Entry Already Exists" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = "Server Error Occured" });
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateEntry(int id, JsonPatchDocument<PayrollDeductionItemCreateDto> patchDoc)
        {
            try
            {
                var entrymodel = await _payrollDeductionRepository.GetItemAsync(id);
                if (entrymodel == null)
                {
                    return NotFound(new Response { Success = false, Message = $"The payroll item with ID {id} could not be found." });
                }
                var entryToPatch = _imapper.Map<PayrollDeductionItemCreateDto>(entrymodel);
                patchDoc.ApplyTo(entryToPatch, ModelState);

                _imapper.Map(entryToPatch, entrymodel);
                if (await _payrollDeductionRepository.SaveChangesAsync())
                {
                    return Ok(_imapper.Map<PayrollDeductionItemCreateDto>(entrymodel));
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = "An Error Occurred!" });
            }
        }

        // DELETE api/<PayrollDeductionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var item = _payrollDeductionRepository.GetItemAsync(id);
                if (item != null)
                {
                    await _payrollDeductionRepository.RemoveItemAsync(id);
                    await _payrollDeductionRepository.SaveChangesAsync();
                    return StatusCode(StatusCodes.Status200OK, new Response { Success = true, Message = "Entry Successfully Deleted" });
                }
                return NotFound(new Response { Success = false, Message = "Entry Not Found!" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = "An Error Occurred!" });
            }
        }
    }
}