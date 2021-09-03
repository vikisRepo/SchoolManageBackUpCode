using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMS.Models.Academics
{
	public class CourseDetail
	{
		public int CourseDetailId { get; set; }

		public int AcademicClassId { get; set; }

		public int AcademicClassSubjectId { get; set; }

		public string CourseName { get; set; }

		public string CourseCode { get; set; }

		public string CourseDescription { get; set; }

		public string CompletionCriteria { get; set; }

		public int PassingScore { get; set; }

		public string Topic { get; set; }

		public	string StudentId { get; set; }

		[JsonIgnore]
		public string FileType { get; set; }

		[JsonIgnore]
		public string  FilePath { get; set; }

	}

	public class StudentCourseDetail
	{
		public int StudentCourseDetailId { get; set; }

		public int StudentId { get; set; }

		public string StudentCourseStatus { get; set; }
	}
}
