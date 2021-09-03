import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Console } from 'console';

@Component({
  selector: 'app-driver-details',
  templateUrl: './driver-details.component.html',
  styleUrls: ['./driver-details.component.css']
})
export class DriverDetailsComponent implements OnInit {
  @Output() driverFormOutput=new EventEmitter<any>(); 
  formValues = {};
  busDriverDetailForm: FormGroup;
  constructor(private fb:FormBuilder) {
    this.busDriverDetailForm = this.fb.group({
      driverName : ['']
      ,driverNumber : ['']
      ,driverAadhar : ['']
    });

    this.busDriverDetailForm.valueChanges.subscribe(() => {
      Object.assign(this.formValues, this.busDriverDetailForm.value);
      // alert(JSON.stringify(this.formValues));
      this.driverFormOutput.emit({value: this.formValues});
    }

    )
   }

  ngOnInit(): void {
  }

}
