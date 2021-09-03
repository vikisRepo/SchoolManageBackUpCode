import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-track-my-bus',
  templateUrl: './track-my-bus.component.html',
  styleUrls: ['./track-my-bus.component.css']
})
export class TrackMyBusComponent implements OnInit {

  @Input() getTrackBusFormValues = {};
  trackMyBusForm: FormGroup;
  constructor(private fb: FormBuilder) {
    this.trackMyBusForm =this.fb.group({
      studentName: ['',Validators.required],
      class: ['',Validators.required],
      busNumber:['',Validators.required],
      driverName:['',Validators.required],
      driverNumber:['',Validators.required],
      status:['',Validators.required],
      arrivalTime :['',Validators.required]
    })
   } 

  ngOnInit(): void {
  }

}
