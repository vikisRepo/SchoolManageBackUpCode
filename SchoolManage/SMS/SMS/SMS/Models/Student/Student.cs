using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

#nullable disable

namespace SMS.Models
{
    public class Student
    {

        [JsonIgnore]
        [IgnoreDataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentId { get; set; }



        //[JsonIgnore]
        //[IgnoreDataMember]
        //public StudentUserCred StudentUserCred { get; set; }

        public int? Salutation { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public int? BloodGroup { get; set; }
        public int? NationalityId { get; set; }
        public int? ReligionId { get; set; }
        public int? Gender { get; set; }
        public string EmailId { get; set; }
        public string AadharNumber { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public int StudentAddressId { get; set; }

        //[JsonIgnore]
        //[IgnoreDataMember]
        //public StudentAddress[] Addresses { get; set; }

        public virtual ICollection<StudentAddress> Addresses { get; set; }

        public long Mobile { get; set; }
        public int AdmissionNumber { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
        public string RollNo { get; set; }
        public int? FirstLanguage { get; set; }
        public int? SecondLanguage { get; set; }
        public string EmisNumber { get; set; }
        public string schoolName { get; set; }
        public int? schoolBrand { get; set; }
        public int? passingOutSchool { get; set; }
        public int yearofattendence { get; set; }
        public string AcademicPrecentage { get; set; }
        public string ReasonForLeaving { get; set; }
        //public byte[] ProfilePic { get; set; }
        //public byte[] TransferCertificate { get; set; }
        //public byte[] BirthCertificate { get; set; }
        //public byte[] Passport { get; set; }
        //public byte[] Aadhar { get; set; }
        //public byte[] RationCard { get; set; }
        //public byte[] StudentVisa {get;set;}


        //public string CurrentLine1 { get; set; }

        //public string CurrentLine2 { get; set; }

        //public string CurrentLine3 { get; set; }

        //public string CurrentCity { get; set; }

        //public string CurrentSate { get; set; }

        //public string CurrentCountry { get; set; }

        //public string CurrentPincode { get; set; }

        //public string PermenantLine1 { get; set; }

        //public string PermenantLine2 { get; set; }

        //public string PermenantLine3 { get; set; }

        //public string PermenantCity { get; set; }

        //public string PermenantSate { get; set; }

        //public string PermenantCountry { get; set; }

        //public string PermenantPincode { get; set; }

        //public string FatherFirstName { get; set; }
        //public String FatherLastName { get; set; }
        //public string FatherMiddleName { get; set; }
        //public long FatherMobileNumber { get; set; }
        //public string FatherOccupation { get; set; }
        //public string FatherSalutationId { get; set; }

        //public string FatherAadharNumber { get; set; }
        //public long FatherAnnualIncome { get; set; }

        //public bool FatherBvEmployee { get; set; }

        //public string FatherCompany { get; set; }

        //public string FatherDesignation { get; set; }

        //public string FatherEmail { get; set; }

        //public string MotherFirstName { get; set; }
        //public String MotherLastName { get; set; }
        //public string MotherMiddleName { get; set; }
        //public long MotherMobileNumber { get; set; }
        //public string MotherOccupation { get; set; }
        //public string MotherSalutationId { get; set; }

        //public string MotherAadharNumber { get; set; }
        //public long MotherAnnualIncome { get; set; }

        //public bool MotherBvEmployee { get; set; }

        //public string MotherCompany { get; set; }

        //public string MotherDesignation { get; set; }

        //public string MotherEmail { get; set; }

        //public string LegalFirstName { get; set; }
        //public String LegalLastName { get; set; }
        //public string LegalMiddleName { get; set; }
        //public long LegalMobileNumber { get; set; }
        //public string LegalOccupation { get; set; }
        //public string LegalSalutationId { get; set; }

        //public string LegalAadharNumber { get; set; }
        //public long LegalAnnualIncome { get; set; }

        //public bool LegalBvEmployee { get; set; }

        //public string LegalCompany { get; set; }

        //public string LegalDesignation { get; set; }

        //public string LegalEmail { get; set; }


        //public string LocalGuardianFirstName { get; set; }
        //public String LocalGuardianLastName { get; set; }
        //public string LocalGuardianMiddleName { get; set; }
        //public long LocalGuardianMobileNumber { get; set; }
        //public string LocalGuardianOccupation { get; set; }
        //public string LocalGuardianSalutationId { get; set; }

        //public string LocalGuardianAadharNumber { get; set; }
        //public long LocalGuardianAnnualIncome { get; set; }

        //public bool LocalGuardianBvEmployee { get; set; }

        //public string LocalGuardianCompany { get; set; }

        //public string LocalGuardianDesignation { get; set; }

        //public string LocalGuardianEmail { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public int DependentsId { get; set; }

        public virtual ICollection<Dependents> Dependentsdetails { get; set; }

    }
}
