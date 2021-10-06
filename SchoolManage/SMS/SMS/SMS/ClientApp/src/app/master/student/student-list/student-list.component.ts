import { Component, OnInit, Output,EventEmitter, ViewChild, AfterViewInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { StudentrestApiService } from '../studentrest-api.service';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { Subscription} from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { SmsConstant } from 'src/app/shared/constant-values';
import { Student } from '../student';
import { Router } from '@angular/router';
import { FactorydataService } from 'src/app/shared/factorydata.service';
@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {
  // studentListData=[{
  //   "studentName":"one",
  //   'esisNumber':'one',
  //    'mobileNumber':'one',
  //    'email':'aiswarya@gmail.com',
  //    'class':'5',
  //    'section':'B',
  //    'status':'good'
  // }];
  @BlockUI() blockUI: NgBlockUI;
  studentfilters: FormGroup;
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;

  currentUserSubscription !: Subscription;
  studentListData : any;
  currentStudent : Student;
  students:Array<Student>;
  filters : boolean;
  rows : number = 0;
  classes = SmsConstant.classes;
  sectiones =SmsConstant.Sectiondropdown;
  statuses = SmsConstant.status;
  ALL_Section: any = [];
  filterSelectObj = [];

  columnsToDisplay = ['StudentName','EsisNumber', 'MobileNumber','Email','Class','Section', 'Actions'];

  constructor(private fb: FormBuilder,private studentrestApiService : StudentrestApiService, private router:Router, private factory: FactorydataService) { 
    this.classes = factory.classes;
    this.studentfilters = this.fb.group({
      classFilter: [''],
      sectionFilter: [''],
      statusvalueFilter: [''],
      joiningDateFrom: ['']
    });

    this.LoadStudent();
  }

  ngOnInit(): void {
    this.LoadStudent();
  }

  LoadStudent()
  {
    this.blockUI.start();

    this.currentUserSubscription = this.studentrestApiService.getStudents().subscribe((student:any) => {
      //debugger;
      this.currentStudent = student;
      this.students=student;
      this.studentListData = new MatTableDataSource(student);
       this.studentListData.paginator = this.paginator;
      this.studentListData.sort = this.sort;
      console.log(this.studentListData);
      this.rows = this.studentListData.data.length;
       this.blockUI.stop();

    });
  }

  removeStudent(student : Student)
  {
    this.blockUI.start();

    this.studentrestApiService.deleteStudent(student.admissionNumber).subscribe(_=>{
      this.LoadStudent();
    });
    this.blockUI.stop();
  }

  applyFilterClass(event: any) {
   /* const filterValues = {
      Class: this.studentfilters.value["classFilter"].toLowerCase()
    };
    debugger;
    this.studentListData.filter = filterValues;*/
    let fileterData=this.students.filter(obj=> obj.class===this.studentfilters.value["classFilter"]);
    this.studentListData=new MatTableDataSource(fileterData);
    this.rows = this.studentListData.data.length;
  }

  applyFilterSection(event: any) {
    /* const filterValues = {
       Class: this.studentfilters.value["classFilter"].toLowerCase()
     };
     debugger;
     this.studentListData.filter = filterValues;*/
     let fileterData=this.students.filter(obj=> obj.class===this.studentfilters.value["sectionFilter"]);
     this.studentListData=new MatTableDataSource(fileterData);
     this.rows = this.studentListData.data.length;
   }

  filterToggle()
  {
    this.filters = !this.filters;
  }

  editStudent(student : Student)
  {
    this.router.navigate(['/new-student',student.admissionNumber]);
    // this.staffApiService.deleteStaff(staff.mobile).subscribe(_=>{
    // });
  }

  clearFilter(): void {
    this.studentListData.filter = '';
    this.studentfilters.reset();
    this.LoadStudent();
  }

  LoadSections(className)
  {
    this.factory.GetSectionByClassName(className.value).subscribe((data) => {
      this.ALL_Section = data; 
    });
  }
}
