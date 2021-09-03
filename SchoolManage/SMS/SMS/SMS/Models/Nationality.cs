using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

#nullable disable

namespace SMS.Models
{
    public partial class Nationality
    {
		//public Nationality()
		//{
		//	Staff = new HashSet<Staff>();
		//	Student = new HashSet<Student>();
		//}
		public int NationalityId { get; set; }
        public string NationalityName { get; set; }

		//[JsonIgnore]
		//[IgnoreDataMember]
		//public virtual ICollection<Staff> Staff { get; set; }

		//[JsonIgnore]
		//[IgnoreDataMember]
		//public virtual ICollection<Student> Student { get; set; }
	}
}
