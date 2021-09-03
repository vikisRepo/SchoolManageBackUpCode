import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

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
  constructor(private fb:FormBuilder) {
    this.vendorDetailForm = this.fb.group({
      vendorName : ['', Validators.required]
      ,itemPriceorPerUnit : ['', Validators.required]
      ,vendorAddress : ['', Validators.required]
      ,vendorNumber : ['', Validators.required]
    });
    this.vendorDetailForm.valueChanges.subscribe(()=>{      
      Object.assign(this.formValues, this.vendorDetailForm.value);
      this.vendorFormDetails.emit({value: this.formValues});  
    });
   }
   formTouched(): boolean {
    this.vendorDetailForm.markAllAsTouched();
    return this.vendorDetailForm.valid;
  }

  ngOnInit(): void {
  }
}
