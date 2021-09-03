using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMS.Models
{
	public class StudentUserCred
	{
		public StudentUserCred()
		{
			Student = new HashSet<Student>();
		}

		[JsonIgnore]
		[IgnoreDataMember]
		[Key]
		public int StudentId { get; set; }

		public string Username { get; set; }
		public string Password { get; set; }

		[JsonIgnore]
		[IgnoreDataMember]
		public virtual ICollection<Student> Student { get; set; }
	}
}
