import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormGroup ,FormBuilder, Validators} from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
import { FactorydataService } from 'src/app/shared/factorydata.service';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';
import { TransportService } from '../../transport.service';

@Component({
  selector: 'app-trip-details',
  templateUrl: './trip-details.component.html',
  styleUrls: ['./trip-details.component.css']
})
export class TripDetailsComponent implements OnInit {
  @Output() tripFormOutput = new EventEmitter<any>();
  @Output() studentFormOutput =new EventEmitter<any>();
  tripDetailForm :FormGroup;
  busAndDriverDetails = SmsConstant.busAndDriverDetails;
  formValues ={};
  constructor(private fb : FormBuilder, factory : FactorydataService, private transportService : TransportService) { 
    this.busAndDriverDetails = factory.busAndDriverDetails;
    this.tripDetailForm = this.fb.group({
      tripNumber : ['',Validators.required],
      tripAreas : ['',Validators.required],
      busNumbersList : ['',Validators.required],
      driverName : ['',Validators.required],
      driverNumber : ['',Validators.required],
      tripTimingFrom: ['', [Validators.required]],
      tripTimingTo: ['', [Validators.required]],
      busesAndDriverId:['']
    }) 
    this.tripDetailForm.valueChanges.subscribe(()=>{
      Object.assign(this.formValues,this.tripDetailForm.value);
      this.tripFormOutput.emit({value: this.tripDetailForm.value,valid:this.tripDetailForm.valid})
    })
  }

  ngOnInit(): void {
    debugger;
    this.transportService.formValue$.subscribe((data : any) => {
      this.tripDetailForm.patchValue(data);
      this.tripDetailForm.get('busNumbersList').setValue(data.busesAndDrivers.busesAndDriverId);
      console.log("Inside Driver Details");
    });
  }

  formTouched(): boolean {
    this.tripDetailForm.markAllAsTouched();
    return this.tripDetailForm.valid;
  }

  LoadDriverDetails(driverDetails)
  {
    this.tripDetailForm.get('driverName').setValue(driverDetails.value['driverName']);
    this.tripDetailForm.get('driverNumber').setValue(driverDetails.value['driverNumber']);
    this.tripDetailForm.get('busesAndDriverId').setValue(driverDetails.value['busesAndDriverId']);
  }


}
