import { SelectionModel } from '@angular/cdk/collections';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { SmsConstant } from 'src/app/shared/constant-values';
import { FactorydataService } from 'src/app/shared/factorydata.service';
import { AttendancerestApiService } from '../attendancerest-api.service';
import { staffAttendanceRequest } from './staffAttendanceRequest';

export interface PeriodicElement {
  staffName: number;
  employeeId: number;
  present: number;
  absent: number;
  halfday: number;
  leave: number;
}

@Component({
  selector: 'app-staff-attendance',
  templateUrl: './staff-attendance.component.html',
  styleUrls: ['./staff-attendance.component.css']
})

export class StaffAttendanceComponent implements OnInit {

  department = new FormControl('');
  staffType = new FormControl('');
  DateFor = new FormControl('');
  currentUserSubscription !: Subscription;
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;
  rows: number;

  displayedColumns: string[] = ['staffName', 'employeeId', 'present', 'absent', 'halfday', 'leave'];
  filterValues = {
    //department: 
    departmentId: '',
    // designation: '',
    designationId: '',
    //status: '',
    employeementstatusId: '',
    //joiningDateFrom: '',
    joiningDate: ''
    //joiningDateTo: '',
  };

  stafffilters: FormGroup;

  staffListData: MatTableDataSource<any> = new MatTableDataSource();
  selection = new SelectionModel<any>(true, []);
  staffAttendanceRequest: staffAttendanceRequest;

  departmentList = SmsConstant.department;
  stafflist = SmsConstant.staffType;

  constructor(private fb: FormBuilder, private factory: FactorydataService, private attendanceService: AttendancerestApiService) {
    this.departmentList = this.factory.department;
    this.stafflist = this.factory.staffType;
    this.staffAttendanceRequest = new staffAttendanceRequest();
    this.stafffilters = this.fb.group({
      class: [''],
      section: [''],
      DateFor: ['']
    });
    // this.loadStaffsForSelection();
  }

  ngOnInit(): void {
  }

  loadStaffsForSelection() {

    this.currentUserSubscription = this.attendanceService.SearchStaffbyDepartmentAndStaffType(
      this.stafffilters.value).subscribe((staff: any) => {
        this.staffListData.data = staff;
        this.staffListData.paginator = this.paginator;
        this.staffListData.sort = this.sort;
        console.log(this.staffListData);
        this.rows = this.staffListData.data.length;
      });

  }

  

  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.staffListData.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ?
        this.selection.clear() :
        this.staffListData.data.forEach(row => this.selection.select(row));
  }

  presenttoggle(row : any)
  {
    // if (row.present==1)
    // {
    //   row.present=0;
    //   return;
    // }
    debugger;
    this.staffAttendanceRequest.employeeId = row.employeeId;
    this.staffAttendanceRequest.staffAttendanceId = row.staffAttendanceId;
    this.staffAttendanceRequest.updateType = 1;
    this.attendanceService.UpdateStaffAttendance(JSON.stringify(this.staffAttendanceRequest)).subscribe(_ => {
      
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
    debugger;
    this.staffAttendanceRequest.employeeId = row.employeeId;
    this.staffAttendanceRequest.staffAttendanceId = row.staffAttendanceId;
    this.staffAttendanceRequest.updateType = 2;
    this.attendanceService.UpdateStaffAttendance(JSON.stringify(this.staffAttendanceRequest)).subscribe(_ => {
      
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
    debugger;
    this.staffAttendanceRequest.employeeId = row.employeeId;
    this.staffAttendanceRequest.staffAttendanceId = row.staffAttendanceId;
    this.staffAttendanceRequest.updateType = 3;
    this.attendanceService.UpdateStaffAttendance(JSON.stringify(this.staffAttendanceRequest)).subscribe(_ => {
      
    });


    if (row.halfDay==0)
    {
      row.present=0;
      row.absent=0;
      row.halfDay=1;
    }
  }

  // applyFilter(event: any) {
  //   console.log(event)

  //   const filterValue = this.stafffilters.value[event];
  //   this.dataSource1.filter = filterValue.trim().toLowerCase();
  //   //this.staffListData.filter = filterValue.trim().toLowerCase();
  // }

}
