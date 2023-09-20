using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;


namespace WebApplication1.Models
{
    public class Department
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }

        public string? Name { get; set; }
       
        public string? Description { get; set; }

        public string? Location { get; set; }

        public string? DepatmentManager { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public ICollection<Project> Projects { get; set; }

      
    }
}
