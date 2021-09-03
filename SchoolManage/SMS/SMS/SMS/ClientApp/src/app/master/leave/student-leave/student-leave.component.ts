import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl,FormGroup } from '@angular/forms';
import { matMenuAnimations } from '@angular/material/menu';
import { SmsConstant } from 'src/app/shared/constant-values';



export interface PeriodicElement {
  studentName: number;
  admissionnumber: number;
  leaveType: string;
  noofdays: number;
  datefrom: Date;
  reason: number;
  status: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {studentName: 1, admissionnumber: 54, leaveType:'seek leave', noofdays: 1,datefrom:new Date(),reason:1,status:"approved"}
 
];

@Component({
  selector: 'app-student-leave',
  templateUrl: './student-leave.component.html',
  styleUrls: ['./student-leave.component.css']
})
export class StudentLeaveComponent implements OnInit {
  departmentIdFilter = new FormControl('');
  stafftypeFilter = new FormControl('');
  joiningDateFrom = new FormControl('');

  displayedColumns: string[] = ['studentName','admissionnumber','leaveType','noofdays','datefrom','reason','status'];
  filterValues = {
    //department: 
    departmentId :'',
   // designation: '',
    designationId: '',
    //status: '',
    employeementstatusId: '',
    //joiningDateFrom: '',
    joiningDate: ''
    //joiningDateTo: '',
  };

  studentFilter: FormGroup;
  
  dataSource1 = ELEMENT_DATA;
  
  department = SmsConstant.department;
  stafftype = SmsConstant.staffType;
  constructor(private fb: FormBuilder) {
    this.studentFilter = this.fb.group({
      departmentIdFilter: [''],
      stafftypeFilter: [''],
      joiningDateFrom: ['']
    });
    this.loadStudent();
   }

  ngOnInit(): void {
  }

  loadStudent()
  {
   // this.blockUI.start();

    // this.currentUserSubscription = this.staffApiService.getStaffs().subscribe((staff:any) => {
    //   this.currentStaff = staff;
    //   this.staffListData.data =staff;
    //    this.staffListData.paginator = this.paginator;
    //   this.staffListData.sort = this.sort;
    //   console.log(this.staffListData);
     
    //    this.blockUI.stop();
      
    //   this.rows = this.staffListData.data.length;
    //});
   // this.blockUI.stop();

  }

  applyFilter(event: any) {
    console.log(event,this.studentFilter.value)
  
    const filterValue = this.studentFilter.value[event];
    this.dataSource1.filter = filterValue.trim().toLowerCase();
    //this.staffListData.filter = filterValue.trim().toLowerCase();
  }

}