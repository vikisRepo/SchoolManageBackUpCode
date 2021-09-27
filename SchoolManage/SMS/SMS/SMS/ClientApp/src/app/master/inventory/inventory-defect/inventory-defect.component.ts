import { Component, OnInit, Output,EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { MessageBoxComponent } from 'src/app/shared/dialog-boxes/message-box/message-box.component';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';
import { InventoryService } from '../inventory.service';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-inventory-defect',
  templateUrl: './inventory-defect.component.html',
  styleUrls: ['./inventory-defect.component.css']
})
export class InventoryDefectComponent implements OnInit {

  inventoryDefectForm : FormGroup;
  
  //toppingList:string[]=['Tamil','English','Maths','Science','social'];
  @Output() formDetails=new EventEmitter();
  id: any;
  obj: any;
  enabletrash : any = true;

  get defect() : FormArray {
    return this.inventoryDefectForm.get('InventoryDefects') as FormArray;
  };

  constructor(private fb : FormBuilder, private inventoryDefectService : InventoryService, public dialog: MatDialog) {
    this.inventoryDefectForm = this.fb.group({
      InventoryDefects: this.fb.array([]) //[this.buildDefects()]
    });
    this.inventoryDefectForm.valueChanges.subscribe(()=>{
      this.formDetails.emit({ value: this.inventoryDefectForm.value,
               valid: this.inventoryDefectForm.valid });
    });
   }
  formTouched(): boolean {
    this.inventoryDefectForm.markAllAsTouched();
   return this.inventoryDefectForm.valid;
  }

  ngOnInit(): void {
    
    this.LoadInventoryDefect();
  }

  LoadInventoryDefect()
  {
    this.inventoryDefectForm.reset();
    this.inventoryDefectService.getInventoryDefects().subscribe((data : any) => {
      console.log(JSON.stringify(data));
      this.inventoryDefectForm.patchValue(data);
      data.inventoryDefects.forEach((x, index) => {
        this.defect.push(this.fb.group(x))
      });
      this.defect.disable()
      if(this.defect.length == 0)
        this.enabletrash = false;
      else
        this.enabletrash = true;  
         
    });
  }

  addDefects(): void {
    this.defect.push(this.buildDefects());
  }

  buildDefects(): FormGroup {
    return this.fb.group({
      inventoryDefectId: [0],
      itemName: ['', Validators.required],
      itemCode: ['', Validators.required],
      defectDesc: ['', Validators.required],
  
    });
    
  }

  CreateInventoryDefect(deffectData : any)
  {
    this.inventoryDefectService.createAndUpdateInventoryDefect(deffectData).subscribe( _=> {
      this.dialog.open(MessageBoxComponent, { width: '350px', height: '100px', data: "InventoryDefects Saved successfully !" });
      setTimeout(() => {
        this.dialog.closeAll();
        this.LoadInventoryDefect();
      }, 5000);
    });
  }

  deleteDefect(index: number)
  {
    console.log(this.defect.at(index).value.inventoryDefectId);
    this.inventoryDefectService.deleteInventoryDefects(this.defect.at(index).value.inventoryDefectId).subscribe( _=> {
      this.dialog.open(MessageBoxComponent, { width: '350px', height: '100px', data: "Inventory Details deleted successfully !" });
      setTimeout(() => {
        this.defect.removeAt(index);
        this.dialog.closeAll();
      }, 5000);
    });
  }

  changeandunchange(flg:boolean , index : number){
    if(flg)
      {
        console.log(this.defect.at(index).value)
       this.CreateInventoryDefect(this.defect.at(index).value);
        this.defect.at(index).disable();
      }
    else{
        this.defect.at(index).enable();
    }

  }

}
