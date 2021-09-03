import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { Subscription } from 'rxjs';
import { AttendancerestApiService } from '../attendancerest-api.service';


export interface PeriodicElement {
  month: number;
  attendance: number;
  totalDays: number;
  present: number;
  absent: number;
  halfday: number;
  leave: number;
}
//adding dummy data 
const ELEMENT_DATA: PeriodicElement[] = [
  {month: 1, attendance: 54, totalDays: 1.0079,present:1, absent: 1,halfday:1,leave:1}
 
];
  

@Component({
  selector: 'app-my-attendance',
  templateUrl: './my-attendance.component.html',
  styleUrls: ['./my-attendance.component.css']
})
export class MyAttendanceComponent implements OnInit {


  //myattendanceListData!: MatTableDataSource<any>;
  currentUserSubscription !: Subscription;
  displayedColumns: string[] = ['month','attendance', 'totalDays','present','absent','halfday','leave'];
  
  //showing dummy data
  dataSource = ELEMENT_DATA;
  constructor(private attendanceService:AttendancerestApiService) { }

  ngOnInit(): void {

  }
  LoadMyAttendance()
  {
    // this.blockUI.start();

    // this.currentUserSubscription = this.attendanceService.getMyAttenance();
    //    this.blockUI.stop();

   // });

  }

}
