import { Component, OnInit, Output,EventEmitter } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { FormControl, FormGroup, FormArray } from '@angular/forms';
import { SmsConstant } from 'src/app/shared/constant-values';
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



  constructor(private fb: FormBuilder, private staffrestApiService : StaffrestApiService) {     
    
    this.empDetailsForm = this.fb.group(
      {
        teacherId : ['',Validators.required],
        employeeId : ['',Validators.required],
        educationId : ['',Validators.required],
        officialEmailId : ['',Validators.required],
        esiNumber : ['',Validators.required],
        staffId : ['',Validators.required],
        employeementstatusId : ['',Validators.required],
        reportingTo : ['',Validators.required],
        epfNumber : ['',Validators.required],
        departmentId : ['',Validators.required],
        joiningDate : ['',Validators.required],
        activeId : ['',Validators.required],
        uanNumber : ['',Validators.required],
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

onSubmit(){

}
  ngOnInit(): void {
    this.staffrestApiService.formValue$.subscribe((data : any) => {
      this.empDetailsForm.patchValue(data);
    });
  }

}
