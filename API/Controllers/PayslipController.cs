using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public ActionResult<Payslip>GetPayslipById(string id)
        {
            var payslipItem = _payslipRepository.GetPayslipsById(id);
                return Ok(payslipItem);
        }
    }
}
