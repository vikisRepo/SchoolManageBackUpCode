import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';

@Component({
  selector: 'app-class-timetable',
  templateUrl: './class-timetable.component.html',
  styleUrls: ['./class-timetable.component.css']
})
export class ClassTimetableComponent implements OnInit {

  tablefilters: FormGroup;
  classes = SmsConstant.classes;
  sectiones =SmsConstant.Sectiondropdown;
  constructor(private fb: FormBuilder) {
    this.tablefilters = this.fb.group({
      classFilter: [''],
      sectionFilter: ['']
    });
   }

  ngOnInit(): void {
  }
  applyFilter(event : any)
  {
    const filterValue =this.tablefilters.value[event];
    
  }

}
