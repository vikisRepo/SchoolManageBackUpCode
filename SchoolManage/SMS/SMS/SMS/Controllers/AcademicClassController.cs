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

			//var resultSection = ((from uu in _dbconext.AcademicClasses.AsEnumerable()
			//			   select new
			//			   {
			//				   className = uu.ClassName,
			//				   Section = uu.Section,
			//				   classgroup = uu.Group,
			//				   academicYear = uu.AcademicYear
			//			   }).GroupBy(cc => new { cc.className }).
			//			   Select(dd => new {
			//				   Sections = dd.Key.Section //string.Join(",", dd.Select(ee => ee.Section).ToList()),
			//				   className = dd.Key.className
			//			   })).ToList();

			//var resultSubjects = ((from uu in _dbconext.AcademicClasses.AsEnumerable()
			//			   join e in _dbconext.AcademicClassSubjects.AsEnumerable() on uu.AcademicClassId equals e.AcademicClassId
			//			   select new
			//			   {
			//				   className = uu.ClassName,
			//				   Section = uu.Section,
			//				   classgroup = uu.Group,
			//				   academicYear = uu.AcademicYear,
			//				   Classid = e.AcademicClassId,
			//				   Subject = e.SubjectID
			//			   }).GroupBy(cc => new { cc.className, cc.academicYear, cc.classgroup, cc.Section }).
			//   Select(dd => new {
			//	   className = dd.Key.className,
			//	   academicYear = dd.Key.academicYear,
			//	   group = dd.Key.classgroup,
			//	  subject = string.Join(",", dd.Select(ff => ff.Subject).ToList())
			//   })).Distinct().ToList();

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
				_academicClassRequest.Subjects =  r.Subject.Split(','); //r.subject.ToArray();
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

			//var resultSection = ((from uu in _dbconext.AcademicClasses.AsEnumerable()
			//					  select new
			//					  {
			//						  className = uu.ClassName,
			//						  Section = uu.Section,
			//						  classgroup = uu.Group,
			//						  academicYear = uu.AcademicYear
			//					  }).GroupBy(cc => new { cc.className }).
			//			   Select(dd => new {
			//				   Sections = string.Join(",", dd.Select(ee => ee.Section).ToList()),
			//				   className = dd.Key.className
			//			   })).Where(X => X.className == ClassName).ToList();

			//var resultSubjects = ((from uu in _dbconext.AcademicClasses.AsEnumerable()
			//					   join e in _dbconext.AcademicClassSubjects.AsEnumerable() on uu.AcademicClassId equals e.AcademicClassId
			//					   select new
			//					   {
			//						   className = uu.ClassName,
			//						   Section = uu.Section,
			//						   classgroup = uu.Group,
			//						   academicYear = uu.AcademicYear,
			//						   Classid = e.AcademicClassId,
			//						   Subject = e.SubjectID
			//					   }).GroupBy(cc => new { cc.className, cc.academicYear, cc.classgroup, cc.Section }).
			//   Select(dd => new {
			//	   className = dd.Key.className,
			//	   academicYear = dd.Key.academicYear,
			//	   group = dd.Key.classgroup,
			//	   subject = string.Join(",", dd.Select(ff => ff.Subject).ToList())
			//   })).Distinct().Where(X => X.className == ClassName).ToList();
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

		

			academicClass.AcademicClassSubjectId = String.Join(",", AcademicClassRequest.Subjects) ;
			academicClass.Section = String.Join(",", AcademicClassRequest.Sections);


            _dbconext.AcademicClasses.Add(academicClass);
            _dbconext.SaveChanges();
            //var arrSections = AcademicClassRequest.Sections;

            //for (int i =0; i < arrSections.Count(); i++)
            //{
            //	AcademicClass academicClass = new AcademicClass();
            //	academicClass.AcademicYear = AcademicClassRequest.AcademicYear;
            //	academicClass.ClassName = AcademicClassRequest.Class;
            //	academicClass.Group = AcademicClassRequest.Group;
            //	//academicClass.Sections = AcademicClassRequest.Sections;
            //	academicClass.Section = arrSections[i].ToString();
            //	_dbconext.AcademicClasses.Add(academicClass);
            //	_dbconext.SaveChanges();

            //	var arrSubjects = AcademicClassRequest.Subjects;

            //	for (int j = 0; j < arrSubjects.Count(); j++)
            //	{
            //		AcademicClassSubject academicClassSubject = new AcademicClassSubject();
            //		academicClassSubject.AcademicClassId = _dbconext.AcademicClasses.Where(X => X.ClassName == academicClass.ClassName
            //													   && X.Section == academicClass.Section).FirstOrDefault().AcademicClassId;
            //		academicClassSubject.SubjectID = Convert.ToInt32(arrSubjects[j]);
            //		//academicClassSubject.SubjectIds = Convert.ToInt32(AcademicClassRequest.Subjects);
            //		_dbconext.AcademicClassSubjects.Add(academicClassSubject);
            //		_dbconext.SaveChanges();
            //	}

            //}

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

		[HttpGet("GetClassSubjects/{ClassName}")]
		public IActionResult GetClassSubjects(string ClassName)
		{
			var q = (from academicClasses in _dbconext.AcademicClasses 
					 join academicClassSubject in _dbconext.AcademicClassSubjects on academicClasses.AcademicClassId equals academicClassSubject.AcademicClassId
					 join sub in _dbconext.Subjects on academicClassSubject.SubjectID equals sub.SubjectID
					 orderby sub.SubjectID
					 select new
					 {
						 academicClasses.ClassName, 
						 sub.SubjectDescr
					 }).Where(X => X.ClassName == ClassName).ToList();

			//_dbconext.AcademicClassSubjects.Join(_dbconext.Subjects, 
			//Where(X => X.AcademicClassId == _classId).Join

			return Ok(q);
		}


		// PUT api/<AcademicClassController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] AcademicClassRespReq AcademicClassRequest)
		{
			AcademicClass academicClass = new AcademicClass();
			academicClass.AcademicClassId = id;
			academicClass.AcademicYear = AcademicClassRequest.AcademicYear == null ? DateTime.Now : AcademicClassRequest.AcademicYear ;
			academicClass.ClassName = AcademicClassRequest.Class;
			academicClass.Group = AcademicClassRequest.Group;



			academicClass.AcademicClassSubjectId = string.Join(',',AcademicClassRequest.Subjects);
			academicClass.Section = string.Join(',',AcademicClassRequest.Sections);

			_dbconext.Entry(_dbconext.AcademicClasses.Where(X => X.AcademicClassId == id).FirstOrDefault()).CurrentValues.SetValues(academicClass);
            _dbconext.SaveChangesAsync();
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
