using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi.Logic;

namespace TestApi.Controllers
{
    [Route("api/{version:apiVersion}/project")]
    [ApiController]
    public class ProjectController:Controller
    {
        private readonly IProjectLogic _projectLogic;

        public ProjectController(IProjectLogic projectLogic)
        {
            _projectLogic = projectLogic;
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult> GetProject([FromRoute] int projectId)
        {
            if (projectId == 0)
                return BadRequest();

            try
            {
                return Ok(await _projectLogic.GetById(projectId));
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch("{projectId}/AssignAction/{actionId}")]
        public async Task<ActionResult> AssignProjectAction([FromRoute] int projectId, [FromRoute] int actionId)
        {
            if (projectId == 0 || actionId == 0)
                return BadRequest();

            try
            {
                await _projectLogic.AddActionToProject(projectId, actionId);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}