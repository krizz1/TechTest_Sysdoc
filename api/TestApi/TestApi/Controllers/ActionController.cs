using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi.Logic;

namespace TestApi.Controllers
{
    [Route("api/{version:apiVersion}/action")]
    [ApiController]
    public class ActionController : Controller
    {
        private readonly IActionLogic _actionLogic;

        public ActionController(IActionLogic actionLogic)
        {
            _actionLogic = actionLogic;
        }

        [HttpGet("{actionId}")]
        public async Task<ActionResult> GetAction([FromRoute] int actionId)
        {
            if (actionId == 0)
                return BadRequest();

            try
            {
                return Ok(await _actionLogic.GetById(actionId));
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetActions()
        {
            try
            {
                return Ok(await _actionLogic.GetAll());
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}