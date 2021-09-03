using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SMS.Models.Academics;
using SMS.Models.Setup;
using SMS.Models.TimeTable;

#nullable disable

namespace SMS.Models
{
    public partial class SchoolManagementContext : IdentityDbContext
    {
        public SchoolManagementContext()
        {
        }

        public SchoolManagementContext(DbContextOptions<SchoolManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        //public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<Religion> Religions { get; set; }

        //public virtual DbSet<Role> Roles { get; set; }
        //public virtual DbSet<RoleFunction> RoleFunctions { get; set; }

        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentAddress> Addresses { get; set; }
        public virtual DbSet<EmployeementStatus> EmployeementStatuses { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<StaffExperience> StaffExperiences { get; set; }
        public virtual DbSet<StaffType> StaffTypes { get; set; }
		public virtual DbSet<Attachments> MyAttachments { get; set; }

		//public virtual DbSet<StaffUserCred> StaffUserCreds { get; set; }
		//public virtual DbSet<StudentUserCred> StudentUserCreds { get; set; }
		public virtual DbSet<ApplicationUser> ApplicationUsers  { get; set; }

		public virtual DbSet<StaffFeedback> StaffFeedbacks { get; set; }

        public virtual DbSet<Subject> Subjects { get; set; }

        public virtual DbSet<AcademicClass> AcademicClasses { get; set; }

        public virtual DbSet<AcademicClassSubject> AcademicClassSubjects { get; set; }

		public virtual DbSet<LessonPlan> LessonPlans { get; set; }

        public virtual DbSet<CourseDetail> CourseDetails { get; set; }

        public virtual DbSet<StudentCourseDetail> StudentCourseDetails { get; set; }

        public virtual DbSet<StaffeLetter> StaffeLetters { get; set; }

        public virtual DbSet<StudentFeedback> StudentFeedbacks { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=.;Database=SchoolSystem;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer("Server=tcp:bvschoolsystem.database.windows.net,1433;Initial Catalog=bvschoolsystem1;Persist Security Info=False;User ID=bv;Password=Sample123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<RoleFunction>(entity =>
            {
                entity.HasIndex(e => e.FunctionId, "IX_RoleFunctions_FunctionId");

                entity.HasIndex(e => e.RoleId, "IX_RoleFunctions_RoleId");

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.RoleFunctions)
                    .HasForeignKey(d => d.FunctionId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleFunctions)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId, "IX_Staffs_DepartmentId");

                entity.HasIndex(e => e.DesignationId, "IX_Staffs_DesignationId");

                entity.Property(e => e.Epfnumber).HasColumnName("EPFNumber");

                entity.Property(e => e.Esinumber).HasColumnName("ESINumber");

                entity.Property(e => e.Uannumber).HasColumnName("UANNumber");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
