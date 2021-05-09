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

        // POST api/<CompanyController>
        [HttpPost]
        public async Task<ActionResult> Post(CompanyDto companyDto)
        {
            var mappedModel = _mapper.Map<CompanyDetails>(companyDto);
            await _companyRepository.CreateCompanyAsync(mappedModel);
            await _companyRepository.SaveAllAsync();
            return Ok(mappedModel);
        }

        // PUT api/<CompanyController>
        [HttpPut]
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
                _companyRepository.UpdateAsync(newCompanyType);
                await _companyRepository.SaveAllAsync();
                return Ok(newCompanyType);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}