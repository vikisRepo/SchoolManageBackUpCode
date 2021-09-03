using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMS.Models.Academics
{
	public class LessonPlan
	{
		public int LessonPlanId { get; set; }

		[JsonIgnore]
		public string LessonPlanCheckDigi { get; set; }

		public int AcademicClassId { get; set; }

		public int AcademicClassSubjectId { get; set; }

		public DateTime? date { get; set; }
		public string classWork { get; set; }

		public string homeWork { get; set; }

		public string lesson { get; set; }

		public string games { get; set; }

		public string activity { get; set; }

		public string classActivity { get; set; }

		public string topic { get; set; }

		public string extraInfo { get; set; }

		public string concept { get; set; }
	}

	public class LessonPlanRequest
	{
		public string ClassName { get; set; }

		public string SubjectName { get; set; }

		public DateTime? date { get; set; }
		public string classWork { get; set; }

		public string homeWork { get; set; }

		public string lesson { get; set; }

		public string games { get; set; }

		public string activity { get; set; }

		public string classActivity { get; set; }

		public string topic { get; set; }

		public string extraInfo { get; set; }

		public string concept { get; set; }
	}
}
