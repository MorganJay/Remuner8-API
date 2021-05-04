using API.Authentication;
using API.Dtos;
using API.Models;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollRateController : ControllerBase
    {
        private readonly IPayrollRateRepository _rateRepository;
        private readonly IMapper _mapper;

        public PayrollRateController(IPayrollRateRepository rateRepository, IMapper mapper)
        {
            _rateRepository = rateRepository;
            _mapper = mapper;
        }

        // GET: api/<PayrollRateController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PayrollRateReadDto>>> GetAllAsync()
        {
            try
            {
                var rate = await _rateRepository.GetAllRatesAsync();
                var mappedModel = _mapper.Map<IEnumerable<PayrollRateReadDto>>(rate);
                return Ok(mappedModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }

        // GET api/<PayrollRateController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PayrollRateReadDto>> GetASync(int id)
        {
            try
            {
                var rate = await _rateRepository.GetRateByIdAsync(id);
                var mappedModel = _mapper.Map<PayrollRateReadDto>(rate);
                return Ok(mappedModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }

        // POST api/<PayrollRateController>
        [HttpPost]
        public async Task<ActionResult> PostRateAsync(PayrollRateCreateDto payrollRateCreateDto)
        {
            try
            {
                var mappedModel = _mapper.Map<PayrollRate>(payrollRateCreateDto);
                await _rateRepository.CreateRateAsync(mappedModel);
                await _rateRepository.SaveAsync();
                var createdReadModel = _mapper.Map<PayrollRateReadDto>(mappedModel);
                return CreatedAtRoute(nameof(GetASync), new { Id = createdReadModel.RateId }, createdReadModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }

        // PUT api/<PayrollRateController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, PayrollRateCreateDto payrollRateCreateDto)
        {
            try
            {
                var rate = await _rateRepository.GetRateByIdAsync(id);
                if (rate == null)
                {
                    return NotFound();
                }
                var putmodel = _mapper.Map(payrollRateCreateDto, rate);
                await _rateRepository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }

        // DELETE api/<PayrollRateController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveRateAsync(int id)
        {
            try
            {
                var rate = await _rateRepository.GetRateByIdAsync(id);
                if (rate == null)
                {
                    return NotFound();
                }
                _rateRepository.DeleteRate(rate);
                await _rateRepository.SaveAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }
    }
}