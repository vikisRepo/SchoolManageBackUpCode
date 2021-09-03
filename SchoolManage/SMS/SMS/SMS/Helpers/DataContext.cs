using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SMS.Models;
using SMS.Models.Academics;
using SMS.Models.Setup;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Staff> Staffs { get; set; }


        public virtual DbSet<Subject> Subjects { get; set; }

        public virtual DbSet<AcademicClass> AcademicClasses { get; set; }

        public virtual DbSet<AcademicClassSubject> AcademicClassSubjects { get; set; }
        public virtual DbSet<LessonPlan> LessonPlans { get; set; }

        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
            //options.
        }
    }
}