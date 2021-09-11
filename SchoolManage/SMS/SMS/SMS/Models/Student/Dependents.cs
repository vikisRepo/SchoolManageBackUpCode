using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMS.Models
{
    public class Dependents
    {
        [JsonIgnore]
        [IgnoreDataMember]
        public int DependentsId { get; set; }
        public string FirstName { get; set; }
        public String LastName { get; set; }
        public string MiddleName { get; set; }
        public long MobileNumber { get; set; }
        public string Occupation { get; set; }
        public string SalutationId { get; set; }

        public string AadharNumber { get; set; }
        public long AnnualIncome { get; set; }

        public bool BvEmployee { get; set; }

        public string Company { get; set; }

        public string Designation { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Student> Students { get; set; }
    }
}
