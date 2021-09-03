import { Component, OnInit, Output,EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';

@Component({
  selector: 'app-employee-experience',
  templateUrl: './employee-experience.component.html',
  styleUrls: ['./employee-experience.component.css']
})
export class EmployeeExperienceComponent implements OnInit,FormTouched {

  experienceForm : FormGroup;
  
  toppingList:string[]=['Tamil','English','Maths','Science','social'];
  @Output() formDetails=new EventEmitter();

  get experiences() : FormArray {
    return this.experienceForm.get('experiences') as FormArray;
  };

  constructor(private fb : FormBuilder) {
    this.experienceForm = this.fb.group({
      experiences: this.fb.array([this.buildExperiences()])
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
    
  }

  addExperience(): void {
    this.experiences.push(this.buildExperiences());
  }

  buildExperiences(): FormGroup {
    return this.fb.group({
      from: ['', Validators.required],
      to: ['', Validators.required],
      responsiblity: ['', Validators.required],
    });
    
  }
  
}
