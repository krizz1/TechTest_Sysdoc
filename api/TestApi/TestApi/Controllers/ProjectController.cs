using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestApi.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController:Controller
    {
        [HttpGet("test")]
        public async Task<ActionResult<object>> Get()
        {
            return new 
            {
                message = "Hello world"
            };
        }
    }
}