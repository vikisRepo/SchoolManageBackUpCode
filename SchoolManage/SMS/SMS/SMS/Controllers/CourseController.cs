using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using SMS.Models.Academics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CourseController : ControllerBase
	{
		private readonly SchoolManagementContext _dbcontext;

		public CourseController(SchoolManagementContext dbcontext)
		{
			this._dbcontext = dbcontext;
		}

		// GET: api/<CourseController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<CourseController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<CourseController>
		[HttpPost]
		public void Post([FromBody] CourseDetail courseDetail)
		{
			_dbcontext.CourseDetails.Add(courseDetail);
			_dbcontext.SaveChanges();
		}

		// PUT api/<CourseController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<CourseController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
