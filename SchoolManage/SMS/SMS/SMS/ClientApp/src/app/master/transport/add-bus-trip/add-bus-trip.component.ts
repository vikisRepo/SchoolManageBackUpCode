import { Component, OnInit, Query, QueryList, ViewChildren,EventEmitter, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { MessageBoxComponent } from 'src/app/shared/dialog-boxes/message-box/message-box.component';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';
import { BusTrips } from '../list-bus-trips/BusTrips';
import { TransportService } from '../transport.service';
import { BlockUI, NgBlockUI } from 'ng-block-ui';

@Component({
  selector: 'app-add-bus-trip',
  templateUrl: './add-bus-trip.component.html',
  styleUrls: ['./add-bus-trip.component.css']
})
export class AddBusTripComponent implements OnInit {

  @Output() addbusTripFormDetail=new EventEmitter<any>(); 
  tripDetailForm : FormControl;
  BusTrips: boolean[] = []
  selectedTab: number = 0;
  BusTripsResult:any ={};
  _trip:BusTrips;
  isAddMode?: boolean;
  id: any;

  @BlockUI() blockUI: NgBlockUI;

  @ViewChildren('dt') dt: QueryList<FormTouched>;
  constructor(private transportService : TransportService, public dialog: MatDialog, private route: ActivatedRoute) { }

  ngOnInit(): void {
    debugger;
    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;
  }

  ngAfterViewInit(): void {

    if (!this.isAddMode) {
      this.transportService.getBusTripDetail(this.id)
        .subscribe(data => {
          this.transportService.setFormValue(data);
        }, error => console.log(error));
    }
  }

  formTouched(): boolean{
    this.tripDetailForm.markAllAsTouched();
    return this.tripDetailForm.valid;
  }

  submit() {
    this.blockUI.start();
    if (this.BusTrips.includes(false)) {
      this.blockUI.stop();
      return;
    }
    if (this.isAddMode) {
      this.createBusTrips();
     } else {
      this.updateBusTrips();
     }
    this.blockUI.stop();
  }

  createBusTrips()
  {
    console.log(JSON.stringify(this.BusTripsResult));
    this.transportService.createBusTripDetail(this.BusTripsResult).subscribe(_ => {
      this.dialog.open(MessageBoxComponent, { width: '350px', height: '100px', data: "Trip Details saved successfully !" });
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500);
    });
  }

  updateBusTrips()
  {
    this.transportService.updateBusTripDetails(this.id, this.BusTripsResult).subscribe(_=>{
      this.dialog.open(MessageBoxComponent, { width: '350px', height: '100px', data: "Trip details updated successfully !" });
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500);
    });
  }

  setTabFormDetails(value: any,tab:number){
    this.BusTrips[tab] = value.valid;
    Object.assign(this.BusTripsResult,value.value);
  }

}
