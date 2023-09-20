using System.ComponentModel.DataAnnotations;

namespace WebApplication1.dto
{
    public class EmployeeDTO
    {
        [Required]
        [MaxLength(100)]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string? LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public int DepartmentId { get; set; }
        // Add other properties you want to expose to clients
    }
}
