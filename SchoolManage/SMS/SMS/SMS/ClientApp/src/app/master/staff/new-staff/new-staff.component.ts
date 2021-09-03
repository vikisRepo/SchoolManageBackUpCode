import { AfterViewInit, Component, OnInit, QueryList, ViewChildren } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { MessageBoxComponent } from 'src/app/shared/dialog-boxes/message-box/message-box.component';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';
import { Staff } from '../Staff';
import { StaffrestApiService } from '../staffrest-api.service';

@Component({
  selector: 'app-new-staff',
  templateUrl: './new-staff.component.html',
  styleUrls: ['./new-staff.component.css']
})
export class NewStaffComponent implements OnInit, AfterViewInit {

  formDetails: boolean[] = [];
  results: any = null;
  conResults: any = {};
  selectedTab: number = 0;
  id?: any;
  _staff?: Staff;
  isAddMode?: boolean;
  loading = false;
  submitted = false;

  @ViewChildren("dt") dt: QueryList<FormTouched>;

  @BlockUI() blockUI: NgBlockUI;

  constructor(private staffApiService: StaffrestApiService, private route: ActivatedRoute, public dialog: MatDialog) { }

  ngAfterViewInit(): void {

    if (!this.isAddMode) {
      this.staffApiService.getStaff(this.id)
        .subscribe(data => {
          this._staff = data;
          this.staffApiService.setFormValue(data);
          console.log(this._staff);
        }, error => console.log(error));
    }

  }

  ngOnInit(): void {

    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;


  }

  btnMovement(st: string) {
    let flg = this.dt.toArray()[this.selectedTab].formTouched();
    console.log(flg)
   
      if (st === 'bck') {
        this.selectedTab--;
      }
      else if (st === 'frd' && flg) {
        if (this.selectedTab >= 3) {
          this.submit();
          return;
        }
        this.selectedTab++;
      }
    
  }

  submit() {
    this.blockUI.start();
    this.submitted = true;


    if (this.formDetails.includes(false)) {
      this.blockUI.stop();
      return;
    }

    if (this.isAddMode) {
      this.createStaff();
    } else {
      this.updateSatff();
    }
    this.blockUI.stop();
  }

  createStaff() {
    this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"New Staff details successfully !"});
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500);
    this.staffApiService.createStaff(this.conResults).subscribe(_ => {
      this.dialog.open(MessageBoxComponent, { width: '250px', height: '200px', data: "create" });
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500);
    });
  }

  updateSatff() {
    this.dialog.open(MessageBoxComponent,{ width: '350px',height:'100px',data:"Staff details updated successfully !"});
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500);
    this.staffApiService.updateStaff(this.id, this.conResults).subscribe(_ => {
      
      this.dialog.open(MessageBoxComponent, { width: '250px', height: '200px', data: "update" });
      setTimeout(() => {
        this.dialog.closeAll();
        //routerlink needs
      }, 2500);
    });
  }

  setTabFormDetails(value: any, tab: number) {

    this.formDetails[tab] = value.valid;

    Object.assign(this.conResults, value.value);
    console.log(this.conResults);

  }

}
