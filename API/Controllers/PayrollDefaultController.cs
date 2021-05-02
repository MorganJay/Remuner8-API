using API.Dtos;
using API.Models;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollDefaultController : ControllerBase
    {
        private readonly IPayrollDefaultRepository _payrollDefaultRepository;
        private readonly IMapper _mapper;

        public PayrollDefaultController(IPayrollDefaultRepository payrollDefaultRepository, IMapper mapper)
        {
            _payrollDefaultRepository = payrollDefaultRepository;
            _mapper = mapper;
        }

        // GET: api/<PayrollDefaultController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PayrollDefaultReadDto>>> GetAll()
        {
            var item = await _payrollDefaultRepository.GetAllDefaultsAsync();
            var mappedModel = _mapper.Map<PayrollDefaultCreateDto>(item);
            return Ok(mappedModel);
        }

        // GET api/<PayrollDefaultController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PayrollDefaultReadDto>> Get(int id)
        {
            var item = await _payrollDefaultRepository.GetDefaultByIdAsync(id);
            var mappedModel = _mapper.Map<PayrollDefaultReadDto>(item);
            return Ok(mappedModel);
        }

        // POST api/<PayrollDefaultController>
        [HttpPost]
        public async Task<ActionResult> Post(PayrollDefaultCreateDto payrollDefaultCreateDto)
        {
            var mappedModel = _mapper.Map<PayrollDefault>(payrollDefaultCreateDto);
            await _payrollDefaultRepository.CreateDefaultAsync(mappedModel);
            await _payrollDefaultRepository.SaveAsync();
            var createdReadModel = _mapper.Map<PayrollDefaultReadDto>(mappedModel);
            return CreatedAtRoute(nameof(Get), new { Id = createdReadModel.Id }, createdReadModel);
        }

        // PUT api/<PayrollDefaultController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, PayrollDefaultCreateDto payrollDefaultCreateDto)
        {
            var item = await _payrollDefaultRepository.GetDefaultByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            var putModel = _mapper.Map(payrollDefaultCreateDto, item);
            await _payrollDefaultRepository.SaveAsync();
            return Ok(putModel);
        }

        // DELETE api/<PayrollDefaultController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _payrollDefaultRepository.GetDefaultByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            _payrollDefaultRepository.DeleteDefault(id);
            await _payrollDefaultRepository.SaveAsync();
            return Ok();
        }
    }
}