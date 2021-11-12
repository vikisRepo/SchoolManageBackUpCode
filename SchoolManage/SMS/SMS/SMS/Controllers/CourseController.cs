using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using SMS.Models.Academics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;
using SMS.Models.Course;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CourseController : ControllerBase
	{
		private readonly MysqlDataContext _dbcontext;

		public CourseController(MysqlDataContext dbcontext)
		{
			this._dbcontext = dbcontext;
		}

		// GET: api/<CourseController>
		[HttpGet]
		public IEnumerable<CourseDetail> Get()
		{
			return this._dbcontext.CourseDetails.ToList();
		}

		// GET api/<CourseController>/5
		[HttpGet("{id}")]
		public CourseDetail Get(int id)
		{
			return this._dbcontext.CourseDetails.Where(x => x.CourseDetailID == id).FirstOrDefault();
		}

		// POST api/<CourseController>
		[HttpPost]
		public int Post([FromBody] CourseDetail courseDetail)
		{
			CourseDetail _courseDetail = new CourseDetail
			{
				Code = courseDetail.Code,
				CreatedDate = courseDetail.CreatedDate,
				Description = courseDetail.Description,
				Name = courseDetail.Name,
			};

			_dbcontext.CourseDetails.Add(courseDetail);
			_dbcontext.SaveChanges();
			return _courseDetail.CourseDetailID;
		}

		// PUT api/<CourseController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] CourseDetail courseDetail)
		{
			var courseDetails = _dbcontext.CourseDetails.Where(x => x.CourseDetailID == id).FirstOrDefault();

			courseDetails.Code = courseDetail.Code;
			courseDetails.CreatedDate = courseDetail.CreatedDate;
			courseDetails.Description = courseDetail.Description;
			courseDetails.Name = courseDetail.Name;
			_dbcontext.SaveChanges();

		}

		// DELETE api/<CourseController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			var courseDetails = _dbcontext.CourseDetails.Where(x => x.CourseDetailID == id).FirstOrDefault();
			_dbcontext.CourseDetails.Remove(courseDetails);
			_dbcontext.SaveChanges();
		}
	}
}
