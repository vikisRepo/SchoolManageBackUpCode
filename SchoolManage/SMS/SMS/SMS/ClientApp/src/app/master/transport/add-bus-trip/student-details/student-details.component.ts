import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css']
})
export class StudentDetailsComponent implements OnInit {
  @Output() studentFormOutput =new EventEmitter<any>();
  
  classes = SmsConstant.classes;
  sections = SmsConstant.section;
  constructor(private fb : FormBuilder) { 
    this.studentDetailForm = this.fb.group({
      class : ['',Validators.required],
      section : ['',Validators.required]
    }) 
  }
  studentDetailForm :FormGroup;
  ngOnInit(): void {
  }

}
