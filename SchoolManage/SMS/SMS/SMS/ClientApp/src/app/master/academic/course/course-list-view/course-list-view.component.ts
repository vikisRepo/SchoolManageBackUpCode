import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SmsConstant } from 'src/app/shared/constant-values';

@Component({
  selector: 'app-course-list-view',
  templateUrl: './course-list-view.component.html',
  styleUrls: ['./course-list-view.component.css']
})
export class CourseListViewComponent implements OnInit {
  
  classId: any;
  subjectName:any

  courseListForm : FormGroup;
 classes=SmsConstant.classes;
 sections=SmsConstant.section;
 allstatus=SmsConstant.section

  constructor(private route: ActivatedRoute,
    private router: Router,private fb:FormBuilder) {
      this.courseListForm=this.fb.group({
        class:[''],
        section:[''],
        status:[''],
        courseCFrom:[''],
        courseCTo:['']
      })
     }

  ngOnInit(): void {
    this.classId = this.route.snapshot.paramMap.get('class');
    this.subjectName =this.route.snapshot.paramMap.get('subject');

  }
  navigate() {
    
    this.router.navigate(["/main/course/courseSubjectwise/" + this.subjectName + "/" + this.classId]);
}
checkBoxAction(matValue:any){
  // this.pFlagEmit.emit(matValue.checked);
  // if (matValue.checked) {
  //   this.form.disable();
  // }
  // else {
  //   this.form.enable();
  // }
}
}
