using crm_back_test.Models;

namespace crm_back_test.Services.ProjectServices
{
    public interface IProjectService
    {
        public Task<Project?> getProject(int projectId);
        public Task<List<Project>?> getProjects();
        public Task<List<Project>?> postProject(Project newProject);
        public Task<List<Project>?> putProject(int projectId, Project newProject);
        public Task<List<Project>?> deleteProject(int projectId);
    }
}
