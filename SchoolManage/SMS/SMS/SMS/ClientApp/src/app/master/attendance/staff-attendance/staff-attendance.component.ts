import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl,FormGroup } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';

export interface PeriodicElement {
  staffName: number;
  employeeId: number;
  present: number;
  absent: number;
  halfday: number;
  leave: number;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {staffName: 1, employeeId: 54, present:1, absent: 0,halfday:0,leave:0}
 
];

@Component({
  selector: 'app-staff-attendance',
  templateUrl: './staff-attendance.component.html',
  styleUrls: ['./staff-attendance.component.css']
})
export class StaffAttendanceComponent implements OnInit {

  subjectFilter = new FormControl('');
  staffFilter = new FormControl('');
  joiningDateFrom = new FormControl('');

  displayedColumns: string[] = ['staffName','employeeId','present','absent','halfday','leave'];
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

  stafffilters: FormGroup;
  
  dataSource1 = ELEMENT_DATA;
  
  subjectlist = SmsConstant.Subjectsdropdown;
  stafflist = SmsConstant.staffType;
  constructor(private fb: FormBuilder) {
    this.stafffilters = this.fb.group({
      subjectFilter: [''],
      staffFilter: [''],
      joiningDateFrom: ['']
    });
    this.loadStaff();
   }

  ngOnInit(): void {
  }
  
  loadStaff()
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
    console.log(event)
  
    const filterValue = this.stafffilters.value[event];
    this.dataSource1.filter = filterValue.trim().toLowerCase();
    //this.staffListData.filter = filterValue.trim().toLowerCase();
  }

}
