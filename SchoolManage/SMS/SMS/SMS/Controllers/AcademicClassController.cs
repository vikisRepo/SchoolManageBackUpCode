using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using SMS.Models.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using WebApi.Helpers;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AcademicClassController : ControllerBase
	{
		//private readonly SchoolManagementContext _dbconext;
		private readonly MysqlDataContext _dbconext;
		private readonly IMapper _mapper;
		
		public AcademicClassController(MysqlDataContext dbcontext, IMapper mapper )
		{
			_dbconext = dbcontext;
		}

    //// GET: api/<AcademicClassController>
    [HttpGet]
    public IActionResult Get()
    {
      List<AcademicClassRespReq> academicClassRequest = new List<AcademicClassRespReq>();



      var result = (from uu in _dbconext.AcademicClasses.AsEnumerable()
                    select new
                    {
                      className = uu.ClassName,
                      Section = uu.Section,
                      classgroup = uu.Group,
                      academicYear = uu.AcademicYear,
                      Classid = uu.AcademicClassId,
                      Subject = uu.AcademicClassSubjectId
                    }
              ).ToList();

      foreach (var r in result)
      {

        AcademicClassRespReq _academicClassRequest = new AcademicClassRespReq();
        _academicClassRequest.AcademicYear = r.academicYear;
        _academicClassRequest.Class = r.className;
        _academicClassRequest.Group = r.classgroup;
        _academicClassRequest.Subjects = r.Subject.Split(','); //r.subject.ToArray();
        _academicClassRequest.Sections = r.Section.Split(',');//resultSection.Where(X => X.className == r.className).FirstOrDefault().Sections.ToArray();

        academicClassRequest.Add(_academicClassRequest);


      }

      return Ok(academicClassRequest);

    }

    // GET api/<AcademicClassController>/5
    [HttpGet("{ClassName}")]
    public IActionResult Get(string ClassName)
    {
      List<AcademicClassRespReq> academicClassRequest = new List<AcademicClassRespReq>();

      var result = (from uu in _dbconext.AcademicClasses.AsEnumerable()
                    select new
                    {
                      className = uu.ClassName,
                      Section = uu.Section,
                      classgroup = uu.Group,
                      academicYear = uu.AcademicYear,
                      Classid = uu.AcademicClassId,
                      Subject = uu.AcademicClassSubjectId
                    }
              ).ToList().Distinct().Where(X => X.className == ClassName).ToList();


      foreach (var r in result)
      {
        AcademicClassRespReq _academicClassRequest = new AcademicClassRespReq();
        _academicClassRequest.AcademicYear = r.academicYear;
        _academicClassRequest.Class = r.className;
        _academicClassRequest.Group = r.classgroup;
        //char[] vs = r.subject.ToArray();
        _academicClassRequest.Subjects = r.Subject.Split(',');
        //char[] vs1 = result.Where(X => X.className == r.className).FirstOrDefault().Sections.ToArray();
        _academicClassRequest.Sections = r.Section.Split(',');

        academicClassRequest.Add(_academicClassRequest);


      }

      return Ok(academicClassRequest);
    }

    // POST api/<AcademicClassController>
    [HttpPost]
    public IActionResult Post([FromBody] AcademicClassRespReq AcademicClassRequest)
    {
      AcademicClass academicClass = new AcademicClass();
      academicClass.AcademicYear = AcademicClassRequest.AcademicYear;
      academicClass.ClassName = AcademicClassRequest.Class;
      academicClass.Group = AcademicClassRequest.Group;



      academicClass.AcademicClassSubjectId = String.Join(",", AcademicClassRequest.Subjects);
      academicClass.Section = String.Join(",", AcademicClassRequest.Sections);


      _dbconext.AcademicClasses.Add(academicClass);
      _dbconext.SaveChanges();


      return Ok();
    }

		[HttpGet("GetClassNames")]
		public IActionResult GetClassNames()
		{
			return Ok(_dbconext.AcademicClasses.AsEnumerable().GroupBy(Y => new { Y.ClassName }).Select(
				X => new {
					className = X.Key.ClassName
				}));
		}

		[HttpGet("GetFactoryClassNames")]
		public IActionResult GetFactoryClassNames()
		{
			return Ok(_dbconext.AcademicClasses.AsEnumerable().GroupBy(Y => new { Y.ClassName, Y.AcademicClassId }).Select(
				X => new {
					className = X.Key.ClassName,
					id = X.Key.AcademicClassId
				}));
		}

		[HttpGet("GetClassSubjects/{ClassName}")]
		public IActionResult GetClassSubjects(string ClassName)
		{
			var academicClassSubjectId = _dbconext.AcademicClasses.Where(x => x.ClassName == ClassName).FirstOrDefault().AcademicClassSubjectId;
			List<string> academicclass = academicClassSubjectId.Split(',').ToList();

			return Ok(academicclass);
		}

		[HttpGet("GetClassSections/{ClassName}")]
		public IActionResult GetClassSections(string ClassName)
		{

			var section = _dbconext.AcademicClasses.Where(x => x.ClassName == ClassName).FirstOrDefault().Section;
			List<string> academicsection = section.Split(',').ToList();

			return Ok(academicsection);
		}


    // PUT api/<AcademicClassController>/5
    [HttpPut("{id}")]
    public void Put(string id, [FromBody] AcademicClassRespReq AcademicClassRequest)
    {
       AcademicClass academicClass = _dbconext.AcademicClasses.Where(X => X.ClassName == id).FirstOrDefault();
      if (academicClass != null)
      {
        //academicClass.AcademicClassId = id;
        academicClass.AcademicYear = AcademicClassRequest.AcademicYear == null ? DateTime.Now : AcademicClassRequest.AcademicYear;
        academicClass.ClassName = AcademicClassRequest.Class;
        academicClass.Group = AcademicClassRequest.Group;
        academicClass.AcademicClassSubjectId = string.Join(',', AcademicClassRequest.Subjects);
        academicClass.Section = string.Join(',', AcademicClassRequest.Sections);
        _dbconext.SaveChangesAsync();
      }
    }

    // DELETE api/<AcademicClassController>/5
    [HttpDelete("{ClassName}")]
    public void Delete(string ClassName)
    {
      var academicClass = _dbconext.AcademicClasses.Where(X => X.ClassName == ClassName).ToList();

      //_dbconext.Remove(_dbconext.AcademicClasses.Where(X => X.ClassName == ClassName).ToList());

      foreach (var removeClass in academicClass)
      {
        _dbconext.Remove(_dbconext.AcademicClasses.Where(X => X.AcademicClassId == removeClass.AcademicClassId).FirstOrDefault());
      }

      _dbconext.SaveChanges();
    }
	}
}
