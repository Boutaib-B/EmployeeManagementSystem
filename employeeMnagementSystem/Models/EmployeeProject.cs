using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class EmployeeProject

    {
  
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeProjectId { get; set; }

        public string? Description { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }

       
    }
}
