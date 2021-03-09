using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Authentication;
using API.Dtos;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/payslip")]
    [ApiController]
    public class PayslipController : ControllerBase
    {
        private readonly IPayslipRepository _payslipRepository;

        public PayslipController(IPayslipRepository payslipRepository)
        {
            _payslipRepository = payslipRepository;
        }
        [HttpGet("{id}")]
        public ActionResult<PayslipDto>GetPayslipById(string id)
        {
            var getPaySlipById = _payslipRepository.GetPayslipById(id);
            if (getPaySlipById == null)
            {
                return BadRequest(new Response { Status = "Error", Message = $"The information with id={id} is not found" });
            }
            return Ok (getPaySlipById);
        }
    }
}
