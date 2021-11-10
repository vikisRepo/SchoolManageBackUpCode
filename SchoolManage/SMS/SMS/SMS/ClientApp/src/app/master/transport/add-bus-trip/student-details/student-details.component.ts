import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
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
import { listenerCount } from 'process';
import { TransportService } from '../../transport.service';
import { MessageBoxComponent } from 'src/app/shared/dialog-boxes/message-box/message-box.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css']
})
export class StudentDetailsComponent implements OnInit {
  @Output() studentFormOutput =new EventEmitter<any>();
  @Input() public BusTripDetails :any; 
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
  selectedStudentsTrip:Array<Student> = [];
  copy:Array<Student> = [];
  currentUserSubscription !: Subscription;
  classes = SmsConstant.classes;
  sections = SmsConstant.section;
  initialSelection = [];
  allowMultiSelect = true;
  initialSelectionTrip = [];
  allowMultiSelectTrip = true;
  ALL_Section = [];
  selectedAdmissionNumber : Array<any> = [];
  selection = new SelectionModel<Student>(this.allowMultiSelect, this.initialSelection);
  selectionTrip = new SelectionModel<Student>(this.allowMultiSelectTrip, this.initialSelectionTrip);

  columnsToDisplay = ['select','StudentName', 'MobileNumber','Class','Section'];

  constructor(private fb : FormBuilder, private factory: FactorydataService,
    private studentrestApiService : StudentrestApiService, private transportservice : TransportService, 
    public dialog: MatDialog) { 
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

  isAllSelectedTrip() {
    const numSelected = this.selectionTrip.selected.length;
    const numRows = this.selectedStudentListData.data.length;
    return numSelected == numRows;
  }


  
  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ?
        this.selection.clear() :
        this.studentListData.data.forEach(row => this.selection.select(row));
  }

  masterToggleTrip() {
    this.isAllSelectedTrip() ?
        this.selectionTrip.clear() :
        this.selectedStudentListData.data.forEach(row => this.selectionTrip.select(row));
  }

  LoadSections(className)
  {
    this.factory.GetSectionByClassName(className.value).subscribe((data) => {
      this.ALL_Section = data; 
    });
  }
  addStudent()
  {
    debugger;
    let admissionNumberlist = [];
    this.selectedStudents=this.selectedStudents.concat(this.selection.selected);
    this.selectedStudents=this.selectedStudents.filter((obj, pos, arr) => {
      if (admissionNumberlist.indexOf(obj["admissionNumber"]) === -1) admissionNumberlist.push(obj["admissionNumber"]);
      return arr.map(mapObj => mapObj["admissionNumber"]).indexOf(obj["admissionNumber"]) === pos;
    });

    this.selectedStudentListData = new MatTableDataSource(this.selectedStudents);

    this.transportservice.UpdateStudentTripDetails( this.BusTripDetails.tripId, admissionNumberlist).subscribe(_ => {
      this.dialog.open(MessageBoxComponent, { width: '350px', height: '100px', data: "Trip details for selected students updated successfully !" });
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500);
    });

  }
  removeStudentfromTrip(){
        debugger;
    let admissionNumberlist = [];
    console.log(this.selectionTrip.selected);
    this.selectedStudentsTrip=this.selectionTrip.selected;
    this.selectedStudentsTrip.forEach(myFunction);
    function myFunction(item) {
      if (admissionNumberlist.indexOf(item["admissionNumber"]) === -1) admissionNumberlist.push(item["admissionNumber"]);
    }
    this.selectedStudents = this.selectedStudentListData.data.filter(ar => !this.selectedStudentsTrip.find(rm => (rm.admissionNumber === ar.admissionNumber)
    ))
    this.selectedStudentListData = new MatTableDataSource(this.selectedStudents);

    this.transportservice.RemoveStudentTripDetails( this.BusTripDetails.tripId, admissionNumberlist).subscribe(_ => {
      this.dialog.open(MessageBoxComponent, { width: '350px', height: '100px', data: "Trip details for selected students updated successfully !" });
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500);
    });

  }

}
