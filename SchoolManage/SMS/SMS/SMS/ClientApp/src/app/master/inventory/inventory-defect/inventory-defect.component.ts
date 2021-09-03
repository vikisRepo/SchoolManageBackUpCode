import { Component, OnInit, Output,EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';

@Component({
  selector: 'app-inventory-defect',
  templateUrl: './inventory-defect.component.html',
  styleUrls: ['./inventory-defect.component.css']
})
export class InventoryDefectComponent implements OnInit {

  inventoryDefectForm : FormGroup;
  
  //toppingList:string[]=['Tamil','English','Maths','Science','social'];
  @Output() formDetails=new EventEmitter();

  get defect() : FormArray {
    return this.inventoryDefectForm.get('defect') as FormArray;
  };

  constructor(private fb : FormBuilder) {
    this.inventoryDefectForm = this.fb.group({
      defect: this.fb.array([this.buildDefects()])
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
    
  }

  addDefects(): void {
    this.defect.push(this.buildDefects());
  }

  buildDefects(): FormGroup {
    return this.fb.group({
      ItemName: ['', Validators.required],
      ItemCode: ['', Validators.required],
      DefectDesc: ['', Validators.required],
    });
    
  }
  
}
