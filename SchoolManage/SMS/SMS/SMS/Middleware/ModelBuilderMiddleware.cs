using Microsoft.EntityFrameworkCore;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Middleware
{
    public static class ModelBuilderMiddleware
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>().HasData(
                new Bank { BankId = 1, BankDescr = "State Bank of India (SBI)" },
                new Bank { BankId = 2, BankDescr = "Punjab National Bank" },
                new Bank { BankId = 3, BankDescr = "Bank of Baroda (With Merger of Dena Bank & Vijaya Bank)" },
                new Bank { BankId = 4, BankDescr = "Canara Bank (With Merger of Syndicate Bank)" },
                new Bank { BankId = 5, BankDescr = "Union Bank of India (With Merger of Andhra Bank and Corporation Bank)" },
                new Bank { BankId = 6, BankDescr = "Indian Bank (With Merger of Allahabad Bank)" },
                new Bank { BankId = 7, BankDescr = "Central Bank of India" },
                new Bank { BankId = 8, BankDescr = "UCO Bank" },
                new Bank { BankId = 9, BankDescr = "Bank of Maharashtra" },
                new Bank { BankId = 10, BankDescr = "Punjab & Sindh Bank" },
                new Bank { BankId = 11, BankDescr = "Bandhan Bank" },
                new Bank { BankId = 12, BankDescr = "Catholic Syrian Bank" },
                new Bank { BankId = 13, BankDescr = "City Union Bank" },
                new Bank { BankId = 14, BankDescr = "DCB Bank" },
                new Bank { BankId = 15, BankDescr = "Dhanlaxmi Bank" },
                new Bank { BankId = 16, BankDescr = "Federal Bank" },
                new Bank { BankId = 17, BankDescr = "HDFC Bank" },
                new Bank { BankId = 18, BankDescr = "ICICI Bank" },
                new Bank { BankId = 19, BankDescr = "IDBI Bank" },
                new Bank { BankId = 20, BankDescr = "IDFC First Bank" },
                new Bank { BankId = 21, BankDescr = "Jammu & Kashmir Bank" },
                new Bank { BankId = 22, BankDescr = "Karur Vysya Bank" },
                new Bank { BankId = 23, BankDescr = "Lakshmi Vilas Bank" },
                new Bank { BankId = 24, BankDescr = "Nainital Bank" },
                new Bank { BankId = 25, BankDescr = "RBL Bank" },
                new Bank { BankId = 26, BankDescr = "South Indian Bank" },
                new Bank { BankId = 27, BankDescr = "Tamilnad Mercantile Bank Limited" },
                new Bank { BankId = 28, BankDescr = "Axis Bank" },
                new Bank { BankId = 29, BankDescr = "Kotak Mahindra Bank" },
                new Bank { BankId = 30, BankDescr = "Bank of India" },
                new Bank { BankId = 31, BankDescr = "Canara Bank" },
                new Bank { BankId = 32, BankDescr = "IndusInd Bank" },
                new Bank { BankId = 33, BankDescr = "YES Bank" },
                new Bank { BankId = 34, BankDescr = "Karnataka Bank" },
                new Bank { BankId = 35, BankDescr = "Indian Overseas Bank" },
                new Bank { BankId = 36, BankDescr = "Union Bank of India (Andhra Bank & Corporation Bank)" }

            );

            modelBuilder.Entity<City>().HasData(
                new City { CityId = 1, cityDescr = "Chennai" },
                new City { CityId = 2, cityDescr = "Coimbatore" },
                new City { CityId = 3, cityDescr = "Madurai" },
                new City { CityId = 4, cityDescr = "Tiruchirappa" },
                new City { CityId = 5, cityDescr = "Salem" },
                new City { CityId = 6, cityDescr = "Tirunelveli" },
                new City { CityId = 7, cityDescr = "Tiruppur" },
                new City { CityId = 8, cityDescr = "Vellore" },
                new City { CityId = 9, cityDescr = "Erode" },
                new City { CityId = 10, cityDescr = "Thoothukkudi" },
                new City { CityId = 11, cityDescr = "Dindigul" },
                new City { CityId = 12, cityDescr = "Thanjavur" },
                new City { CityId = 13, cityDescr = "Ranipet" },
                new City { CityId = 14, cityDescr = "Sivakasi" },
                new City { CityId = 15, cityDescr = "Karur" },
                new City { CityId = 16, cityDescr = "Udhagamandal" },
                new City { CityId = 17, cityDescr = "Hosur" },
                new City { CityId = 18, cityDescr = "Nagercoil" },
                new City { CityId = 19, cityDescr = "Kanchipuram" },
                new City { CityId = 20, cityDescr = "Kumarapalaya" },
                new City { CityId = 21, cityDescr = "Karaikkudi" },
                new City { CityId = 22, cityDescr = "Neyveli" },
                new City { CityId = 23, cityDescr = "Cuddalore" },
                new City { CityId = 24, cityDescr = "Kumbakonam" },
                new City { CityId = 25, cityDescr = "Tiruvannamal" },
                new City { CityId = 26, cityDescr = "Pollachi" },
                new City { CityId = 27, cityDescr = "Rajapalayam" },
                new City { CityId = 28, cityDescr = "Gudiyatham" },
                new City { CityId = 29, cityDescr = "Pudukkottai" },
                new City { CityId = 30, cityDescr = "Vaniyambadi" },
                new City { CityId = 31, cityDescr = "Ambur" }
                );

            modelBuilder.Entity<Department>().HasData(
                  new Department { DepartmentId = 1, DepartmentName = "Admin" },
                  new Department { DepartmentId = 2, DepartmentName = "Finance" },
                  new Department { DepartmentId = 3, DepartmentName = "Library" },
                  new Department { DepartmentId = 4, DepartmentName = "IT" },
                  new Department { DepartmentId = 5, DepartmentName = "Non Teaching" },
                  new Department { DepartmentId = 6, DepartmentName = "English" },
                  new Department { DepartmentId = 7, DepartmentName = "Tamil" },
                  new Department { DepartmentId = 8, DepartmentName = "Maths" },
                  new Department { DepartmentId = 9, DepartmentName = "Science" },
                  new Department { DepartmentId = 10, DepartmentName = "Social Studies" },
                  new Department { DepartmentId = 11, DepartmentName = "Hindi" },
                  new Department { DepartmentId = 12, DepartmentName = "Commerce" },
                  new Department { DepartmentId = 13, DepartmentName = "Economics" },
                  new Department { DepartmentId = 14, DepartmentName = "Accounts" },
                  new Department { DepartmentId = 15, DepartmentName = "PET" }
             );

            modelBuilder.Entity<EmployeementStatus>().HasData(
                  new EmployeementStatus { EmployeementStatusId = 1, Description = "Active" },
                  new EmployeementStatus { EmployeementStatusId = 2, Description = "In active" },
                  new EmployeementStatus { EmployeementStatusId = 3, Description = "Terminated" },
                  new EmployeementStatus { EmployeementStatusId = 4, Description = "In Leave" }
                );

            modelBuilder.Entity<Designation>().HasData(
                 new Designation { DesignationId = 1, DesignationName = "Teacher" },
                 new Designation { DesignationId = 2, DesignationName = "Co-ordinator" },
                 new Designation { DesignationId = 3, DesignationName = "HOD" },
                 new Designation { DesignationId = 4, DesignationName = "Non-Teaching" },
                 new Designation { DesignationId = 5, DesignationName = "Office Associate" },
                 new Designation { DesignationId = 6, DesignationName = "Finance Associate" },
                 new Designation { DesignationId = 7, DesignationName = "Principal" },
                 new Designation { DesignationId = 8, DesignationName = "Librarian" },
                 new Designation { DesignationId = 9, DesignationName = "Vice Principal" }
               );

            modelBuilder.Entity<Bloodgroup>().HasData(
                 new Bloodgroup { BloodgroupId = 1, BloodgroupName = "(A +)" },
                 new Bloodgroup { BloodgroupId = 2, BloodgroupName = "(A -)" },
                 new Bloodgroup { BloodgroupId = 3, BloodgroupName = "(B +)" },
                 new Bloodgroup { BloodgroupId = 4, BloodgroupName = "(B -)" },
                 new Bloodgroup { BloodgroupId = 5, BloodgroupName = "(O +)" },
                 new Bloodgroup { BloodgroupId = 6, BloodgroupName = "(O -)" },
                 new Bloodgroup { BloodgroupId = 7, BloodgroupName = "(AB +)" },
                 new Bloodgroup { BloodgroupId = 8, BloodgroupName = "(AB -)" }
                );

            modelBuilder.Entity<MaritalStatus>().HasData(
                new MaritalStatus { MaritalStatusId = 1, MaritalStatusName = "Married" },
                new MaritalStatus { MaritalStatusId = 2, MaritalStatusName = "Widowed" },
                new MaritalStatus { MaritalStatusId = 3, MaritalStatusName = "Separated" },
                new MaritalStatus { MaritalStatusId = 4, MaritalStatusName = "Divorced" },
                new MaritalStatus { MaritalStatusId = 5, MaritalStatusName = "Single" }
               );
            
            modelBuilder.Entity<Religion>().HasData(
                new Religion { ReligionId = 1, ReligionName = "Hindu" },
                new Religion { ReligionId = 2, ReligionName = "Christian" },
                new Religion { ReligionId = 3, ReligionName = "Muslim" },
                new Religion { ReligionId = 4, ReligionName = "Sikh" },
                new Religion { ReligionId = 5, ReligionName = "Buddhist" },
                new Religion { ReligionId = 6, ReligionName = "Jains" },
                new Religion { ReligionId = 7, ReligionName = "Others" },
                new Religion { ReligionId = 8, ReligionName = "Not willing to disclose" }
               );

            modelBuilder.Entity<Gender>().HasData(
                new Gender { GenderId = 1, GenderName = "Male" },
                new Gender { GenderId = 2, GenderName = "Female" },
                new Gender { GenderId = 3, GenderName = "Trans" },
                new Gender { GenderId = 4, GenderName = "Not willing to disclose" }
               );

            modelBuilder.Entity<Nationality>().HasData(
               new Nationality { NationalityId = 1, NationalityName = "Indian" },
               new Nationality { NationalityId = 2, NationalityName = "Others" },
               new Nationality { NationalityId = 3, NationalityName = "Not willing to disclose" }
              ); 

             modelBuilder.Entity<Salutation>().HasData(
               new Salutation { SalutationId = 1, SalutationName = "Mr." },
               new Salutation { SalutationId = 2, SalutationName = "Mrs." },
               new Salutation { SalutationId = 3, SalutationName = "Miss" },
               new Salutation { SalutationId = 4, SalutationName = "Master" }
              );

            modelBuilder.Entity<Language>().HasData(
                  new Language { LanguageId = 1, LanguageDescription = "Hindi" },
                  new Language { LanguageId = 2, LanguageDescription = "English" },
                  new Language { LanguageId = 3, LanguageDescription = "Bengali" },
                  new Language { LanguageId = 4, LanguageDescription = "Marathi" },
                  new Language { LanguageId = 5, LanguageDescription = "Telugu" },
                  new Language { LanguageId = 6, LanguageDescription = "Tamil" },
                  new Language { LanguageId = 7, LanguageDescription = "Gujarati" },
                  new Language { LanguageId = 8, LanguageDescription = "Urdu" },
                  new Language { LanguageId = 9, LanguageDescription = "Kannada" },
                  new Language { LanguageId = 10, LanguageDescription = "Odia" },
                  new Language { LanguageId = 11, LanguageDescription = "Malayalam" },
                  new Language { LanguageId = 12, LanguageDescription = "Punjabi" },
                  new Language { LanguageId = 13, LanguageDescription = "Assamese" },
                  new Language { LanguageId = 14, LanguageDescription = "French" },
                  new Language { LanguageId = 15, LanguageDescription = "Others" }
             );

            modelBuilder.Entity<StaffType>().HasData(
                  new StaffType { StaffTypeId = 1, Description = "Teacher" },
                  new StaffType { StaffTypeId = 2, Description = "Admin" },
                  new StaffType { StaffTypeId = 3, Description = "Principal" },
                  new StaffType { StaffTypeId = 4, Description = "Co-ordinator" },
                  new StaffType { StaffTypeId = 5, Description = "Support Staff" },
                  new StaffType { StaffTypeId = 6, Description = "Driver" },
                  new StaffType { StaffTypeId = 7, Description = "IT Technician" },
                  new StaffType { StaffTypeId = 8, Description = "Vice Principal" },
                  new StaffType { StaffTypeId = 9, Description = "Librarian" },
                  new StaffType { StaffTypeId = 10, Description = "Lab Staff" },
                  new StaffType { StaffTypeId = 11, Description = "PET" },
                  new StaffType { StaffTypeId = 12, Description = "HOD" }
            );

            modelBuilder.Entity<Role>().HasData(
                            new Role { RoleId = 1, Description = " Super Admin" },
                            new Role { RoleId = 2, Description = " Admin" },
                            new Role { RoleId = 3, Description = " Finance Admin" },
                            new Role { RoleId = 4, Description = " Student" },
                            new Role { RoleId = 5, Description = " Teacher" },
                            new Role { RoleId = 6, Description = " Inventory Admin" },
                            new Role { RoleId = 7, Description = " Library Admin" }
                                );

        }
    }
}

