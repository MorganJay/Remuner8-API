using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetAsync()
        {
            var companyItem = await _companyRepository.GetCompanyDetailsAsync();
            var mappedModel = _mapper.Map<IEnumerable<CompanyDto>>(companyItem);
            return Ok(mappedModel);
        }

        // GET api/<CompanyController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CompanyController>
        [HttpPost]
        public async Task<ActionResult> Post(CompanyDto companyDto)
        {
            var mappedModel = _mapper.Map<SystemDefault>(companyDto);
            await _companyRepository.CreateCompanyAsync(mappedModel);
            await _companyRepository.SaveAllAsync();
            return Ok();
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(CompanyDto companyDto)
        {
            try
            {
                var companyItem = await _companyRepository.GetCompanyDetailsAsync();
                if (companyItem is null)
                {
                    return NotFound();
                }
                var newCompanyType = _mapper.Map(companyDto, companyItem);
                _companyRepository.UpdateAsync((SystemDefault)companyItem);
                await _companyRepository.SaveAllAsync();
                return Ok(newCompanyType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //// DELETE api/<CompanyController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}