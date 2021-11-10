using SMS.Models.Transport;
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

    [JsonIgnore]
    [IgnoreDataMember]
    public int DependentsId { get; set; }

    public virtual ICollection<Dependents> Dependentsdetails { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public int BusTripid { get; set; }

    //[JsonIgnore]
    //[IgnoreDataMember]
    //public virtual BusTrip StudentTrip { get; set; }

  }
}
