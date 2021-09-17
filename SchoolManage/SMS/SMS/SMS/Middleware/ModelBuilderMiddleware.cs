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
                new City { CityId = 1, cityDescr = " Chennai" },
                new City { CityId = 2, cityDescr = " Coimbatore" },
                new City { CityId = 3, cityDescr = " Madurai" },
                new City { CityId = 4, cityDescr = " Tiruchirappa" },
                new City { CityId = 5, cityDescr = " Salem" },
                new City { CityId = 6, cityDescr = " Tirunelveli" },
                new City { CityId = 7, cityDescr = " Tiruppur" },
                new City { CityId = 8, cityDescr = " Vellore" },
                new City { CityId = 9, cityDescr = " Erode" },
                new City { CityId = 10, cityDescr = " Thoothukkudi" },
                new City { CityId = 11, cityDescr = " Dindigul" },
                new City { CityId = 12, cityDescr = " Thanjavur" },
                new City { CityId = 13, cityDescr = " Ranipet" },
                new City { CityId = 14, cityDescr = " Sivakasi" },
                new City { CityId = 15, cityDescr = " Karur" },
                new City { CityId = 16, cityDescr = " Udhagamandal" },
                new City { CityId = 17, cityDescr = " Hosur" },
                new City { CityId = 18, cityDescr = " Nagercoil" },
                new City { CityId = 19, cityDescr = " Kanchipuram" },
                new City { CityId = 20, cityDescr = " Kumarapalaya" },
                new City { CityId = 21, cityDescr = " Karaikkudi" },
                new City { CityId = 22, cityDescr = " Neyveli" },
                new City { CityId = 23, cityDescr = " Cuddalore" },
                new City { CityId = 24, cityDescr = " Kumbakonam" },
                new City { CityId = 25, cityDescr = " Tiruvannamal" },
                new City { CityId = 26, cityDescr = " Pollachi" },
                new City { CityId = 27, cityDescr = " Rajapalayam" },
                new City { CityId = 28, cityDescr = " Gudiyatham" },
                new City { CityId = 29, cityDescr = " Pudukkottai" },
                new City { CityId = 30, cityDescr = " Vaniyambadi" },
                new City { CityId = 31, cityDescr = " Ambur" }
                );

            modelBuilder.Entity<Department>().HasData(
                  new Department { DepartmentId = 1, DepartmentName = " Admin" },
                  new Department { DepartmentId = 2, DepartmentName = " Finance" },
                  new Department { DepartmentId = 3, DepartmentName = " Library" },
                  new Department { DepartmentId = 4, DepartmentName = " IT" },
                  new Department { DepartmentId = 5, DepartmentName = " Non Teaching" },
                  new Department { DepartmentId = 6, DepartmentName = " English" },
                  new Department { DepartmentId = 7, DepartmentName = " Tamil" },
                  new Department { DepartmentId = 8, DepartmentName = " Maths" },
                  new Department { DepartmentId = 9, DepartmentName = " Science" },
                  new Department { DepartmentId = 10, DepartmentName = " Social Studies" },
                  new Department { DepartmentId = 11, DepartmentName = " Hindi" },
                  new Department { DepartmentId = 12, DepartmentName = " Commerce" },
                  new Department { DepartmentId = 13, DepartmentName = " Economics" },
                  new Department { DepartmentId = 14, DepartmentName = " Accounts" },
                  new Department { DepartmentId = 15, DepartmentName = " PET" }
             );

        }
    }
}
