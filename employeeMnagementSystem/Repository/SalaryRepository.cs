using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    
    public class SalaryRepository : ISalaryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;


        public SalaryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Salary> CreateSalaryAsync(Salary slr)
        {
            
            await _context.Salaries.AddAsync(slr);
            await _context.SaveChangesAsync();
            return slr;

        }

        public async Task<Salary> DeleteSalaryAsync(int id)
        {
            var  todelete = await _context.Salaries.FindAsync(id);

            if (todelete != null)
            {
                _context.Salaries.Remove(todelete);
                await _context.SaveChangesAsync();
            }

            return todelete;
        }

        public async Task<IEnumerable<Salary>> GetAllSalariesAsync()
        {
            return await _context.Salaries.ToListAsync();
        }


        public async Task<Salary> GetSalaryByIdAsync(int slr_id)
        {
            var salary = await _context.Salaries.FirstOrDefaultAsync(x => x.SalaryId == slr_id);
            //Include(_ => _.Address)
            // .Include(_ => _.Department)
            return salary;
        }
        public async Task<Project> UpdateSalaryAsync(int id, Salary slr_update)
        {
            var existingslr = await _context.Salaries.FirstOrDefaultAsync(x => x.SalaryId == id);


            if (existingslr != null)
            {
                existingslr.BasicSalary= slr_update.BasicSalary;
                existingslr.Allowances = slr_update.Allowances;
                existingslr.Deductions = slr_update.Deductions;

               
                existingslr.TotalSalary = slr_update.TotalSalary;

                // Mettez à jour les autres propriétés

                await _context.SaveChangesAsync();
            }

            return existingslr;
        }


    } 
}
