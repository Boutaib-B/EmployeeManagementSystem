using Microsoft.Owin.BuilderProperties;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace WebApplication1.Models
{
   
        public class Employee
        {
       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public Address Address { get; set; }

        public ICollection<Salary> Salaries { get; set; }

        public ICollection<EmployeeProject> EmployeeProjects { get; set; }

       
    }

 }

