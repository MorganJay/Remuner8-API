using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: /
        [HttpGet]
        public JsonResult ShowPhoto()
        {
            return new JsonResult("https://res.cloudinary.com/dhw0kymph/image/upload/v1615372245/Remuner8_fwt9rm.jpg");
        }
    }
}