using crm_back_test.Models;

namespace crm_back_test.Services.ProjectServices
{
    public interface IProjectService
    {
        public Task<Project?> getProject(int projectId);
        public Task<List<Project>?> getProjects();
        public Task<Project?> postProject(Project newProject);
        public Task<Project?> putProject(int projectId, Project newProject);
        public Task<Project?> deleteProject(int projectId);
    }
}
