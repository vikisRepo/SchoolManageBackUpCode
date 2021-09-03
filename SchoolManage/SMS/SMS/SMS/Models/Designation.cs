using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

#nullable disable

namespace SMS.Models
{
    public partial class Designation
    {
		//public Designation()
		//{
		//	staff = new HashSet<Staff>();
		//}

		public int DesignationId { get; set; }
        public string DesignationName { get; set; }

		//[JsonIgnore]
		//[IgnoreDataMember]
		//public virtual ICollection<Staff> staff { get; set; }
	}
}
