using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DateExample.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public  DbSet<ToursEntity> Tours { get; set; }
        public  DbSet<SoldToursEntity> SoldTours { get; set; }

        public DbSet<PasswordPolicy> PasswordPolicies { get; set; }

    }
}
