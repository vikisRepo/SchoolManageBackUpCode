import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormGroup ,FormBuilder, Validators} from '@angular/forms';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';

@Component({
  selector: 'app-trip-details',
  templateUrl: './trip-details.component.html',
  styleUrls: ['./trip-details.component.css']
})
export class TripDetailsComponent implements OnInit {
  @Output() tripFormOutput = new EventEmitter<any>();
  @Output() studentFormOutput =new EventEmitter<any>();
  tripDetailForm :FormGroup;
  constructor(private fb : FormBuilder) { 
    this.tripDetailForm = this.fb.group({
      tripNumber : ['',Validators.required],
      tripAreas : ['',Validators.required],
      busNumber : ['',Validators.required],
      driverName : ['',Validators.required],
      driverNumber : ['',Validators.required]
    }) 
  }

  ngOnInit(): void {
    // this.destroy = this.staffrestApiService.formValue$.subscribe((data : any) => {
    //   this.bankingFrom.patchValue(data);
  }
  
  formTouched(): boolean {
    this.tripDetailForm.markAllAsTouched();
    return this.tripDetailForm.valid;
  }

}
