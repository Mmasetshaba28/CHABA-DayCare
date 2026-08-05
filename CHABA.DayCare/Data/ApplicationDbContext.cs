using CHABA.DayCare.Models.Child;
using CHABA.DayCare.Models.Core;
using CHABA.DayCare.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CHABA.DayCare.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Child> Children { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Child>()
                .HasOne(c => c.Classroom)
                .WithMany()
                .HasForeignKey(c => c.ClassroomId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Child>()
                .HasOne(c => c.Organisation)
                .WithMany()
                .HasForeignKey(c => c.OrganisationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
