using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.ModelBinding;
using WebApplication1.Data;
using WebApplication1.dto;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;


        public EmployeeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Employee> CreateEmployeeAsync(Employee empl)
        {
            
               
                _context.Employees.Add(empl);
                await _context.SaveChangesAsync();
                return empl;
           
        }

        public async Task<Employee> DeleteEmployeeAsync(int id)
        {
            var EmployeeToDelete = await _context.Employees.FindAsync(id);

            if (EmployeeToDelete != null)
            {
                _context.Employees.Remove(EmployeeToDelete);
                await _context.SaveChangesAsync();
            }

            return EmployeeToDelete;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {

            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int emp_id)
        {
            var employee = await _context.Employees.Include(_ => _.Address)
                                                   .Include(_ => _.Department)
                                                   .FirstOrDefaultAsync(x => x.EmployeeId == emp_id);

            return employee;
        }
       

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employupdate)
        {
            var existingEmployee = await _context.Employees.Include(_ => _.Address).FirstOrDefaultAsync(x => x.EmployeeId == id);


            if (existingEmployee != null)
            {
                existingEmployee.FirstName = employupdate.FirstName;
                existingEmployee.LastName = employupdate.LastName;

                if (existingEmployee.Address != null && employupdate.Address != null)
                {
                    existingEmployee.Address.Street = employupdate.Address.Street;
                    existingEmployee.Address.City = employupdate.Address.City;
                    existingEmployee.Address.State = employupdate.Address.State;
                    existingEmployee.Address.ZipCode = employupdate.Address.ZipCode;
                }
              
                    // Mettez à jour les autres propriétés

                    await _context.SaveChangesAsync();
            }

            return existingEmployee;
        }


    }


}










