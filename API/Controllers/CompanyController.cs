using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository repo;

        public CompanyController(ICompanyRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemDefault>>> GetCompanyDetails()
        {
            var companyInfo = await repo.GetCompanyDetailsAsync();
            return Ok(companyInfo);
        }
    }
}