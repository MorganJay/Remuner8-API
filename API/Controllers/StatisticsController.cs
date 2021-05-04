using API.Authentication;
using API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public StatisticsController(IStatisticsRepository statistics)
        {
            _statisticsRepository = statistics;
        }

        // GET: api/Statistics
        [HttpGet]
        public async Task<ActionResult<int>> GetStatistics()
        {
            try
            {
                var departmentCount = await _statisticsRepository.DepartmentsCountAsync();
                var employeeCount = await _statisticsRepository.EmployeeCountAsync();

                return Ok(new { Departments = departmentCount, Employees = employeeCount });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }
    }
}