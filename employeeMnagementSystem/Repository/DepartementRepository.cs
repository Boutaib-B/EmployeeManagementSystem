using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Web.Http.ModelBinding;
using WebApplication1.Data;
using WebApplication1.dto;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class DepartementRepository : IDepartementRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;


        public DepartementRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Department> CreateDepartmentAsync(Department Dep)
        {
           await  _context.Departments.AddAsync(Dep);
            await _context.SaveChangesAsync();
            return Dep;

        }

        public async Task<Department> DeleteDepartmentAsync(int id)
        {
            var DepToDelete = await _context.Departments.FindAsync(id);

            if (DepToDelete != null)
            {
                _context.Departments.Remove(DepToDelete);
                await _context.SaveChangesAsync();
            }

            return DepToDelete;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentAsync()
        {
          return  await  _context.Departments.ToListAsync(); 
        }
        public async Task<Department> GetDepartmentByIdAsync(int emp_id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.DepartmentId == emp_id);
            //Include(_ => _.Address)
          // .Include(_ => _.Department)
            return department;
        }
        public async Task<Department> UpdateDepartmentAsync(int id, Department Dep_update)
        {
            var existingdep = await _context.Departments.Include(_ => _.Employees).FirstOrDefaultAsync(x => x.DepartmentId == id);


            if (existingdep != null)
            {
                existingdep.Name = Dep_update.Name;
                existingdep.Employees = Dep_update.Employees;

                // Mettez à jour les autres propriétés

                await _context.SaveChangesAsync();
            }

            return existingdep;
        }


    }


}








