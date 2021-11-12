import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LessonPlanRestApiService } from '../../lesson-plan/lesson-plan-rest-api.service';

@Component({
  selector: 'app-course-subject',
  templateUrl: './course-subject.component.html',
  styleUrls: ['./course-subject.component.css']
})
export class CourseSubjectComponent implements OnInit {
  standard: any;
    // [{
    //   subject: "English"
    // }, { subject: "Tamil" }, { subject: "Maths" }, { subject: "Science" }, { subject: "Social" }];
  classId: any;
  
  constructor(private route: ActivatedRoute,
    private router: Router, private lessonPlanRestApiService : LessonPlanRestApiService) { }

  ngOnInit(): void {
    debugger;
    this.classId = this.route.snapshot.paramMap.get('class');
    this.lessonPlanRestApiService.getClassSubjects(this.classId).subscribe( data => {
      this.standard = data;
    });
    console.log(this.classId);
   
  }
  navigate(subject: any) {
        this.router.navigate(["course/courseListView/"+subject+"/"+this.classId]);
    //  this.router.navigate(["/main/course/courseSubjectwise/" + subject + "/" + this.classId]);
  }

  getColor(title) { (2)
    switch (title) {
      case title.includes('Tamil'):
        return '#E36EEC';
      case title.includes('English'):
        return '#6E9BEC';
      case title.includes('Maths'):
        return '#EC846E';
      case title.includes('Science'):
        return 'yellow';
      case title.includes('Social'):
        return '#FFBD33'; 
      default:
         return '33FFBD';  
    }
  }
}
