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
    this.classId = this.route.snapshot.paramMap.get('class');
    this.lessonPlanRestApiService.getClassSubjects(this.classId).subscribe( data => {
      this.standard = data;
    });
    console.log(this.classId);
   
  }
  navigate(subject: any) {
        this.router.navigate(["/main/course/courseListView/"+subject+"/"+this.classId]);
    //  this.router.navigate(["/main/course/courseSubjectwise/" + subject + "/" + this.classId]);
  }
}
