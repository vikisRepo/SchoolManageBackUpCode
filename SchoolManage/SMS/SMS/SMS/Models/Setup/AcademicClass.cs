using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMS.Models.Setup
{
	public class AcademicClass
	{

		[JsonIgnore]
		public int AcademicClassId { get; set; }

		public DateTime AcademicYear { get; set; }

		public string ClassName { get; set; }

		[JsonIgnore]
		public string Section { get; set; }

		public string  Group { get; set; }

        //[ForeignKey("AcademicClassSubject")]
        public String AcademicClassSubjectId { get; set; }
        //public AcademicClassSubject AcademicClassSubject { get; set; }

    }

	public class AcademicClassSubject
	{
		public int AcademicClassSubjectId { get; set; }

		public int AcademicClassId { get; set; }

		public int SubjectID { get; set; }

		//public ICollection<AcademicClass> AcademicClasses { get; set; }

		//public ICollection<Subject> Subjects { get; set; }

	}

	public class AcademicClassRespReq
	{
		public DateTime AcademicYear { get; set; }

		public string Class { get; set; }

		// Comma Seperated values
		public String[] Sections { get; set; }

		public string Group { get; set; }

		// Comma Seperated values
		public string[] Subjects { get; set; }
	}
}
