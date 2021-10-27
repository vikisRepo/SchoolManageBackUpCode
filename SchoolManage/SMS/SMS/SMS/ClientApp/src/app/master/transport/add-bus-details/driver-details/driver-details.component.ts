import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Console } from 'console';
import { BusanddriverService } from '../busanddriver.service';

@Component({
  selector: 'app-driver-details',
  templateUrl: './driver-details.component.html',
  styleUrls: ['./driver-details.component.css']
})
export class DriverDetailsComponent implements OnInit {
  @Output() driverFormOutput=new EventEmitter<any>(); 
  formValues = {};
  busDriverDetailForm: FormGroup;
  constructor(private fb:FormBuilder, private _BusanddriverServiceAPI: BusanddriverService) {
    this.busDriverDetailForm = this.fb.group({
       driverName : ['', Validators.required]
      ,driverNumber : ['', Validators.required]
      ,driverAadhar : ['', Validators.required]
    });

    this.busDriverDetailForm.valueChanges.subscribe(() => {
      Object.assign(this.formValues, this.busDriverDetailForm.value);
      // alert(JSON.stringify(this.formValues));
      this.driverFormOutput.emit({value: this.formValues, valid:this.busDriverDetailForm.valid});
    }

    )
   }

  ngOnInit(): void {
    debugger;
    this._BusanddriverServiceAPI.formValue$.subscribe((data : any) => {
      this.busDriverDetailForm.patchValue(data);
      console.log("Inside Driver Details");
    });
  }

}
