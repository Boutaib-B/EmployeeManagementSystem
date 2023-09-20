using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Salary
    {
        
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalaryId { get; set; }

        public int EmployeeId { get; set; } // Cette propriété sera utilisée comme clé étrangère
        public Employee Employee { get; set; }


        // Basic Salary
        public decimal BasicSalary { get; set; }

        // Allowances (e.g., housing, transport)
        public decimal Allowances { get; set; }

        // Deductions (e.g., taxes, insurance)
        public decimal Deductions { get; set; }

        // Total Salary (calculated property)
        public decimal TotalSalary
        {
            get
            {
               
                return BasicSalary + Allowances - Deductions;
            }
        }

        
    }

}
