using API.Dtos;
using API.Models;
using API.Repositories;
using API.Repository;
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
    public class CompanyDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyDetailsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<IActionResult> GetAllCompanyDetails()
        {
            var companyDetails = await _unitOfWork.CompanyDetails.GetAll();
            var result = _mapper.Map<IList<CompanyDto>>(companyDetails);
            return Ok(result);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public async Task<IActionResult> PostCompanyDetails([FromBody] CompanyDto companyDto)
        {
            var mappedModel = _mapper.Map<CompanyDetails>(companyDto);
            await _unitOfWork.CompanyDetails.Insert(mappedModel);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetAllCompanyDetails", new { id = mappedModel.CompanyId }, mappedModel);
        }

        // PUT api/<CompanyController>
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CompanyDto companyDto)
        {
            try
            {
                var companyItem = await _unitOfWork.CompanyDetails.Get(m => m.CompanyId == id);
                if (companyItem == null)
                {
                    return NotFound();
                }
                var newCompanyType = _mapper.Map(companyDto, companyItem);
                _unitOfWork.CompanyDetails.Update(newCompanyType);
                await _unitOfWork.Save();
                return Ok(newCompanyType);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}