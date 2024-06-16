using Microsoft.EntityFrameworkCore;
using JobSearchApplication.Models;

namespace JobSearchApplication.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Jobseeker> Jobseekers { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define relationships and constraints if necessary
            modelBuilder.Entity<User>()
                .HasOne(u => u.Jobseeker)
                .WithOne(js => js.User)
                .HasForeignKey<Jobseeker>(js => js.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Employer)
                .WithOne(e => e.User)
                .HasForeignKey<Employer>(e => e.UserId);

            modelBuilder.Entity<Resume>()
                .HasOne(r => r.Jobseeker)
                .WithMany(u => u.Resumes)
                .HasForeignKey(r => r.JobseekerId);

            modelBuilder.Entity<Resume>()
                .HasOne(r => r.Location)
                .WithMany(l => l.Resumes)
                .HasForeignKey(r => r.LocationId);

            modelBuilder.Entity<Resume>()
                .HasOne(r => r.Category)
                .WithMany(c => c.Resumes)
                .HasForeignKey(r => r.CategoryId);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.Resume)
                .WithMany(r => r.Applications)
                .HasForeignKey(a => a.ResumeId);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.Job)
                .WithMany(j => j.Applications)
                .HasForeignKey(a => a.JobId);
            
            modelBuilder.Entity<Application>()
                .HasOne(a => a.Role)
                .WithMany(r => r.Applications)
                .HasForeignKey(a => a.RoleId);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.Status)
                .WithMany(s => s.Applications)
                .HasForeignKey(a => a.StatusId);


            modelBuilder.Entity<Job>()
                .HasOne(j => j.Location)
                .WithMany(l => l.Jobs)
                .HasForeignKey(j => j.LocationId);

            modelBuilder.Entity<Job>()
                .HasOne(j => j.Category)
                .WithMany(c => c.Jobs)
                .HasForeignKey(j => j.CategoryId);

            modelBuilder.Entity<Job>()
                .HasOne(j => j.Employer)
                .WithMany(e => e.Jobs)
                .HasForeignKey(j => j.EmployerId);
        }


    }
}
