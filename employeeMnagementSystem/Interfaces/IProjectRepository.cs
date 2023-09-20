using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task<Project> CreateProjectAsync(Project Projectdomainmodel);
        Task<Project> UpdateProjectAsync(int id, Project Projectdomainmodel);
        Task<Project> DeleteProjectAsync(int id);
    }
}
