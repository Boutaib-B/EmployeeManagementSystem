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
   
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper, DataContext dataContext)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _dataContext = dataContext;

        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();

            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }

        [HttpGet]
        [Route("{emp_id:int}")]
        public async Task<IActionResult> GetEmployee([FromRoute] int emp_id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(emp_id);
            if (employee == null)
            { return NotFound(); }
            return Ok(employee);
        }

        [HttpPost]
         public async Task<IActionResult> CreateEmployee([FromBody] Employee2dto Employee2dto)
         {
        //Convert DTO to DomainModel
        var empDomainModel = _mapper.Map<Employee>(Employee2dto);

          //Use domain model to create client
          empDomainModel = await _employeeRepository.CreateEmployeeAsync(empDomainModel);
          //_context.Clients.Add(ClientDomainModel);
          //_context.SaveChanges();
          //Map  Domain Model back to DTO

          var Empldto = _mapper.Map<EmployeeDTO>(empDomainModel);

          return CreatedAtAction(nameof(CreateEmployee), new { id = Empldto.EmployeeId }, Empldto);
         }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] UpdateEmployeerequestDTO updateEmployeerequestDTO)
        {
            var EmpDomainModel = _mapper.Map<Employee>(updateEmployeerequestDTO);

            EmpDomainModel = await _employeeRepository.UpdateEmployeeAsync(id, EmpDomainModel);

            var Empdto = _mapper.Map<EmployeeDTO>(EmpDomainModel);

            return Ok(Empdto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            var clientdomainmodel = await _employeeRepository.DeleteEmployeeAsync(id);

            if (clientdomainmodel == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<EmployeeDTO>(clientdomainmodel));
        }

    }
}
