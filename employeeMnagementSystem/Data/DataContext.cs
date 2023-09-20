using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DataContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=localhost;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"); 
        }
        public DataContext(DbContextOptions<DataContext> options)
         : base(options)
        {
        }
        // Your other DbSet properties and configurations

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>()
                       .HasMany(e => e.Employees)
                       .WithOne(d => d.Department)
                       .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Address)
                .WithOne(a => a.Employee)
                .HasForeignKey<Address>(a => a.EmployeeId);


            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ep => ep.EmployeeId);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(ep => ep.ProjectId);
          

            modelBuilder.Entity<Project>()
               .HasOne(ep => ep.Department)
               .WithMany(p => p.Projects)
               .HasForeignKey(ep => ep.DepartmentId);

            modelBuilder.Entity<Salary>()
              .HasOne(ep => ep.Employee)
              .WithMany(p => p.Salaries)
              .HasForeignKey(p => p.EmployeeId);

                          

            modelBuilder.Entity<Salary>()
            .Property(s => s.BasicSalary)
            .HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Salary>()
            .Property(s => s.Allowances)
           .HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Salary>()
           .Property(s => s.Deductions)
          .HasColumnType("decimal(18, 2)");


      


        }
        public void CreateOrUpdateDatabase()
        {
            Database.Migrate();
        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        public DbSet<EmployeeProject> Salaries { get; set; }

    }
}








