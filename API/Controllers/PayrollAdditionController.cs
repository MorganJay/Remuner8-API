using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollAdditionController : ControllerBase
    {
        public PayrollAdditionController()
        {
                
        }
        // GET: api/<PayrollAdditionController>
        [HttpGet]
        public IEnumerable<string> GetEntriesAsync()
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/<PayrollAdditionController>/5
        [HttpGet("{id}")]
        public string GetEntryAsync(int id)
        {
            return "value";
        }

        // POST api/<PayrollAdditionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PayrollAdditionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PayrollAdditionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
