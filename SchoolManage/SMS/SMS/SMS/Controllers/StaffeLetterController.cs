using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StaffeLetterController : ControllerBase
	{
		private readonly SchoolManagementContext _dbcontext;
		public StaffeLetterController(SchoolManagementContext dbcontext)
		{
			this._dbcontext = dbcontext;
		}
		// GET: api/<StaffeLetterController>
		[HttpGet]
		public IEnumerable<StaffeLetter> Get()
		{
			return _dbcontext.StaffeLetters.ToList();
		}

		// GET api/<StaffeLetterController>/5
		[HttpGet("{id}")]
		public StaffeLetter Get(string id)
		{
			return _dbcontext.StaffeLetters.Where(X => X.Empid == id).FirstOrDefault();
		}

		// POST api/<StaffeLetterController>
		[HttpPost]
		public void Post([FromBody] StaffeLetter staffeLetter)
		{
			staffeLetter.Attachment = string.Empty;
			_dbcontext.StaffeLetters.Add(staffeLetter);
			_dbcontext.SaveChanges();
		}

		// PUT api/<StaffeLetterController>/5
		[HttpPut("{id}")]
		public void Put(string id, [FromBody] StaffeLetter staffeLetter)
		{
			_dbcontext.Entry(_dbcontext.StaffeLetters.Where(X => X.Empid == id).FirstOrDefault()).CurrentValues.SetValues(staffeLetter);
			_dbcontext.SaveChanges();
		}

		// DELETE api/<StaffeLetterController>/5
		[HttpDelete("{id}")]
		public void Delete(string id)
		{
			_dbcontext.Remove(_dbcontext.StaffeLetters.Where(X => X.Empid == id).FirstOrDefault());
			_dbcontext.SaveChanges();
		}
	}
}
