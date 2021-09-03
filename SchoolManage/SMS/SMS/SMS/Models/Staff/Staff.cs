using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

#nullable disable

namespace SMS.Models
{
    public partial class Staff
    {
        [JsonIgnore]
        [IgnoreDataMember]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int StaffId { get; set; }

		//Salutation Dropdown
		public string SalutationId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }

        //Blood Group Dropdown
        public string BloodGroup { get; set; }
        public string Marritalsatus { get; set; }
        public DateTime WeddingDate { get; set; }
        public int ReligionId { get; set; }
        public string Gender { get; set; }
        public int NationalityId { get; set; }
        public long Mobile { get; set; }

        // LanguageDropDown
        public int MotherTongue { get; set; }

        //LanguagesDropdown
        [JsonIgnore]
        [IgnoreDataMember]
        public int LanguagesId { get; set; }
		//public Languages[] Languages { get; set; }
        public string EmailId { get; set; }
        public string AadharNumber { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string SpouseName { get; set; }
        public string FatherOccupation { get; set; }
        public string MotherOccupation { get; set; }
        public string SpouseOccupation { get; set; }
        public string FatherMobileNumber { get; set; }
        public string MotherMobileNumber { get; set; }
        public string SpouseMobileNumber { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankIfscCode { get; set; }
        public string PanNumber { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public int StaffAddressId { get; set; }

        //public StaffAddress[] Addresses { get; set; }

        public virtual ICollection<StaffAddress> Addresses { get; set; }

        public string TeacherId { get; set; }

        // Staff type drop Dwon
        public int StaffTypeId { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
        public int EmployeeId { get; set; }
        public string OfficialEmailId { get; set; }
        public string Esinumber { get; set; }
        public string Epfnumber { get; set; }

        //public int cityID { get; set; }

        //[ForeignKey(cityID)]

        //public City CityID { get; set; }

        // reporting To drop down TBD
        public int ReportingTo { get; set; }

        // Education Drop Dwon TBD
        public int EducationId { get; set; }

        // Employee Status DropDown
        public int EmployeementStatusId { get; set; }

        // Role Dropu Down
        public int RoleId { get; set; }
        public DateTime JoiningDate { get; set; }
        public int ActiveId { get; set; }
        public string Uannumber { get; set; }

        //public byte[] ProfilePic { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public int StaffExperienceId { get; set; }

        //public StaffExperience[] Experience { get; set; }

        public virtual ICollection<StaffExperience> experiences { get; set; }

        //[JsonIgnore]
        //[IgnoreDataMember]
        //public virtual ApplicationUser ApplicationUser { get; set; }

        //[JsonIgnore]
        //[IgnoreDataMember]
        //public virtual Department Department { get; set; }

        //[JsonIgnore]
        //[IgnoreDataMember]
        //public virtual Designation Designation { get; set; }

        //[JsonIgnore]
        //[IgnoreDataMember]
        //public virtual StaffType StaffType { get; set; }

        //[JsonIgnore]
        //[IgnoreDataMember]
        //public virtual EmployeementStatus EmployeementStatus { get; set; }

        //[JsonIgnore]
        //[IgnoreDataMember]
        //public virtual Nationality Nationality { get; set; }

        //[JsonIgnore]
        //[IgnoreDataMember]
        //public virtual Religion Religion { get; set; }
    }
}
