using crm_back_test.Data;
using crm_back_test.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace crm_back_test.Services.ProjectServices
{
    public class ProjectService : IProjectService
    {
        private readonly DataContext _context;

        public ProjectService(DataContext context)
        {
            _context = context;
        }

        public async Task<Project?> getProject(int projectId)
        {
            var project = await _context.Projects.FindAsync(projectId);

            return project;
        }

        public async Task<List<Project>?> getProjects()
        {
            var projects = await _context.Projects.ToListAsync();

            return projects;
        }

        public async Task<List<Project>?> postProject(Project newProject)
        {
            var project = await _context.Projects.Where(project => 
                project.Name.Equals(newProject.Name)).FirstOrDefaultAsync();

            if (project != null)
            {
                return null;
            }

            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync();

            return await _context.Projects.ToListAsync();
        }

        public async Task<List<Project>?> putProject(int projectId, Project newProject)
        {
            var project = await _context.Projects.FindAsync(projectId);

            if (project == null)
            {
                return null;
            }
        
            project.Name = (newProject.Name == "") ? project.Name : newProject.Name;
            project.Fee = (newProject.Fee == 0) ? project.Fee : newProject.Fee;
            project.Duration = (newProject.Duration == 0) ? project.Duration : newProject.Duration;
            project.StartDate = (newProject.StartDate == new DateTime(1900,01,01,0,0,0)) ? project.StartDate : newProject.StartDate;
            project.Installments = (newProject.Installments == 0) ? project.Installments : newProject.Installments;
            project.Status = (newProject.Status == "") ? project.Status : newProject.Status;
            project.Description = (newProject.Description == "") ? project.Description : newProject.Description;
            project.CustomerId = (newProject.CustomerId == 0) ? project.CustomerId : newProject.CustomerId;
            project.TechLeadId = (newProject.TechLeadId == 0) ? project.TechLeadId : newProject.TechLeadId;

            await _context.SaveChangesAsync();

            return await _context.Projects.ToListAsync();
        }

        public async Task<List<Project>?> deleteProject(int projectId)
        {
            var project = await _context.Projects.FindAsync(projectId);

            if (project == null)
            {
                return null;
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return await _context.Projects.ToListAsync();
        }
    }
}
