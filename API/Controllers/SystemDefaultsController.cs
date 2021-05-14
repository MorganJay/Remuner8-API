using API.Dtos;
using API.Models;
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
    public class SystemDefaultsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SystemDefaultsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<IActionResult> GetAllSystemDefaults()
        {
            var SystemDefaults = await _unitOfWork.SystemDefault.GetAll();
            var result = _mapper.Map<IList<SystemDefaultDto>>(SystemDefaults);
            return Ok(result);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public async Task<IActionResult> PostSystemDefaults([FromBody] SystemDefaultDto companyDto)
        {
            var mappedModel = _mapper.Map<SystemDefault>(companyDto);
            await _unitOfWork.SystemDefault.Insert(mappedModel);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetAllSystemDefaults", new { id = mappedModel.CompanyId }, mappedModel);
        }

        // PUT api/<CompanyController>
        [HttpPut]
        public async Task<ActionResult> PutSystemDefault(int id, [FromBody] SystemDefaultDto companyDto)
        {
            try
            {
                var companyItem = await _unitOfWork.SystemDefault.Get(m => m.CompanyId == id);
                if (companyItem == null)
                {
                    return NotFound();
                }
                var newCompanyType = _mapper.Map(companyDto, companyItem);
                _unitOfWork.SystemDefault.Update(newCompanyType);
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