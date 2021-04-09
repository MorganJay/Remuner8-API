using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<ActionResult<IEnumerable<CompanyDetails>>> GetCompanyDetails()
        {
            var companyInfo = await repo.GetCompanyDetailsAsync();
            return Ok(companyInfo);
        }
    }
}