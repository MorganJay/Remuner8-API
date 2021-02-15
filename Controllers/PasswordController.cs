using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Remuner8.EntityModels;
using Remuner8.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Remuner8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly ILoginRepository login;

        public PasswordController(ILoginRepository login)
        {
            this.login = login;
        }
        // GET: api/<PasswordController>
        [HttpPost]
        public ActionResult Validate([FromBody]PasswordModel model)
        {
            try
            {
                if (login.ValidateCredentials(model))
                {
                    return Ok();
                }
                return NotFound();

            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError);



            }
        }
    }
    }
