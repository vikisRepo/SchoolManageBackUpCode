import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl,FormGroup } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
export interface PeriodicElement {
  student: number;
  admissionnumber: number;
  present: number;
  absent: number;
  halfday: number;
  leave: number;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {student: 1, admissionnumber: 54, present:1, absent: 0,halfday:0,leave:0}
 
];

@Component({
  selector: 'app-student-attendance',
  templateUrl: './student-attendance.component.html',
  styleUrls: ['./student-attendance.component.css']
})
export class StudentAttendanceComponent implements OnInit {

  classFilter = new FormControl('');
  sectionFilter = new FormControl('');
  joiningDateFrom = new FormControl('');

  displayedColumns: string[] = ['student','admissionnumber','present','absent','halfday','leave'];

  studentfilters: FormGroup;
  
  dataSource1 = ELEMENT_DATA;
  
  class = SmsConstant.classes;
  section = SmsConstant.section;
  blockUI: any;
  constructor(private fb: FormBuilder) {
    this.studentfilters = this.fb.group({
      classFilter: [''],
      sectionFilter: [''],
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
    console.log(event)
  
    const filterValue = this.studentfilters.value[event];
    this.dataSource1.filter = filterValue.trim().toLowerCase();
    //this.staffListData.filter = filterValue.trim().toLowerCase();
  }

}
