import { AfterViewInit, Component, OnInit, QueryList,ViewChildren } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { MessageBoxComponent } from 'src/app/shared/dialog-boxes/message-box/message-box.component';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';
import { InventoryService } from '../inventory.service';
import {Inventory} from '../inventory'

@Component({
  selector: 'app-add-inventory',
  templateUrl: './add-inventory.component.html',
  styleUrls: ['./add-inventory.component.css']
})
export class AddInventoryComponent implements OnInit {

  inventoryFormDetails: boolean[] =[]
  // results : any =null;
  invJsonResult: any ={};
  selectedTab:any=0;
  isAddMode?: boolean;
  _Inventory: Inventory;
  id : any;
  
  // @ViewChildren("dt") dt: QueryList<FormTouched>;

  @BlockUI() blockUI: NgBlockUI;
  
  constructor(private route: ActivatedRoute, public dialog: MatDialog, private _InventoryAPI: InventoryService) { }

  ngAfterViewInit(): void {

    if(!this.isAddMode)
    {
      this._InventoryAPI.getInventory(this.id)
        .subscribe(data => {
          this._Inventory = data;
          this._InventoryAPI.setFormValue(data);
          // console.log(this._Inventory);
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

  submit(){
debugger
    this.blockUI.start();
    // this.submitted = true;


   if (this.inventoryFormDetails.includes(false)) {
       this.blockUI.stop();
      return;
    }

    if (this.isAddMode) {
      this.createInventory();
     } else {
      this.updateInventory();
     }

     this.blockUI.stop();

    // if(!this.inventoryFormDetails.includes(false)){
    //   return;
    // } 
     
  }

  createInventory()
  {
    console.log(JSON.stringify(this.invJsonResult));
    this._InventoryAPI.createInventory(this.invJsonResult).subscribe( _=> {
      this.dialog.open(MessageBoxComponent, { width: '350px', height: '100px', data: "Inventory Details updated successfully !" });
      setTimeout(() => {
        this.dialog.closeAll();
      }, 2500);
    });
  }

  updateInventory()
  {
    this._InventoryAPI.updateInventory(this.id, this.invJsonResult).subscribe(_=>{});
  }
  
  setTabFormDetails(value: any,tab:number){
    this.inventoryFormDetails[tab] = value.valid;
    Object.assign(this.invJsonResult,value.value);
    // console.log(value.value);
  }


}

