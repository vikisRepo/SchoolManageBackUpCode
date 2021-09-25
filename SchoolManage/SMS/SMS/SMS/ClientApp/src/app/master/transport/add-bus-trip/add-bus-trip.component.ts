import { Component, OnInit, Query, QueryList, ViewChildren } from '@angular/core';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';

@Component({
  selector: 'app-add-bus-trip',
  templateUrl: './add-bus-trip.component.html',
  styleUrls: ['./add-bus-trip.component.css']
})
export class AddBusTripComponent implements OnInit {

  BusTrips: boolean[] = []
  selectedTab: number = 0;

  @ViewChildren('dt') dt: QueryList<FormTouched>;
  constructor() { }

  ngOnInit(): void {
  }

  

  submit() {
    // debugger
    // this.blockUI.start();
    // // this.submitted = true;
       

    // if (this.BusAndDriverDetails.includes(false)) {
    //   this.blockUI.stop();
    //   return;
    // }

    // if (this.isAddMode) {
    //   this.createBusAndDriver();
    //  } else {
    //   this.updateBusAndDriver();
    //  }

    // this.blockUI.stop();


  }

  setTabFormDetails(value: any,tab:number){
    this.BusTrips[tab] = value.valid;
    Object.assign(this.BusTrips,value.value);
    // console.log(value.value);
  }

  btnMovement(st: string) {
    let flg = this.dt.toArray()[this.selectedTab].formTouched();
    if (st === 'bck') {
      this.selectedTab--;
    }
    else if (st === 'frd' && flg) {
      if (this.selectedTab >= 1) {
        this.submit();
        return;
      }
      this.selectedTab++;
    }
  }

}
