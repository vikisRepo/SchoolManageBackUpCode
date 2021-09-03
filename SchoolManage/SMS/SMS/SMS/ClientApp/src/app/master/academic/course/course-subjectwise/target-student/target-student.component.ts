import { Component, EventEmitter, OnInit, Output, ViewChild, AfterViewInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
import { StudentListComponent } from "../../../../student/student-list/student-list.component";
import {SelectionModel} from '@angular/cdk/collections';

import { Subscription} from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { Student } from 'src/app/master/student/student';
import { StudentrestApiService } from 'src/app/master/student/studentrest-api.service';

@Component({
  selector: 'app-target-student',
  templateUrl: './target-student.component.html',
  styleUrls: ['./target-student.component.css']
})

export class TargetStudentComponent implements OnInit {
  @Output() emitcourseformDetails = new EventEmitter();
  

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;

  currentUserSubscription !: Subscription;
  studentListData : any;
  currentStudent : Student;
  jsonStudentSelectedList : any;
  
  studentselectedList = [];

  columnsToDisplay = ['checked','StudentName','EsisNumber', 'MobileNumber','Email','Class','Section', 'Status'];




  targetstudentForm : FormGroup;
 classes=SmsConstant.classes;
 sections=SmsConstant.section;
 allstatus=SmsConstant.section
  constructor(private studentrestApiService : StudentrestApiService,private fb:FormBuilder,private router:Router) {
    this.targetstudentForm=this.fb.group({
      class:[''],
      section:[''],
      status:['']
    });
    this.targetstudentForm.valueChanges.subscribe(()=>{
      this.emitcourseformDetails.emit({value:this.targetstudentForm.value,valid:this.targetstudentForm.valid});
    })
   }

  ngOnInit(): void {
    this.LoadStudent();
  }
  LoadStudent()
  {
    // this.blockUI.start();

    this.currentUserSubscription = this.studentrestApiService.getStudents().subscribe((student:any) => {
      this.currentStudent = student;
      this.studentListData = new MatTableDataSource(student);
      //  this.studentListData.paginator = this.paginator;
      // this.studentListData.sort = this.sort;
      console.log(this.studentListData);
      //  this.blockUI.stop();

    });
  }
  checkBoxAction(c,element:any){
    
    console.log(c,element)
   if(c.checked)
   {
    this.studentselectedList.push(element);
   }
   else
   {
    this.studentselectedList=this.studentselectedList.filter(value => value!=element);
   }
   this.jsonStudentSelectedList=JSON.stringify(this.studentselectedList)
   console.log("json value is "+this.jsonStudentSelectedList);
    
  }
}
