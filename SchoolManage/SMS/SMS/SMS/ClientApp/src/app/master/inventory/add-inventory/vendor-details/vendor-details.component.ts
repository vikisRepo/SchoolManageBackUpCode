import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { InventoryService } from '../../inventory.service';

@Component({
  selector: 'app-vendor-details',
  templateUrl: './vendor-details.component.html',
  styleUrls: ['./vendor-details.component.css']
})
export class VendorDetailsComponent implements OnInit {
  
  @Output() vendorFormDetails=new EventEmitter<any>(); 
  // @Input() getFormValues = {};
  vendorDetailForm: FormGroup;
  formValues = {};

  constructor(private fb:FormBuilder, private _InventoryAPI: InventoryService) {

    this.vendorDetailForm = this.fb.group({
      vendorName : ['']
      ,itemPriceorPerUnit : [,[Validators.required, Validators.pattern(/^[0-9]\d*$/)]]
      ,vendorAddress : ['']
      ,vendorNumber : ['']
    });
    
    this.vendorDetailForm.valueChanges.subscribe(()=>{      
  
      // Object.assign(this.formValues, this.vendorDetailForm.value);
      this.vendorFormDetails.emit({value: this.vendorDetailForm.value, valid:this.vendorDetailForm.valid});  
    });
   }
   get f() { return this.vendorDetailForm.controls; }
   formTouched(): boolean {

    this.vendorDetailForm.markAllAsTouched();
    return this.vendorDetailForm.valid;
    }

  ngOnInit(): void {

    this._InventoryAPI.formValue$.subscribe((data : any) => {
      console.log("Vendor Details" + JSON.stringify(data));
      this.vendorDetailForm.patchValue(data);
    });
  }

}
