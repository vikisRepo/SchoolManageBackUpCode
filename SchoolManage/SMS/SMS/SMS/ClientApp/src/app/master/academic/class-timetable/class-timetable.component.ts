import { ThrowStmt } from '@angular/compiler';
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
import { FactorydataService } from 'src/app/shared/factorydata.service';

@Component({
  selector: 'app-class-timetable',
  templateUrl: './class-timetable.component.html',
  styleUrls: ['./class-timetable.component.css']
})
export class ClassTimetableComponent implements OnInit {
  @Input() getFormValues = {"class":"","section":""};
  std:string;
  sec:string;
  tablefilters: FormGroup;
  classes = SmsConstant.classes;
  sectiones =SmsConstant.Sectiondropdown;
  constructor(private fb: FormBuilder,private factory: FactorydataService) {
    this.tablefilters = this.fb.group({
      classFilter: [''],
      sectionFilter: ['']
    });
    this.classes = factory.classes;
   }

  ngOnInit(): void {
  }
  applyFilter(event : any)
  {
    debugger;
    const filterValue =this.tablefilters.value[event];
    if(event=="classFilter")
    {
      this.std=filterValue;
      this.getFormValues.class+=this.std;
    }
    else{
      this.sec=filterValue;
      this.getFormValues.section=this.sec;
    }
  }

}
