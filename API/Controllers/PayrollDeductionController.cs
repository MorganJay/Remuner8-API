using API.Authentication;
using API.Dtos;
using API.Models;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var entry = await _payrollDeductionRepository.GetAllItemsAsync();
            var model = _imapper.Map<IEnumerable<PayrollDeductionItemReadDto>>(entry);
            return Ok(model);
        }

        // GET api/<PayrollDeductionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult <PayrollDeductionItemReadDto>> GetItemAsync(int id)
        {
            var item = await _payrollDeductionRepository.GetItemAsync(id);
            if (item != null)
            {
                var model = _imapper.Map<PayrollDeductionItemReadDto>(item);
                return model;
            }
            return NotFound();
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
                    return StatusCode(StatusCodes.Status201Created, new Response { Status = "Success", Message = "Entry Successfully Created" });
                }
                return StatusCode(StatusCodes.Status400BadRequest);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "INternal Server Error", Message = "Server error occured" });
            }
            
            
        }

        // PUT api/<PayrollDeductionController>/5
        [HttpPatch("{id}")]
        public void Put(int id, [FromBody] string value)
        {
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
                    return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Entry Successfully Deleted" });
                }
                return NotFound(new Response { Status = "Error", Message = "Entry Not Found!" });
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "INternal Server Error", Message = "Server error occured" });
            }
            
        }
    }
}
