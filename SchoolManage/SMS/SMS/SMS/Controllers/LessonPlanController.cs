using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using SMS.Models.Academics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LessonPlanController : ControllerBase
	{
		private readonly MysqlDataContext _dbcontext;
		public LessonPlanController(MysqlDataContext dbcontext)
		{
			this._dbcontext = dbcontext;
		}

		// GET: api/<LessonPlanController>
		[HttpGet]
		public IEnumerable<LessonPlan> Get()
		{
			return _dbcontext.LessonPlans.ToList();
		}

		// GET api/<LessonPlanController>/5
		[HttpGet("{ClassName}/{SubjectName}")]
		public IActionResult Get(string ClassName, string SubjectName)
		{

			var ClassIds = (from academicClasses in _dbcontext.AcademicClasses
							join academicClassSubject in _dbcontext.AcademicClassSubjects on academicClasses.AcademicClassId equals academicClassSubject.AcademicClassId
							join sub in _dbcontext.Subjects on academicClassSubject.SubjectID equals sub.SubjectID
							orderby sub.SubjectID
							select new
							{
								academicClasses.ClassName,
								academicClassSubject.AcademicClassId,
								academicClassSubject.AcademicClassSubjectId,
								sub.SubjectDescr
							}).Where(X => X.ClassName == ClassName && X.SubjectDescr == SubjectName).Distinct().FirstOrDefault();

			return Ok(_dbcontext.LessonPlans.Where(X => X.AcademicClassId == ClassIds.AcademicClassId && X.AcademicClassSubjectId == ClassIds.AcademicClassSubjectId).FirstOrDefault());
		}

		[HttpGet("GetLessonPlan/{id}")]
		public IActionResult GetLessonPlan(int id)
		{
			var _lessonPlan = (from lessonPlan in _dbcontext.LessonPlans
							   join acs in _dbcontext.AcademicClassSubjects on lessonPlan.AcademicClassSubjectId equals acs.AcademicClassSubjectId  
							   join Sub in _dbcontext.Subjects on acs.SubjectID equals Sub.SubjectID
								 select new
								 {

									 lessonPlan.date,
									 lessonPlan.classWork,
									 lessonPlan.homeWork,
									 lessonPlan.lesson,
									 lessonPlan.games,
									 lessonPlan.activity,
									 lessonPlan.classActivity,
									 lessonPlan.topic,
									 lessonPlan.extraInfo,
									 lessonPlan.concept,
									 Sub.SubjectDescr
								 }).FirstOrDefault();

			return Ok(_lessonPlan);
		}

		// POST api/<LessonPlanController>
		[HttpPost]
		public void Post([FromBody] LessonPlanRequest lessonPlan)
		{
			var ClassId = (from academicClasses in _dbcontext.AcademicClasses
							join academicClassSubject in _dbcontext.AcademicClassSubjects on academicClasses.AcademicClassId equals academicClassSubject.AcademicClassId
							join sub in _dbcontext.Subjects on academicClassSubject.SubjectID equals sub.SubjectID
							orderby sub.SubjectID
							select new
							{
								academicClasses.ClassName,
								academicClassSubject.AcademicClassId,
								academicClassSubject.AcademicClassSubjectId,
								sub.SubjectDescr
							}).Where(X => X.ClassName == lessonPlan.ClassName && X.SubjectDescr == lessonPlan.SubjectName).Distinct().FirstOrDefault();

			LessonPlan _updLessonPlan = new LessonPlan();

			_updLessonPlan.AcademicClassId = ClassId.AcademicClassId;
			_updLessonPlan.AcademicClassSubjectId = ClassId.AcademicClassSubjectId;
			_updLessonPlan.date = lessonPlan.date;
			_updLessonPlan.classWork = lessonPlan.classWork;
			_updLessonPlan.homeWork = lessonPlan.homeWork;
			_updLessonPlan.lesson = lessonPlan.lesson;
			_updLessonPlan.games = lessonPlan.games;
			_updLessonPlan.activity = lessonPlan.activity;
			_updLessonPlan.classActivity = lessonPlan.classActivity;
			_updLessonPlan.topic = lessonPlan.topic;
			_updLessonPlan.extraInfo = lessonPlan.extraInfo;
			_updLessonPlan.concept = lessonPlan.concept;

			_dbcontext.LessonPlans.Add(_updLessonPlan);
			_dbcontext.SaveChanges();

	}

		// PUT api/<LessonPlanController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<LessonPlanController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
