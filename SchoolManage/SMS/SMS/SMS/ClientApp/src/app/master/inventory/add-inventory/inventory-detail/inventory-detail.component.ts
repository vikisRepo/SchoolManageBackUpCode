import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';

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
  constructor(private fb:FormBuilder) {

    this.inventoryDetailForm = this.fb.group({
      itemName : ['',Validators.required]
      ,itemTypeId : ['',Validators.required]
      ,modelNumber : ['',Validators.required]
      ,serialNumber : ['',Validators.required]
      ,warrenOrGarenInfo : [{ value: '', disabled: this.disabled },Validators.required, ]
      ,itemUsageId : ['',Validators.required]
      ,warrenOrGarantee: [true]
      ,brandName : ['',Validators.required]
      ,quantity : ['',Validators.required]
    })
    this.inventoryDetailForm.valueChanges.subscribe(()=>{
      this.disabled = !this.inventoryDetailForm['warrenOrGarantee'].value;
      Object.assign(this.formValues, this.inventoryDetailForm.value);
      this.inventoryFormDetails.emit({value: this.formValues});
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

  ngOnDestroy(): void {

    //this.destroy.unsubscribe();
    
  }

  ngOnInit(): void {
  }

}

