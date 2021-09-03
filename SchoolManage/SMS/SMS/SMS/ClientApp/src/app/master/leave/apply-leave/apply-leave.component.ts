import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { FormControl, FormGroup, FormArray } from '@angular/forms';
import { Console } from 'console';
import { SmsConstant } from 'src/app/shared/constant-values';
@Component({
  selector: 'app-apply-leave',
  templateUrl: './apply-leave.component.html',
  styleUrls: ['./apply-leave.component.css']
})
export class ApplyLeaveComponent implements OnInit {

  @Output() formDetails=new EventEmitter();
 
  leaveform : FormGroup;
  leavetype=SmsConstant.leaveType;
  leaveSession=SmsConstant.leaveSession;
  snodays : any;


  constructor(private fb:FormBuilder) { 
    this.leaveform = this.fb.group({
      leavetype : [''],
      datefrom : [''],
      dateto : [''],
      leavesession : [''],
      noofdays : [''],
      reason :['']
    });
    this.leaveform.valueChanges.subscribe(()=>{
      
      this.formDetails.emit({value:this.leaveform.value,valid:this.leaveform.valid});
      console.log(this.leaveform.value);
      // snodays = days_between()
    
    });
  }

  ngOnInit(): void {
  }

  days_between(date1, date2) {

    // The number of milliseconds in one day
    const ONE_DAY = 1000 * 60 * 60 * 24;

    // Calculate the difference in milliseconds
    const differenceMs = Math.abs(date1 - date2);

    // Convert back to days and return
    return Math.round(differenceMs / ONE_DAY);

}

  // ngOnInit(): void {
  //   this.staffrestApiService.formValue$.subscribe((data : any) => {
  //     this.empDetailsForm.patchValue(data);
  //   });
  // }

}
