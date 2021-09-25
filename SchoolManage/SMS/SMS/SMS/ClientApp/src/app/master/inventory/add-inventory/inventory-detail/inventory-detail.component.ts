import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';
import { InventoryService } from '../../inventory.service';

@Component({
  selector: 'app-inventory-detail',
  templateUrl: './inventory-detail.component.html',
  styleUrls: ['./inventory-detail.component.css']
})
export class InventoryDetailComponent implements OnInit,FormTouched {

  @Output() inventoryFormDetails=new EventEmitter<any>(); 
//  @Input() getFormValues = {};
 inventoryDetailForm: FormGroup;  
 itemtype = SmsConstant.itemName;
 itemusageAreaType = SmsConstant.itemUsageArea;
 formValues = {};
 disabled = false;
  constructor(private fb:FormBuilder, private _InventoryAPI: InventoryService) {

    this.inventoryDetailForm = this.fb.group({
      itemName : ['',Validators.required]
      ,itemTypeId : ['',Validators.required]
      ,modelNumber : ['',[Validators.required,Validators.pattern(/^[a-zA-Z0-9_]*$/)]]
      ,serialNumber : ['',[Validators.required,Validators.pattern(/^[a-zA-Z0-9_]*$/)]]
      ,warrenOrGarenInfo : ['',Validators.required] 
      ,itemUsageId : ['',Validators.required]
      ,warrenOrGarantee: [false, Validators.required]
      ,brandName : ['',Validators.required]
      ,quantity : [,[Validators.required, Validators.pattern(/^[0-9]\d*$/)]]
    })
    this.inventoryDetailForm.valueChanges.subscribe(()=>{
      // this.disabled = !this.inventoryDetailForm['warrenOrGarantee'].value;
      Object.assign(this.formValues, this.inventoryDetailForm.value);
      this.inventoryFormDetails.emit({value: this.inventoryDetailForm.value, valid:this.inventoryDetailForm.valid});
      // this.inventoryFormDetails.emit({value:this.inventoryDetailForm.value,valid:this.inventoryDetailForm.valid});
    
    });
   }
   
  formTouched(): boolean {
    this.inventoryDetailForm.markAllAsTouched();
    return this.inventoryDetailForm.valid;
  }

  ngOnChanges(changes: SimpleChanges): void {

    if (changes.getFormValues.currentValue) {
    }
  }

  
      // convenience getter for easy access to form fields
      get f() { return this.inventoryDetailForm.controls; }

  ngOnDestroy(): void {

    //this.destroy.unsubscribe();
    
  }

  ngOnInit(): void {
    this._InventoryAPI.formValue$.subscribe((data : any) => {
      this.inventoryDetailForm.patchValue(data);
      // this.toggle();
    });
  }

  toggle() {
    debugger;
    if (this.inventoryDetailForm.get('warrenOrGarantee').enabled) {
      this.inventoryDetailForm.get('warrenOrGarenInfo').enable();
      return;
    }
    // this.parents.reset();
    this.inventoryDetailForm.get('warrenOrGarenInfo').disable();
  }

}

