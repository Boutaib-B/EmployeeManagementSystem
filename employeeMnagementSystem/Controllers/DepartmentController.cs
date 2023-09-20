
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Repository;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.Identity.Client;
using AutoMapper;
using WebApplication1.dto;
using Microsoft.EntityFrameworkCore;
using WebApplication1.CustomActionFilter;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DepartmentsController : Controller
    {
        private readonly IDepartementRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public DepartmentsController(IDepartementRepository departmentRepository, IMapper mapper, DataContext dataContext)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _dataContext = dataContext;

        }

        [HttpGet]
        public async Task<IEnumerable<DepartmentDTO>> GetAllDepartments()
        {
            var depa_s = await _departmentRepository.GetAllDepartmentAsync();

            return _mapper.Map<IEnumerable<DepartmentDTO>>(depa_s);
        }

        [HttpGet]
        [Route("{emp_id:int}")]
        public async Task<IActionResult> GetEmployee([FromRoute] int dep_id)
        {
            var dep_s = await _departmentRepository.GetDepartmentByIdAsync(dep_id);
            if (dep_s == null)
            { return NotFound(); }
            return Ok(dep_s);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentrequestDTO createDepartmentrequestDTO)
        {
            //Convert DTO to DomainModel
            var depDomainModel = _mapper.Map<Department>(createDepartmentrequestDTO);

            //Use domain model to create client
            depDomainModel = await _departmentRepository.CreateDepartmentAsync(depDomainModel);
            //_context.Clients.Add(ClientDomainModel);
            //_context.SaveChanges();
            //Map  Domain Model back to DTO

            var Dep_dto = _mapper.Map<EmployeeDTO>(depDomainModel);

            return CreatedAtAction(nameof(CreateDepartment), new { id = Dep_dto.DepartmentId }, Dep_dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment([FromRoute] int id, [FromBody] UpdateDepartmentrequestDTO updateDepartmentrequestDTO)
        {
            var DepDomainModel = _mapper.Map<Department>(updateDepartmentrequestDTO);

            DepDomainModel = await _departmentRepository.UpdateDepartmentAsync(id,DepDomainModel);

            var Dep_dto = _mapper.Map<DepartmentDTO>(DepDomainModel);

            return Ok(Dep_dto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
        {
            var depdomainmodel = await _departmentRepository.DeleteDepartmentAsync(id);

            if (depdomainmodel == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<DepartmentDTO>(depdomainmodel));
        }

    }
}

