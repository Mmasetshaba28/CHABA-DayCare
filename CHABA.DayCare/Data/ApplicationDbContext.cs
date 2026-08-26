using CHABA.DayCare.Models.Child;
using CHABA.DayCare.Models.Core;
using CHABA.DayCare.Models.Guardian;
using CHABA.DayCare.Models.Identity;
using CHABA.DayCare.Models.Staff;
using CHABA.DayCare.Models.Finance;
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
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Payment> Payments { get; set; }


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

            builder.Entity<Guardian>()
                .HasOne(g => g.Child)
                .WithMany()
                .HasForeignKey(g => g.ChildId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Staff>()
                .HasOne(s => s.Classroom)
                .WithMany()
                .HasForeignKey(s => s.ClassroomId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Payment>()
                .HasOne(p => p.Child)
                .WithMany()
                .HasForeignKey(p => p.ChildId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
