import { getLocaleDateFormat } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { ActivatedRoute, Router } from '@angular/router';
import { SmsConstant } from 'src/app/shared/constant-values';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-course-list-view',
  templateUrl: './course-list-view.component.html',
  styleUrls: ['./course-list-view.component.css']
})
export class CourseListViewComponent implements OnInit {
  
  classId: any;
  subjectName: any
  CourseListData: any[];
  courseListForm: FormGroup;
  rows : number = 0;
  columnsToDisplay = ['CourseName', 'Code', 'Topic', 'Active','action'];
  classes = SmsConstant.classes;
  sections = SmsConstant.section;
  allstatus = SmsConstant.section
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;

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
    this.loadForm();

  }
  loadForm(){
  //  this.currentStudent = student;
  //  this.students=student;
    // this.CourseListData = new MatTableDataSource(student);
    //  this.CourseListData.paginator = this.paginator;
    // this.CourseListData.sort = this.sort;
    // console.log(this.CourseListData);
    // this.rows = this.CourseListData.data.length;
   // this.CourseListData = {course:"Tamil",code:"XYZ"};
  }
  navigate() {
    
    this.router.navigate(["course/courseSubjectwise/" + this.subjectName + "/" + this.classId]);
  }

  editLessonPlan(lessonPlan : any)
  {
    this.router.navigate(['lesson-plan/addsLessonPlanSubjectWise/',lessonPlan.lessonPlanId]);
    // this.staffApiService.deleteStaff(staff.mobile).subscribe(_=>{
    // });
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
