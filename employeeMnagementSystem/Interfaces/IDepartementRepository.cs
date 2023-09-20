using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IDepartementRepository
    {
        Task<IEnumerable<Department>> GetAllDepartmentAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
        Task<Department> CreateDepartmentAsync(Department Departmentdomainmodel);
        Task<Department> UpdateDepartmentAsync(int id, Department Departmentedomainmodel);
        Task<Department> DeleteDepartmentAsync(int id);
    }
}
