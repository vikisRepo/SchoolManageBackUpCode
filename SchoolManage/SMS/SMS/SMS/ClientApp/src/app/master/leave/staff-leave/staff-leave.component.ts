import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl,FormGroup } from '@angular/forms';
import { matMenuAnimations } from '@angular/material/menu';
import { SmsConstant } from 'src/app/shared/constant-values';



export interface PeriodicElement {
  staffName: number;
  admissionnumber: number;
  leaveType: string;
  noofdays: number;
  datefrom: Date;
  reason: number;
  status: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {staffName: 1, admissionnumber: 54, leaveType:'seek leave', noofdays: 1,datefrom:new Date(),reason:1,status:"approved"}
 
];
@Component({
  selector: 'app-staff-leave',
  templateUrl: './staff-leave.component.html',
  styleUrls: ['./staff-leave.component.css']
})
export class StaffLeaveComponent implements OnInit {

  classFilter = new FormControl('');
  sectionFilter = new FormControl('');
  joiningDateFrom = new FormControl('');

  displayedColumns: string[] = ['studentName','admissionnumber','leaveType','noofdays','datefrom','reason','status'];
  

  stafffilters: FormGroup;
  
  dataSource1 = ELEMENT_DATA;
  
  class = SmsConstant.classes;
  section = SmsConstant.section;
  constructor(private fb: FormBuilder) {
    this.stafffilters = this.fb.group({
      classFilter: [''],
      sectionFilter: [''],
      joiningDateFrom: ['']
    });
    this.loadStaff();
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

  ngOnInit(): void {
  }
  
  applyFilter(event: any) {
    console.log(event)
  
    const filterValue = this.stafffilters.value[event];
    this.dataSource1.filter = filterValue.trim().toLowerCase();
    //this.staffListData.filter = filterValue.trim().toLowerCase();
  }

}
