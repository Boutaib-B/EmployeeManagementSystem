using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace WebApplication1.Models
{
    public class Project
    {
       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      
        public int ProjectId { get; set; }


        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Supervisor { get; set; }

        public Department Department { get; set; }

        public int DepartmentId { get; set; }

        public ICollection<EmployeeProject> EmployeeProjects { get; set; }

      

    }
}
