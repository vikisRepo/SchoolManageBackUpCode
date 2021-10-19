using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

#nullable disable

namespace SMS.Models
{
    public partial class Department
    {
		//public Department()
		//{
		//	staff = new HashSet<Staff>();
		//}
		public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
	}
}
