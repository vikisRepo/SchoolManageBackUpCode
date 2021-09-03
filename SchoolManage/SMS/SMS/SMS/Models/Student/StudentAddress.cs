using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMS.Models
{
	public class StudentAddress
	{
		//public StudentAddress()
		//{
		//	Staff = new HashSet<Staff>();
		//	Student = new HashSet<Student>();
		//}

		[JsonIgnore]
		[IgnoreDataMember]
		public int StudentAddressId { get; set; }
		[JsonIgnore]
		[IgnoreDataMember]

		public int StudentId { get; set; }
		public string Line1 { get; set; }

		public string Line2 { get; set; }

		public string Line3 { get; set; }

		public string City { get; set; }

		public string Sate { get; set; }

		public string Country { get; set; }

		public string Pincode { get; set; }

		//[JsonIgnore]
		//[IgnoreDataMember]
		//public virtual ICollection<Staff> Staff { get; set; }

		//[JsonIgnore]
		//[IgnoreDataMember]
		//public virtual ICollection<Student> Student { get; set; }

	}
}
