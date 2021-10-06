import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl,FormGroup } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { studentAttendanceRequest } from '../staff-attendance/student-attendancerequest';
import { FactorydataService } from 'src/app/shared/factorydata.service';
import { AttendancerestApiService } from '../attendancerest-api.service';
import { Subscription } from 'rxjs';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
export interface PeriodicElement {
  student: number;
  admissionnumber: number;
  present: number;
  absent: number;
  halfday: number;
  leave: number;
}

// const ELEMENT_DATA: PeriodicElement[] = [
//   {student: 1, admissionnumber: 54, present:1, absent: 0,halfday:0,leave:0}
 
// ];

@Component({
  selector: 'app-student-attendance',
  templateUrl: './student-attendance.component.html',
  styleUrls: ['./student-attendance.component.css']
})
export class StudentAttendanceComponent implements OnInit {

  classFilter = new FormControl('');
  sectionFilter = new FormControl('');
  joiningDateFrom = new FormControl('');

  displayedColumns: string[] = ['studentName','admissionNumber','present','absent','halfDay','leave'];

  studentfilters: FormGroup;
  currentUserSubscription !: Subscription;
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;

  rows: number;
  

  studentListData: MatTableDataSource<any> = new MatTableDataSource();
  selection = new SelectionModel<any>(true, []);
  studentAttendanceRequest: studentAttendanceRequest;
  
  class = SmsConstant.classes;
  section = SmsConstant.section;
  blockUI: any;
  ALL_Section: any = [];
  constructor(private fb: FormBuilder, private factory: FactorydataService, private attendanceService: AttendancerestApiService) {
    this.class = this.factory.classes;
    this.section = this.factory.Subjectsdropdown;
    this.studentAttendanceRequest = new studentAttendanceRequest();
    this.studentfilters = this.fb.group({
      class: [''],
      section: [''],
      dateFor: ['']
    });
   }

  ngOnInit(): void {
  }

  loadStudent()
  {
    this.currentUserSubscription = this.attendanceService.SearchStudentbyClassAndSection(
      this.studentfilters.value).subscribe((student: any) => {
        this.studentListData.data = student;
        this.studentListData.paginator = this.paginator;
        this.studentListData.sort = this.sort;
        console.log(this.studentListData);
        this.rows = this.studentListData.data.length;
      });
  }

  applyFilter(event: any) {
    console.log(event)
  
    const filterValue = this.studentfilters.value[event];
    this.studentListData.filter = filterValue.trim().toLowerCase();
    //this.staffListData.filter = filterValue.trim().toLowerCase();
  }

  presenttoggle(row : any)
  {
    // if (row.present==1)
    // {
    //   row.present=0;
    //   return;
    // }
    this.studentAttendanceRequest.admissionNumber = row.admissionNumber;
    this.studentAttendanceRequest.studentAttendanceId = row.studentAttendanceId;
    this.studentAttendanceRequest.updateType = 1;
    this.attendanceService.UpdateStudentAttendance(JSON.stringify(this.studentAttendanceRequest)).subscribe(_ => {
      
    });

    if (row.present==0)
      {
        row.present=1;
        row.absent=0;
        row.halfDay=0;
      }
  }

  absenttoggle(row : any)
  {
    // if (row.absent==1)
    // {
    //   row.absent=0;
    //   return;
    // }
    this.studentAttendanceRequest.admissionNumber = row.admissionNumber;
    this.studentAttendanceRequest.studentAttendanceId = row.studentAttendanceId;
    this.studentAttendanceRequest.updateType = 2;
    this.attendanceService.UpdateStudentAttendance(JSON.stringify(this.studentAttendanceRequest)).subscribe(_ => {
      
    });


    if (row.absent==0)
    {
      row.present=0;
      row.absent=1;
      row.halfDay=0;
    }
  }

  halfdaytoggle(row : any)
  {
    // if (row.halfDay==1)
    // {
    //   row.halfDay=0;
    //   return;
    // }
    this.studentAttendanceRequest.admissionNumber = row.admissionNumber;
    this.studentAttendanceRequest.studentAttendanceId = row.studentAttendanceId;
    this.studentAttendanceRequest.updateType = 3;
    this.attendanceService.UpdateStudentAttendance(JSON.stringify(this.studentAttendanceRequest)).subscribe(_ => {
      
    });


    if (row.halfDay==0)
    {
      row.present=0;
      row.absent=0;
      row.halfDay=1;
    }
  }

  LoadSections(className)
  {
    this.factory.GetSectionByClassName(className.value).subscribe((data) => {
      this.ALL_Section = data; 
    });
  }

}
