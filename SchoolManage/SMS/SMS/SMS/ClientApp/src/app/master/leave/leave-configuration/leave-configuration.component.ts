import { Component, OnInit, Output,EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';

@Component({
  selector: 'app-leave-configuration',
  templateUrl: './leave-configuration.component.html',
  styleUrls: ['./leave-configuration.component.css']
})
export class LeaveConfigurationComponent implements OnInit {

  leaveForm : FormGroup;
  staffLeave: FormGroup;

  @Output() formDetails=new EventEmitter();

  get studentLeave() : FormArray {
    return this.leaveForm.get('studentLeave') as FormArray;
  };

  get staffLeavearr(): FormArray {
    return this.staffLeave.get('staffLeave') as FormArray;
  };

  constructor(private fb : FormBuilder) {
    this.leaveForm = this.fb.group({
      studentLeave: this.fb.array([this.buildStudentLeave()]),
     // staffLeave: this.fb.array([this.buildStaffLeave]),
      staffLeave : this.fb.group({
        staffLeavearr : this.fb.array([this.buildStaffLeave])
      })
    });

    this.leaveForm.valueChanges.subscribe(()=>{
      this.formDetails.emit({ value: this.leaveForm.value,
               valid: this.leaveForm.valid });
    });
   }

  ngOnInit(): void {
  }
  addStudentleave(): void {
    this.studentLeave.push(this.buildStudentLeave());
  }

  addStaffleave(): void {
    this.studentLeave.push(this.buildStaffLeave());
  }

  buildStudentLeave(): FormGroup {
    return this.fb.group({
      studentLeave: '',
    });
    
  }
  buildStaffLeave(): FormGroup {
    return this.fb.group({
      staffLeave: '',
    });
    
  }

}
