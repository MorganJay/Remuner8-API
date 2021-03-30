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
    public class CompanyDetailsController : ControllerBase
    {
        private readonly ICompanyRepository repo;

        public CompanyDetailsController(ICompanyRepository repo)
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