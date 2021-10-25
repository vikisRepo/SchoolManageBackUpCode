import { Component, OnInit, Output,EventEmitter } from '@angular/core';
import { validateBasis } from '@angular/flex-layout';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { FormControl, FormGroup, FormArray } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
import { FactorydataService } from 'src/app/shared/factorydata.service';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';
import { StaffrestApiService } from '../../staffrest-api.service';
@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css']
})
export class EmployeeDetailsComponent implements OnInit,FormTouched {

  @Output() formDetails=new EventEmitter();

  empDetailsForm : FormGroup;
  staffId=SmsConstant.staffType;  
  department = SmsConstant.department;
  designation = SmsConstant.designation;
  employeementStatus= SmsConstant.employmentStatus;
  role = SmsConstant.role;
  education = SmsConstant.education;
  reportingTo =SmsConstant.reportingTo;
  active_value = SmsConstant.active;
  submitted = true;



  constructor(private fb: FormBuilder, private staffrestApiService : StaffrestApiService, private factory: FactorydataService) {    
    
    
    this.staffId=factory.staffType;  
    this.department = factory.department;
    this.designation = factory.designation;
    this.role = factory.role;
    this.employeementStatus = factory.employmentStatus;
    
    this.empDetailsForm = this.fb.group(  
      // Validators.pattern('^[a-zA-Z ]*$')]],  
      //  Validators.pattern(/^[0-9]\d*$/)
      {
        teacherId : [,[Validators.required, Validators.pattern(/^[a-zA-Z0-9_]*$/)]],
        employeeId : [,[Validators.required, Validators.pattern(/^[a-zA-Z0-9_]*$/)]],  //, 
        educationId : ['',Validators.required],
        officialEmailId : [,[Validators.required,Validators.email]],
        esinumber : [''],
        staffTypeId : ['',Validators.required],
        employeementStatusId : ['',Validators.required],
        reportingTo : ['',Validators.required],
        epfnumber : [''],
        departmentId : ['',Validators.required],
        joiningDate : ['',Validators.required],
        activeId : ['',Validators.required],
        uannumber : [''],
        designationId : ['',Validators.required],
        roleId : ['',Validators.required]
      }
    );
    this.empDetailsForm.valueChanges.subscribe(()=>{
      
      this.formDetails.emit({value:this.empDetailsForm.value,valid:this.empDetailsForm.valid});
    
    });
  }
  formTouched(): boolean {
   this.empDetailsForm.markAllAsTouched();
   return this.empDetailsForm.valid;
  }

      // convenience getter for easy access to form fields
  get f() { return this.empDetailsForm.controls; }

onSubmit(){

}
  ngOnInit(): void {
    debugger;
    this.staffrestApiService.formValue$.subscribe((data : any) => {
      this.empDetailsForm.patchValue(data);
    });
  }

}
