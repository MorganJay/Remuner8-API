using API.Authentication;
using API.Dtos;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayslipsController : ControllerBase
    {
        private readonly IPayslipRepository _payslipRepository;

        public PayslipsController(IPayslipRepository payslipRepository)
        {
            _payslipRepository = payslipRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PayslipDto>> GetPayslipById(string id)
        {
            var getPaySlipById = await _payslipRepository.GetPayslipByIdAsync(id);
            if (getPaySlipById is null)
            {
                return BadRequest(new Response { Success = false, Message = $"The information with id={id} is not found" });
            }
            return Ok(getPaySlipById);
        }
    }
}