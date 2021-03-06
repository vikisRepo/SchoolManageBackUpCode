import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { ActivatedRoute } from '@angular/router';
import { MessageBoxComponent } from 'src/app/shared/dialog-boxes/message-box/message-box.component';
import { MatDialog } from '@angular/material/dialog';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BusanddriverService } from './busanddriver.service';
import { BusAndDriver } from './BusAndDriver';


@Component({
  selector: 'app-add-bus-details',
  templateUrl: './add-bus-details.component.html',
  styleUrls: ['./add-bus-details.component.css']
})
export class AddBusDetailsComponent implements OnInit {

  BusAndDriverDetails: boolean[] = []
  isAddMode?: boolean;
  id: any;
  busAndDriJsonResult: any = {};
  _busAndDriver: BusAndDriver;
  selectedTab: number = 0;

  @BlockUI() blockUI: NgBlockUI;

  constructor(private route: ActivatedRoute, public dialog: MatDialog,
     private _BusanddriverServiceAPI: BusanddriverService) { }
  
  ngAfterViewInit(): void {

    if (!this.isAddMode) {
      this._BusanddriverServiceAPI.getBusAnddriver(this.id)
        .subscribe(data => {
          debugger;
          this._busAndDriver = data;
          this._BusanddriverServiceAPI.setFormValue(this._busAndDriver);
          console.log(this._busAndDriver);
        }, error => console.log(error));
    }

  }


  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;
  }

  btnMovement(st: string) {
    if (st === 'bck') {
      this.selectedTab--;
    }
    else if (st === 'frd') {
      if (this.selectedTab >= 1) {
        this.submit();
        return;
      }
      this.selectedTab++;
    }
  }

  submit() {
    this.blockUI.start();
    if (this.BusAndDriverDetails.includes(false)) {
      this.blockUI.stop();
      return;
    }
    if (this.isAddMode) {
      this.createBusAndDriver();
     } else {
      this.updateBusAndDriver();
     }
    this.blockUI.stop();
  }

  createBusAndDriver() {
    this._BusanddriverServiceAPI.createBusAnddriver(this.busAndDriJsonResult).subscribe(_ => {
      this.dialog.open(MessageBoxComponent, { width: '350px', height: '100px', data: "Bus And Driver Details saved successfully !" });
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500);
    });
  }

  updateBusAndDriver()
  {
    this._BusanddriverServiceAPI.updateBusAnddriver(this.id, this.busAndDriJsonResult).subscribe(_=>{
      this.dialog.open(MessageBoxComponent, { width: '350px', height: '100px', data: "Bus And Driver Details updated successfully !" });
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500);
    });
  }

  setTabFormDetails(value: any,tab:number){
    this.BusAndDriverDetails[tab] = value.valid;
    Object.assign(this.busAndDriJsonResult,value.value);
  }

}






