using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface ISalaryRepository
    {
        Task<IEnumerable<Salary>> GetAllSalariesAsync();
        Task<Salary> GetSalaryByIdAsync(int id);
        Task<Salary> CreateSalaryAsync(Salary Salarydomainmodel);
        Task<Salary> UpdateSalaryAsync(int id, Salary Salarydomainmodel);
        Task<Salary> DeleteSalaryAsync(int id);
    }
}
