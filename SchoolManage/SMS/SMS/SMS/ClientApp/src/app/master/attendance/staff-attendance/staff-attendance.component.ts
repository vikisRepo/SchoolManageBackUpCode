import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { SmsConstant } from 'src/app/shared/constant-values';
import { FactorydataService } from 'src/app/shared/factorydata.service';
import { AttendancerestApiService } from '../attendancerest-api.service';

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

  departmentList = SmsConstant.department;
  stafflist = SmsConstant.staffType;

  constructor(private fb: FormBuilder, private factory: FactorydataService, private attendanceService: AttendancerestApiService) {
    this.departmentList = this.factory.department;
    this.stafflist = this.factory.staffType;
    this.stafffilters = this.fb.group({
      department: [''],
      staffType: [''],
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

  // applyFilter(event: any) {
  //   console.log(event)

  //   const filterValue = this.stafffilters.value[event];
  //   this.dataSource1.filter = filterValue.trim().toLowerCase();
  //   //this.staffListData.filter = filterValue.trim().toLowerCase();
  // }

}
