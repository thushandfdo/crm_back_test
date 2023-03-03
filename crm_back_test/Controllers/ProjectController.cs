using crm_back_test.Models;
using crm_back_test.Services.ProjectServices;
using crm_back_test.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crm_back_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<Project?>> getProject(int projectId)
        {
            var user = await _projectService.getProject(projectId);

            if (user == null)
            {
                return NotFound("Project does not exist");
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<Project>?>> getProjects()
        {
            var users = await _projectService.getProjects();

            if (users == null)
            {
                return NotFound("Project list is Empty..!");
            }

            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<List<Project>?>> postProject(Project newProject)
        {
            var users = await _projectService.postProject(newProject);

            if (users == null)
            {
                return NotFound("Project is already exist..!");
            }

            return Ok(users);
        }

        [HttpPut("{projectId}")]
        public async Task<ActionResult<List<Project>?>> putProject(int projectId, Project newProject)
        {
            var projects = await _projectService.putProject(projectId, newProject);

            if (projects == null)
            {
                return NotFound("Project is not found..!");
            }

            return Ok(projects);
        }

        [HttpDelete("{projectId}")]
        public async Task<ActionResult<List<Project>?>> deleteProject(int projectId)
        {
            var users = await _projectService.deleteProject(projectId);

            if (users == null)
            {
                return NotFound("Project is not found..!");
            }

            return Ok(users);
        }
    }
}
