using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("company")]
    public class CompanyController : ControllerBase
    {
        [HttpGet("Hello")]
        public string Hello()
        {
            return "Hello";
        }
    }
}
