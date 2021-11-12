import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AnonymousSubject } from 'rxjs/internal/Subject';
import { TimeTableService } from '../services/time-table.service';
import { TimeTableEditorComponent } from '../time-table-editor/time-table-editor.component';

@Component({
  selector: 'app-time-table-viewer',
  templateUrl: './time-table-viewer.component.html',
  styleUrls: ['./time-table-viewer.component.css']
})
export class TimeTableViewerComponent implements OnInit {
  @Input() public classdetails : any;
  l = { j: 6 };

  timePeriod = ['', '&#8544;', '&#8545;', '&#8546;', '&#8547;', '&#8548;', '&#8549;', '&#8550;', '&#8551;', '&#8552;'];

  weekDays = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'];
  numBreaks = 0;

  table = {};

  dataSrc = {
    addtionlWeekDays: ['Sat'],
    //periods: 9,
    table: [
      {
        day: 'Mon',
        period: 1,
        subject: 'English',
        staff: "Dinesh",
        startTime: '09:00',
        endTime: '09:45'
      },
      {
        day: 'Mon',
        period: 2,
        subject: 'English',
        staff: "Dinesh",
        startTime: '09:00',
        endTime: '09:45'
      }
      ,
      {
        day: 'Mon',
        period: 3,
        subject: 'English',
        staff: "Dinesh",
        startTime: '09:00',
        endTime: '09:45'
      }
    ]
  };

  constructor(private ttServObj: TimeTableService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.table = this.getIndex();
    console.log(this.classdetails.class+" "+this.classdetails.section);
  }

  getIndex() {
    let k = this.dataSrc.table.reduce((a, cv) => {
      if (a[cv.day]) {
        (a[cv.day])[cv.period] = cv;
      }
      else {
        a[cv.day] = {};
        (a[cv.day])[cv.period] = cv;
      }

      return a;
    }, {});
    return k;
  }

  selectPeriod(obj) {
    debugger;
    var merged:any;
    let timetableClassDetails = {timeTableMasterdetails : this.classdetails};
    if(obj != "null" && obj != "undefined")
     merged = Object.assign(obj, timetableClassDetails);
    else
     merged = timetableClassDetails;
    this.ttServObj.setData = merged;
    this.dialog.open(TimeTableEditorComponent, { data: merged })
  }

}
