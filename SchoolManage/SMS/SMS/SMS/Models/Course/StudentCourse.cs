using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models.Course
{
	public class StudentCourse
	{
		public int StudentCourseId { get; set; }

		[ForeignKey("StudentId")]
		public int StudentId { get; set; }
		public Student Student { get; set; }

		[ForeignKey("CourseContentId")]
		public int CourseContentId { get; set; }
		public CourseContent CourseContent { get; set; }
		public int PassingScore { get; set; }
	}
}
