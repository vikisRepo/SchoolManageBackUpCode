import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LessonPlanRestApiService } from '../lesson-plan-rest-api.service';
import { LessonPlan } from '../models/lesson-plan';

@Component({
  selector: 'app-add-lesson-plan-listview',
  templateUrl: './add-lesson-plan-listview.component.html',
  styleUrls: ['./add-lesson-plan-listview.component.css']
})
export class AddLessonPlanListviewComponent implements OnInit {
  studentListData : any[];

  // studentListData=[{
  //   "date":"20/2/2021",
  //   'lesson':'one',
  //    'topic':'one',
  //    'concept':'aiswarya@gmail.com',
  //    'extraInfo':'5',
  //    'games':'B',
  //    'activity':'good',
  //    'homeWork':'good'
  // },
  // {
  //   "date":"20/2/2021",
  //   'lesson':'one',
  //    'topic':'one',
  //    'concept':'aiswarya@gmail.com',
  //    'extraInfo':'5',
  //    'games':'B',
  //    'activity':'good',
  //    'homeWork':'good'
  // }];
  columnsToDisplay = ['date','lesson', 'topic','concept','extraInfo','games','activity','homeWork','actions'];
  LessonListForm:FormGroup;

  subject: any;
  class: any;


  constructor(private fb:FormBuilder,private route: ActivatedRoute,private router:Router, 
                  private lessonPlanRestApiService : LessonPlanRestApiService) { 
this.LessonListForm=this.fb.group({
  from:[''],
  to:['']
});

  }

  ngOnInit(): void {
    this.subject = this.route.snapshot.paramMap.get('subject');
    this.class = this.route.snapshot.paramMap.get('class');

    this.lessonPlanRestApiService.getLessonPlans().subscribe(data =>
      {
        this.studentListData = data;

      }
    );


  }
  navToback(){
    this.router.navigate(["main/lesson-plan/addsLessonPlanSubjectWise/"+this.subject+"/"+this.class]);
  }

  editLessonPlan(lessonPlan : any)
  {
    this.router.navigate(['main/lesson-plan/addsLessonPlanSubjectWise/',lessonPlan.lessonPlanId]);
    // this.staffApiService.deleteStaff(staff.mobile).subscribe(_=>{
    // });
  }

}
