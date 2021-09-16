import { Component, OnInit, Output,EventEmitter, SimpleChanges, Input } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { Console } from 'console';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';
import { StaffrestApiService } from '../../staffrest-api.service';

@Component({
  selector: 'app-employee-experience',
  templateUrl: './employee-experience.component.html',
  styleUrls: ['./employee-experience.component.css']
})
export class EmployeeExperienceComponent implements OnInit,FormTouched {

  experienceForm : FormGroup;
  
  @Output() formDetails=new EventEmitter();
  @Input() getFormValues = {};
  enabletrash : any = true;

  get experiences() : FormArray {
    return this.experienceForm.get('staffExperiences') as FormArray;
  };

  constructor(private fb : FormBuilder, private staffrestApiService : StaffrestApiService) {
    this.experienceForm = this.fb.group({
      staffExperiences: this.fb.array([this.buildExperiences()]) //
    });
    this.experienceForm.valueChanges.subscribe(()=>{
      this.formDetails.emit({ value: this.experienceForm.value,
               valid: this.experienceForm.valid });
    });
   }

  formTouched(): boolean {
    this.experienceForm.markAllAsTouched();
   return this.experienceForm.valid;
  }

  ngOnInit(): void {
    this.staffrestApiService.formValue$.subscribe((data : any) => {
      console.log("inside ngoninit experience" + JSON.stringify(data.staffExperiences));
      this.experienceForm.patchValue(data);
      data.staffExperiences.forEach((x) => {
        this.experiences.push(this.fb.group(x))
      });

      if(this.experiences.length == 0)
        this.enabletrash = false;
      else
        this.enabletrash = true;  
         
    });
  }

  addExperience(): void {
    this.experiences.push(this.buildExperiences());
  }

  buildExperiences(): FormGroup {
    return this.fb.group({
      from: [''],
      to: [''],
      responsibilty: [''],
    });
    
  }
  
}
