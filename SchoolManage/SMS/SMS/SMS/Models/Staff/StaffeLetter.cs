using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SMS.Models
{
    public partial class StaffeLetter
	{
		[JsonIgnore]
		[IgnoreDataMember]
		public int StaffeLetterId { get; set; }
		public string Empid { get; set; }
		public string StaffName { get; set; }

		public string LetterType { get; set; }

		public string Department { get; set; }

		public string Month { get; set; }

		public string TeacherId { get; set; }

		public int Year { get; set; }

		[JsonIgnore]
		[IgnoreDataMember]
		public int AttachmentId { get; set; }
	}
}
