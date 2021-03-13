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
    public class PayrollOvertimeController : ControllerBase
    {
        private readonly IPayrollOvertimeItemRepository _payrollOvertimeItemRepository;
        private readonly IMapper _mapper;

        public PayrollOvertimeController(IPayrollOvertimeItemRepository payrollOvertimeItemRepository, IMapper mapper)
        {
            _payrollOvertimeItemRepository = payrollOvertimeItemRepository;
            _mapper = mapper;
        }

        // GET: api/<PayrollOvertimeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PayrollOvertimeItemReadDto>>> GetAll()
        {
            var item = await _payrollOvertimeItemRepository.GetAllAsync();
            var model = _mapper.Map<IEnumerable<PayrollOvertimeItemReadDto>>(item);
            return Ok(item);
        }

        // GET api/<PayrollOvertimeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult <PayrollOvertimeItemReadDto>> GetItem(int id)
        {
            try
            {
                var item = await _payrollOvertimeItemRepository.GetItemAsync(id);
                if (item != null)
                {
                    var model = _mapper.Map<PayrollOvertimeItemReadDto>(item);
                    return Ok(model);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "INternal Server Error", Message = "Server error occured" });
            } 
        }

        // POST api/<PayrollOvertimeController>
        [HttpPost]
        public async Task<ActionResult> Additem(PayrollOvertimeItemCreateDto payrollOvertimeItemCreateDto)
        {
            try
            {
                var model = _mapper.Map<PayrollOvertimeItem>(payrollOvertimeItemCreateDto);
                var item = await _payrollOvertimeItemRepository.GetItemAsync(model.Id);
                if (item == null)
                {
                    await _payrollOvertimeItemRepository.AddItemAsync(model);
                    await _payrollOvertimeItemRepository.SaveAsync();
                    return StatusCode(StatusCodes.Status201Created, new Response { Status = "Success", Message = "Entry Successfully Created" });
                }
                return StatusCode(StatusCodes.Status400BadRequest);

            }
                catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "INternal Server Error", Message = "Server error occured" });
            }
            
        }


        // PUT api/<PayrollOvertimeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PayrollOvertimeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {  
                var item = await _payrollOvertimeItemRepository.GetItemAsync(id);
                if (item == null)
                {
                    return NotFound(new Response { Status = "Error", Message = "Entry Not Found!" });
                }
                await _payrollOvertimeItemRepository.DeleteItem(item.Id);
                await _payrollOvertimeItemRepository.SaveAsync();
                return Ok(new Response { Status = "Success", Message = "Entry Deleted Successfully!" });

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "INternal Server Error", Message = "Server error occured" });
            }
           

        }
    }
    
}
