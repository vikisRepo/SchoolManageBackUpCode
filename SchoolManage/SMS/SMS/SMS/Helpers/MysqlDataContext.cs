using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SMS.Models;
using SMS.Models.Academics;
using SMS.Models.Inventory;
using SMS.Models.Leave;
using SMS.Models.Setup;
using SMS.Models.TimeTable;
using SMS.Models.Transport;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class MysqlDataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public virtual DbSet<Subject> Subjects { get; set; }

        public virtual DbSet<AcademicClass> AcademicClasses { get; set; }

        public virtual DbSet<AcademicClassSubject> AcademicClassSubjects { get; set; }

        public virtual DbSet<LessonPlan> LessonPlans { get; set; }


        //leave tables

        public virtual DbSet<StudentLeave> StudentLeaves { get; set; }

        public virtual DbSet<StaffLeave> StaffLeaves { get; set; }

        #region "staff_Lookups"
        public virtual DbSet<Nationality> Nationalities { get; set; }

        public virtual DbSet<Religion> Religions { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<State> States { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Language> Languages { get; set; }

        public virtual DbSet<StaffType> StaffTypes { get; set; }

        public virtual DbSet<Designation> Designations { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Education> Educations { get; set; }

        public virtual DbSet<ReportingTo> ReportingTos { get; set; }

        public virtual DbSet<SchoolName> SchoolNames { get; set; }

        public virtual DbSet<Bank> Banks { get; set; }
        #endregion

        //public virtual DbSet<ClassTimeTable> ClassTimeTable { get; set; }

        //end Leave tables

        #region "Inventory"

        public virtual DbSet<InventoryDefect> InventoryDefects { get; set; }
        public virtual DbSet<InventoryItemType> InventoryItemTypes { get; set; }
        public virtual DbSet<InventoryItemUsageArea> InventoryItemUsageAreas { get; set; }
        public virtual DbSet<Inventory> Inventorys { get; set; }

        #endregion

        #region "Transport"
        public virtual DbSet<BusType> BusTypes { get; set; }
        public virtual DbSet<BusesAndDriver> BusesAndDrivers { get; set; }
        public virtual DbSet<BusTrip> BusTrips { get; set; }
        public virtual DbSet<NotificationSpan> NotificationSpans { get; set; }
        #endregion "Transport"

        public virtual DbSet<ClassTimeTable> ClassTimeTables { get; set; }

        public virtual DbSet<PeriodDetail> PeriodDetails { get; set; }

        private readonly IConfiguration Configuration;

        public MysqlDataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseMySQL(Configuration.GetConnectionString("WebApiDatabaseMySQL_Dev"));
            //options.
        }
    }
}