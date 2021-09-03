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

  constructor(private route: ActivatedRoute, public dialog: MatDialog, private _BusanddriverServiceAPI: BusanddriverService) { }
  ngAfterViewInit(): void {

    if (!this.isAddMode) {
      // console.log(this._busAndDriver);
      this._BusanddriverServiceAPI.getBusAnddriver(this.id)
        .subscribe(data => {
          this._busAndDriver = data;
          this._BusanddriverServiceAPI.setFormValue(data);
          
        }, error => console.log(error));
    }

  }


  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;
    // if (Object.keys(this.expData).length != 0) {

    //   this.BusAndDriverGrp.disable();
    //   this.BusAndDriverGrp.setValue(this.expData);
    // }
    // else {

    //   this.BusAndDriver = true;
    // }
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
    debugger
    this.blockUI.start();
    // this.submitted = true;


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
    // if(!this.stuFormtDetails.includes(false)){
    //   return;
    // }

  }

  createBusAndDriver() {
    // console.log(this.busAndDriJsonResult);
    this._BusanddriverServiceAPI.createBusAnddriver(this.busAndDriJsonResult).subscribe(_ => {
      this.dialog.open(MessageBoxComponent, { width: '350px', height: '100px', data: "Bus And Driver Details updated successfully !" });
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500);
    });
  }
  // this.studentApiService.createStudent(this.stuJsonResult).subscribe(_=>{
  //   this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"student feedback updated successfully !"});
  //   setTimeout(() => {
  //     this.dialog.closeAll();
  //   }, 2500);
  // });

  updateBusAndDriver()
  {
    this._BusanddriverServiceAPI.updateBusAnddriver(this.id, this.busAndDriJsonResult).subscribe(_=>{

    });
  }

  setTabFormDetails(value: any,tab:number){
    this.BusAndDriverDetails[tab] = value.valid;
    Object.assign(this.busAndDriJsonResult,value.value);
    // console.log(value.value);
  }
}






