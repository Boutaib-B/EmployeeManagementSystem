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
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;


        public ProjectRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Project> CreateProjectAsync(Project prj)
        {
            await _context.Projects.AddAsync(prj);
            await _context.SaveChangesAsync();
            return prj;

        }

        public async Task<Project> DeleteProjectAsync(int id)
        {
            var projToDelete = await _context.Projects.FindAsync(id);

            if (projToDelete != null)
            {
                _context.Projects.Remove(projToDelete);
                await _context.SaveChangesAsync();
            }

            return projToDelete;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }
        public async Task<Project> GetProjectByIdAsync(int prj_id)
        {
            var projet = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == prj_id);
            //Include(_ => _.Address)
            // .Include(_ => _.Department)
            return projet;
        }
        public async Task<Project> UpdateProjectAsync(int id, Project prj_update)
        {
            var existingprj = await _context.Projects
                .Include(_ => _.Department)
                .Include(_ => _.EmployeeProjects)
                .FirstOrDefaultAsync(x => x.DepartmentId == id);


            if (existingprj != null)
            {
                existingprj.Name = prj_update.Name;
                existingprj.Description = prj_update.Description;
                existingprj.Supervisor = prj_update.Supervisor;

                existingprj.EmployeeProjects = prj_update.EmployeeProjects;
                existingprj.Department = prj_update.Department;

                // Mettez à jour les autres propriétés

                await _context.SaveChangesAsync();
            }

            return existingprj;
        }


    }
}
