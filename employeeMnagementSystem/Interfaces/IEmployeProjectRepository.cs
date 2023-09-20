using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IEmployeProjectRepository
    {
        Task<IEnumerable<EmployeeProject>> GetAllEmployeeProjectsAsync();
        Task<EmployeeProject> GetEmployeeProjectByIdAsync(int id);
        Task<EmployeeProject> CreateEmployeeProjectAsync(EmployeeProject EmployeeProjectdomainmodel);
        Task<EmployeeProject> UpdateEmployeeProjectAsync(int id, EmployeeProject EmployeeProjectdomainmodel);
        Task<EmployeeProject> DeleteEmployeeProjectAsync(int id);

    }
}
