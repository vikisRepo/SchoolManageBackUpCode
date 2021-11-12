using Microsoft.AspNetCore.Mvc;
using SMS.Models.TimeTable;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApi.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimetableController : ControllerBase
    {
        private readonly MysqlDataContext _dbcontext;
        public TimetableController(MysqlDataContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }

   // GET api/<TimetableController>/5
    [HttpGet("GetTimeTable/{clases}/{section}")]
    public IActionResult Get(string clases,string section,DateTime fromDate,DateTime todate)
    {
      return Ok(_dbcontext.ClassTimeTables.Where(X => X.Class == clases && X.Section == section && (X.Date >= fromDate && X.Date <=X.Date)).FirstOrDefault());
    }

    // GET: api/<TimetableController>
    //    [HttpGet("RetriveTimetable")]
    //public ClassTimeTable Get([FromBody] ClassTimeTableReq value)
    //{
    //  return _dbcontext.ClassTimeTables
    //                 .Where(s => s.Class == value.Class && s.Section == value.Section && s.Year == value.Year)
    //                 .FirstOrDefault<ClassTimeTable>();
    //}

    // POST api/<TimetableController>
    [HttpPost("CreatePeriod")]
    public void Post([FromBody] ClassTimeTable value)
    {
      _dbcontext.ClassTimeTables.Add(value);
      _dbcontext.SaveChanges();
    }

    // PUT api/<TimetableController>/5
    [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TimetableController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
