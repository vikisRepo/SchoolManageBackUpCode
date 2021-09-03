import { Component, OnInit,Output,EventEmitter, OnDestroy } from '@angular/core';
import { Validators } from '@angular/forms';
import { FormBuilder, FormGroup } from '@angular/forms';
import { constants } from 'buffer';
import { Observable, Observer } from 'rxjs';
import { SmsConstant } from 'src/app/shared/constant-values';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';
import { StaffrestApiService } from '../../staffrest-api.service';

@Component({
  selector: 'app-banking-details',
  templateUrl: './banking-details.component.html',
  styleUrls: ['./banking-details.component.css']
})
export class BankingDetailsComponent implements OnInit, OnDestroy,FormTouched {

  bankingFrom : FormGroup;
  @Output() formDetails=new EventEmitter();
  bank = SmsConstant.bank;
  destroy!: any;
  constructor(private fb: FormBuilder, private staffrestApiService : StaffrestApiService ) { 

    this.bankingFrom = this.fb.group({
      bankName : ['',Validators.required],
      bankAccountNumber : ['',Validators.required],
      panNumber : ['',Validators.required],
      branchNumber : ['',Validators.required],
      bankIfscCode : ['',Validators.required]
    });
    this.bankingFrom.valueChanges.subscribe(()=>{
      
      this.formDetails.emit({value:this.bankingFrom.value,valid:this.bankingFrom.valid});
    
    });
  }
  formTouched(): boolean {
    this.bankingFrom.markAllAsTouched();
    return this.bankingFrom.valid;
  }

  ngOnDestroy(): void {

    this.destroy.unsubscribe();
    
  }

  ngOnInit(): void {
     this.destroy = this.staffrestApiService.formValue$.subscribe((data : any) => {
       this.bankingFrom.patchValue(data);
     });
  }

}
