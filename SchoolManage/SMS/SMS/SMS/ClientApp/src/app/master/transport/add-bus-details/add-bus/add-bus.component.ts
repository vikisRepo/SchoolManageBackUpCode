import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';


@Component({
  selector: 'app-add-bus',
  templateUrl: './add-bus.component.html',
  styleUrls: ['./add-bus.component.css']
})
export class AddBusComponent implements OnInit {
 @Output() busFormOutput=new EventEmitter<any>(); 
 formValues= {};
 busDetailForm: FormGroup;
 bustype = SmsConstant.busTypes;
 sendNotification = SmsConstant.notification;
  constructor(private fb:FormBuilder) {
    this.busDetailForm = this.fb.group({
      busTypeid : ['']
      ,company : ['']
      ,seatCount : ['']
      ,busNumber : ['']
      ,insurancePolicyNum : ['']
      ,insuranceEndDate : ['']
      ,notificationSpanId : ['']
    })

    this.busDetailForm.valueChanges.subscribe(() =>{
      Object.assign(this.formValues, this.busDetailForm.value);
      this.busFormOutput.emit({value: this.formValues});
    }
    )
   }
  
  ngOnInit(): void {
  }

}