using WebApplication1.dto;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IEmployeeRepository
    {
           Task<IEnumerable<Employee>> GetAllEmployeesAsync();
          Task<Employee> GetEmployeeByIdAsync(int id);
          Task<Employee> CreateEmployeeAsync(Employee employeedomainmodel);
          Task<Employee> UpdateEmployeeAsync(int id, Employee employeedomainmodel);
          Task<Employee> DeleteEmployeeAsync(int id);

        
    }
}
