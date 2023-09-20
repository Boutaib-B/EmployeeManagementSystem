using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readeRoleId = "fb0528db-8385-4a50-b18e-ac1c34d7ef28";
            var writerRoleId = "838552a9-7cee-49c3-aa42-d2db60eb15c2";
        var roles = new List<IdentityRole>
          {
            new IdentityRole
            {
                Id = readeRoleId,
                ConcurrencyStamp = readeRoleId,
                Name = "Reader",
                NormalizedName = "Reader".ToUpper()
            },
            new IdentityRole
            {
                Id = writerRoleId, ConcurrencyStamp = writerRoleId,Name = "Writer",NormalizedName ="Writer".ToUpper()
            }
          };
            builder.Entity<IdentityRole>().HasData (roles);
        }
       
    }
}
