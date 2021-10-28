import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { Subscription} from 'rxjs';
import { FactorydataService } from 'src/app/shared/factorydata.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { StudentrestApiService } from 'src/app/master/student/studentrest-api.service';
import { Student } from 'src/app/master/student/student';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css']
})
export class StudentDetailsComponent implements OnInit {
  @Output() studentFormOutput =new EventEmitter<any>();
  @BlockUI() blockUI: NgBlockUI;
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;
  studentListData:any;
  selectedStudentListData:MatTableDataSource<Student>;
  currentStudent : Student;
  rows : number = 0;
  students:Array<Student>;
  selectedStudents:Array<Student> = [];
  currentUserSubscription !: Subscription;
  classes = SmsConstant.classes;
  sections = SmsConstant.section;
  initialSelection = [];
  allowMultiSelect = true;
  ALL_Section = [];
  selection = new SelectionModel<any>(this.allowMultiSelect, this.initialSelection);

  columnsToDisplay = ['select','StudentName', 'MobileNumber','Class','Section'];

  constructor(private fb : FormBuilder, private factory: FactorydataService,private studentrestApiService : StudentrestApiService) { 
    this.classes = factory.classes;
    this.studentDetailForm = this.fb.group({
      class : ['',Validators.required],
      section : ['',Validators.required]
    }) 
    this.LoadStudent();
  }
  studentDetailForm :FormGroup;
  ngOnInit(): void {
  }
  LoadStudent()
  {
    this.blockUI.start();
    this.currentUserSubscription = this.studentrestApiService.getStudents().subscribe((student:any) => {
      //debugger;
      this.currentStudent = student;
      this.students=student;
      this.studentListData = new MatTableDataSource(student);
   //   this.selectedStudentListData = new MatTableDataSource(this.selectedStudents);
     // this.studentListData.paginator = this.paginator;
     // this.studentListData.sort = this.sort;
      console.log(this.studentListData);
      this.rows = this.studentListData.data.length;
      this.blockUI.stop();
    });
  }

  applyFilterClass(event: any) {
    /* const filterValues = {
       Class: this.studentfilters.value["classFilter"].toLowerCase()
     };
     debugger;
     this.studentListData.filter = filterValues;*/
     let fileterData=this.students.filter(obj=> obj.class===this.studentDetailForm.value["class"]);
     this.studentListData=new MatTableDataSource(fileterData);
     this.rows = this.studentListData.data.length;
   }

   applyFilterSection(event: any) {
    /* const filterValues = {
       Class: this.studentfilters.value["classFilter"].toLowerCase()
     };
     debugger;
     this.studentListData.filter = filterValues;*/
     let fileterData=this.students.filter(obj=> obj.section===this.studentDetailForm.value["section"]);
     this.studentListData=new MatTableDataSource(fileterData);
     this.rows = this.studentListData.data.length;
   }

   isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.studentListData.data.length;
    return numSelected == numRows;
  }

  addStudent()
  {
     this.selectedStudents.push(this.studentListData.data[0]);
    console.log( this.studentListData.data[0]);
    this.selectedStudentListData = new MatTableDataSource(this.selectedStudents);
  }
  
  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ?
        this.selection.clear() :
        this.studentListData.data.forEach(row => this.selection.select(row));
  }

  LoadSections(className)
  {
    this.factory.GetSectionByClassName(className.value).subscribe((data) => {
      this.ALL_Section = data; 
    });
  }

}
