using API.Dtos;
using API.Models;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollCategoryController : ControllerBase
    {
        private readonly IPayrollCategoryRepository _payrollCategoryRepository;
        private readonly IMapper _mapper;

        public PayrollCategoryController(IPayrollCategoryRepository payrollCategoryRepository, IMapper mapper)
        {
            _payrollCategoryRepository = payrollCategoryRepository;
            _mapper = mapper;
        }

        // GET: api/<PayrollCategoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PayrollCategoryReadDto>>> GetAllAsync()
        {
            try
            {
                var category = await _payrollCategoryRepository.GetAllCategoriesAsync();
                var mappedModel = _mapper.Map<IEnumerable<PayrollCategoryReadDto>>(category);
                return Ok(mappedModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<PayrollCategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PayrollCategoryReadDto>> GetAsync(int id)
        {
            try
            {
                var category = await _payrollCategoryRepository.GetCategoryByIdAsync(id);
                var mappedModel = _mapper.Map<PayrollCategoryReadDto>(category);
                return Ok(mappedModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/<PayrollCategoryController>
        [HttpPost]
        public async Task<ActionResult> PostAsync(PayrollCategoryCreateDto payrollCategoryCreateDto)
        {
            var mappedModel = _mapper.Map<PayrollCategory>(payrollCategoryCreateDto);
            await _payrollCategoryRepository.CreateCategoryAsync(mappedModel);
            await _payrollCategoryRepository.SaveAsync();
            var createdReadModel = _mapper.Map<PayrollCategoryReadDto>(mappedModel);
            return CreatedAtRoute(nameof(GetAsync), new { Id = createdReadModel.CategoryId }, createdReadModel);
        }

        // PUT api/<PayrollCategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, PayrollCategoryCreateDto payrollCategoryCreateDto)
        {
            var existingCategory = await _payrollCategoryRepository.GetCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            _mapper.Map(payrollCategoryCreateDto, existingCategory);
            await _payrollCategoryRepository.SaveAsync();
            //return Ok(existingCategory);
            var CreatedReadModel = _mapper.Map<PayrollCategoryReadDto>(existingCategory);
            return Ok(CreatedReadModel);
        }

        // DELETE api/<PayrollCategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var category = await _payrollCategoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _payrollCategoryRepository.DeleteCategory(id);
            await _payrollCategoryRepository.SaveAsync();
            return Ok();
        }
    }
}